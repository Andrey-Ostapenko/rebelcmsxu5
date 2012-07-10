﻿using System.Collections.Generic;

namespace Rebel.Framework.EntityGraph.Domain.Entity.Graph
{
    /// <summary>
    ///   Represents a graph of typed entities through a list of entity vertices.
    /// Typed entities are entities which have a guaranteed schema of attributes.
    /// </summary>
    public interface ITypedEntityGraph<T> : IDictionary<IMappedIdentifier, T> where T : ITypedEntityVertex
    {
    }
}