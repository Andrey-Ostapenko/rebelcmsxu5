﻿using System;
using Rebel.Framework.Data.Common;
using Rebel.Framework.EntityGraph.Domain.ObjectModel;
using Rebel.Framework.EntityGraph.Domain.Versioning;

namespace Rebel.Framework.EntityGraph.Domain.Entity.Attribution.MetaData
{
    public class AttributeGroupDefinition : IAttributeGroupDefinition 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeGroupDefinition"/> class.
        /// </summary>
        public AttributeGroupDefinition()
        {
            AttributeDefinitions = new EntityCollection<IAttributeDefinition>();
        }

        #region Implementation of ITracksConcurrency

        /// <summary>
        ///   Gets or sets the concurrency token.
        /// </summary>
        /// <value>The concurrency token.</value>
        public IConcurrencyToken ConcurrencyToken { get; set; }

        #endregion

        #region Implementation of IEntity

        /// <summary>
        ///   Gets or sets the status of the entity.
        /// </summary>
        /// <value>The status.</value>
        public IEntityStatus Status { get; set; }

        /// <summary>
        ///   Gets or sets the creation date of the entity (UTC).
        /// </summary>
        /// <value>The UTC created.</value>
        public DateTime UtcCreated { get; set; }

        /// <summary>
        ///   Gets or sets the modification date of the entity (UTC).
        /// </summary>
        /// <value>The UTC modified.</value>
        public DateTime UtcModified { get; set; }

        /// <summary>
        ///   Gets or sets the timestamp when the status of this entity was last changed (in UTC).
        /// </summary>
        /// <value>The UTC status changed.</value>
        public DateTime UtcStatusChanged { get; set; }

        /// <summary>
        ///   Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public IMappedIdentifier Id { get; set; }

        /// <summary>
        ///   Gets or sets the revision data.
        /// </summary>
        /// <value>The revision.</value>
        public IRevisionData Revision { get; set; }

        #endregion

        #region Implementation of IReferenceByAlias

        /// <summary>
        /// Gets or sets the alias of the object. The alias is a string to which this object
        /// can be referred programmatically, and is often a normalised version of the <see cref="IReferenceByAlias.Name"/> property.
        /// </summary>
        /// <value>The alias.</value>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the name of the object. The name is a string intended to be human-readable, and
        /// is often a more descriptive version of the <see cref="IReferenceByAlias.Alias"/> property.
        /// </summary>
        /// <value>The name.</value>
        public LocalizedString Name { get; set; }

        #endregion

        #region Implementation of IComparable<in int>

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IReferenceByOrdinal

        /// <summary>
        /// Gets the ordinal.
        /// </summary>
        /// <value>The ordinal.</value>
        public int Ordinal { get; set; }

        #endregion

        /// <summary>
        /// Gets the attribute definitions.
        /// </summary>
        /// <value>The attribute definitions.</value>
        public IEntityCollection<IAttributeDefinition> AttributeDefinitions { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Id.ValueAsString;
        }
    }
}