﻿using System.Collections.Generic;

namespace RebelCms.Framework.Persistence.Abstractions
{
    /// <summary>
    /// Provides a simple 1-dimensional list of entities
    /// </summary>
    public interface IPersistenceEntityCollection : IDictionary<IMappedIdentifier, IPersistenceEntity>, IEnumerable<IPersistenceEntity>
    {
    }
}