﻿using System.Configuration;
using RebelCms.Framework.Configuration;

namespace RebelCms.Cms.Web.Configuration.RebelCmsSystem
{
    [ConfigurationCollection(typeof(RouteMatchElement))]
    public class RouteMatchElementCollection : ConfigurationElementCollection<string, RouteMatchElement>
    {
        public const string CollectionXmlKey = "routeMatches";

        /// <summary>
        /// Gets the type of the <see cref="T:System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Configuration.ConfigurationElementCollectionType"/> of this collection.
        /// </returns>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        /// <summary>
        /// Gets the name used to identify this collection of elements in the configuration file when overridden in a derived class.
        /// </summary>
        /// <returns>
        /// The name of the collection; otherwise, an empty string. The default is an empty string.
        /// </returns>
        protected override string ElementName
        {
            get { return CollectionXmlKey; }
        }

        protected override string GetElementKey(RouteMatchElement element)
        {
            return element.Path;
        }

        
    }
}