﻿using System;
using System.Configuration;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Umbraco.Cms.Web.Configuration.Languages
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class LanguageElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember]
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the iso code.
        /// </summary>
        /// <value>
        /// The iso code.
        /// </value>
        [DataMember]
        [ConfigurationProperty("isoCode", IsRequired = true, IsKey = true)]
        public string IsoCode
        {
            get
            {
                return (string)this["isoCode"];
            }
            set
            {
                this["isoCode"] = value;
            }
        }

        /// <summary>
        /// Gets the fallbacks.
        /// </summary>
        [IgnoreDataMember]
        [ConfigurationCollection(typeof(FallbackCollection), AddItemName = "fallback")]
        [ConfigurationProperty("fallbacks", IsRequired = false)]
        public FallbackCollection Fallbacks
        {
            get
            {
                return (FallbackCollection)base["fallbacks"];
            }
            set
            {
                base["fallbacks"] = value;
            }
        }

        /// <summary>
        /// Converts the laanguage to an XML string.
        /// </summary>
        /// <returns></returns>
        public string ToXmlString()
        {
            var settings = new XmlWriterSettings { Indent = true };
            var builder = new StringBuilder();
            using (var writer = XmlWriter.Create(builder, settings))
            {
                this.SerializeToXmlElement(writer, "language");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Configuration.ConfigurationElement"/> object is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Configuration.ConfigurationElement"/> object is read-only; otherwise, false.
        /// </returns>
        public override bool IsReadOnly()
        {
            return false;
        }
    }
}
