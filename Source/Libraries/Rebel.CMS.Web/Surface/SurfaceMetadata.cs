﻿using System.Collections.Generic;
using Rebel.Cms.Web.Model.BackOffice;

namespace Rebel.Cms.Web.Surface
{
    public class SurfaceMetadata : ControllerPluginMetadata
    {
        public SurfaceMetadata(IDictionary<string, object> obj)
            : base(obj)
        {
        }

        /// <summary>
        /// Flag to advertise if this Surface controller can part take in Surface child view macros
        /// </summary>
        public bool HasChildActionMacros { get; set; }

    }
}
