﻿using System.Collections.ObjectModel;

namespace Rebel.Cms.Web.Routing
{
    /// <summary>
    /// A keyed collection of HostnameEntry's
    /// </summary>
    public class HostnameCollection : KeyedCollection<string, HostnameEntry>
    {
        protected override string GetKeyForItem(HostnameEntry item)
        {
            return item.Hostname;
        }
    }
}