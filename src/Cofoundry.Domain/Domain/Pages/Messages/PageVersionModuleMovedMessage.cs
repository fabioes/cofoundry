﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    /// <summary>
    /// Message published when a module has been moved on a page
    /// </summary>
    public class PageVersionModuleMovedMessage : IPageContentUpdatedMessage
    {
        /// <summary>
        /// Id of the page affected by the change
        /// </summary>
        public int PageId { get; set; }

        /// <summary>
        /// The id of the PageVersionModule that was moved
        /// </summary>
        public int PageVersionModuleId { get; set; }

        /// <summary>
        /// Always false because modules can only be modified on draft versions
        /// </summary>
        public bool HasPublishedVersionChanged { get { return false; } }
    }
}
