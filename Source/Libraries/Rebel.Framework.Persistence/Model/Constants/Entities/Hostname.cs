﻿using Rebel.Framework.Persistence.Model.Constants.AttributeDefinitions;
using Rebel.Framework.Persistence.Model.Constants.Schemas;

namespace Rebel.Framework.Persistence.Model.Constants.Entities
{
    /// <summary>
    /// A hostname entity
    /// </summary>
    public class Hostname : TypedEntity
    {
        public Hostname()
        {
            this.SetupFromSchema<HostnameSchema>();
        }

        /// <summary>
        /// Gets/sets the hostname
        /// </summary>
        public string Name
        {
            get { return Attributes[HostnameSchema.HostnameAlias].DynamicValue; }
            set { Attributes[HostnameSchema.HostnameAlias].DynamicValue = value; }
        }

    }
}