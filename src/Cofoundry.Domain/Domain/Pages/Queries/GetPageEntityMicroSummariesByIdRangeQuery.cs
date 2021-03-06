﻿using Conditions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Domain.CQS;

namespace Cofoundry.Domain
{
    public class GetPageEntityMicroSummariesByIdRangeQuery : IQuery<IDictionary<int, RootEntityMicroSummary>>
    {
        public GetPageEntityMicroSummariesByIdRangeQuery()
        {
        }

        public GetPageEntityMicroSummariesByIdRangeQuery(
            IEnumerable<int> ids
            )
        {
            Condition.Requires(ids).IsNotNull();

            PageIds = ids.ToArray();
        }

        [Required]
        public int[] PageIds { get; set; }
    }
}
