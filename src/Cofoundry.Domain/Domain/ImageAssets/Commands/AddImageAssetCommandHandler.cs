﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain.Data;
using Cofoundry.Domain.CQS;
using Cofoundry.Core;
using Cofoundry.Core.EntityFramework;

namespace Cofoundry.Domain
{
    public class AddImageAssetCommandHandler 
        : IAsyncCommandHandler<AddImageAssetCommand>
        , IPermissionRestrictedCommandHandler<AddImageAssetCommand>
    {
        #region constructor

        private readonly CofoundryDbContext _dbContext;
        private readonly EntityAuditHelper _entityAuditHelper;
        private readonly EntityTagHelper _entityTagHelper;
        private readonly ImageAssetCommandHelper _imageAssetCommandHelper;
        private readonly ITransactionScopeFactory _transactionScopeFactory;

        public AddImageAssetCommandHandler(
            CofoundryDbContext dbContext,
            EntityAuditHelper entityAuditHelper,
            EntityTagHelper entityTagHelper,
            ImageAssetCommandHelper imageAssetCommandHelper,
            ITransactionScopeFactory transactionScopeFactory
            )
        {
            _dbContext = dbContext;
            _entityAuditHelper = entityAuditHelper;
            _entityTagHelper = entityTagHelper;
            _imageAssetCommandHelper = imageAssetCommandHelper;
            _transactionScopeFactory = transactionScopeFactory;
        }

        #endregion

        #region Execute

        public async Task ExecuteAsync(AddImageAssetCommand command, IExecutionContext executionContext)
        {
            var imageAsset = new ImageAsset();

            imageAsset.FileDescription = command.Title;
            imageAsset.FileName = SlugFormatter.ToSlug(command.Title);
            imageAsset.DefaultAnchorLocation = command.DefaultAnchorLocation;
            _entityTagHelper.UpdateTags(imageAsset.ImageAssetTags, command.Tags, executionContext);
            _entityAuditHelper.SetCreated(imageAsset, executionContext);

            using (var scope = _transactionScopeFactory.Create())
            {
                // if adding, save this up front
                _dbContext.ImageAssets.Add(imageAsset);

                await _imageAssetCommandHelper.SaveFile(command.File, imageAsset);

                command.OutputImageAssetId = imageAsset.ImageAssetId;
                scope.Complete();
            }
        }
        
        #endregion

        #region Permission

        public IEnumerable<IPermissionApplication> GetPermissions(AddImageAssetCommand command)
        {
            yield return new ImageAssetCreatePermission();
        }

        #endregion
    }
}
