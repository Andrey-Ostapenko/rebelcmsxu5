﻿using Rebel.Framework.Persistence.Abstractions.Attribution.MetaData;
using Rebel.Framework.Persistence.Model.Attribution;

namespace Rebel.Framework.Persistence.Model.Constants.SerializationTypes
{
    using Rebel.Framework.Data;

    public class StringSerializationType : IAttributeSerializationDefinition
    {
        #region Implementation of IReferenceByName

        /// <summary>
        /// Gets or sets the alias of the object. The alias is a string to which this object
        /// can be referred programmatically, and is often a normalised version of the <see cref="IReferenceByName.Name"/> property.
        /// </summary>
        /// <value>The alias.</value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the name of the object. The name is a string intended to be human-readable, and
        /// is often a more descriptive version of the <see cref="IReferenceByName.Alias"/> property.
        /// </summary>
        /// <value>The name.</value>
        public LocalizedString Name { get; set; }

        #endregion

        #region Implementation of IAttributeSerializationDefinition<LocalizedString>

        /// <summary>
        ///   Gets or sets the type of the data serialization.
        /// </summary>
        /// <value>The type of the data serialization.</value>
        public DataSerializationTypes DataSerializationType { get { return DataSerializationTypes.String; } }

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>        
        public dynamic Serialize(TypedAttribute value)
        {
            return (dynamic)value.DynamicValue;
        }

        #endregion

    }
}