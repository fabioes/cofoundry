﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    /// <summary>
    /// Page section information for rendering a page including 
    /// full module details with mapped display models.
    /// </summary>
    public class PageSectionRenderDetails : IEntitySectionRenderDetails<PageVersionModuleRenderDetails>
    {
        public int PageTemplateSectionId { get; set; }

        public string Name { get; set; }

        public PageVersionModuleRenderDetails[] Modules { get; set; }
    }
}
