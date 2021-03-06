﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;
using System.Reflection;

namespace Cofoundry.Domain
{
    public interface ICustomEntityDisplayModelMapper
    {
        TDisplayModel MapDetails<TDisplayModel>(CustomEntityRenderDetails dataModel)
            where TDisplayModel : ICustomEntityDisplayModel;
    }
}
