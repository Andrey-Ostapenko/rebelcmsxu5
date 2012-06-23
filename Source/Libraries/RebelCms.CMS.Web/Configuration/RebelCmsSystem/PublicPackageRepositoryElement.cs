﻿using System.Configuration;

namespace RebelCms.Cms.Web.Configuration.RebelCmsSystem
{
    public class PublicPackageRepositoryElement : ConfigurationElement
    {
        
        /// <summary>
        /// Gets or sets the repository address.
        /// </summary>
        /// <value>
        /// The repository address.
        /// </value>
        [ConfigurationProperty("repositoryAddress", IsRequired = true)]
        public string RepositoryAddress
        {
            get { return this["repositoryAddress"].ToString(); }
            set
            {
                this["repositoryAddress"] = value;
            }
        }

    }
}