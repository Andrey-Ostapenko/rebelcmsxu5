﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Umbraco.Framework;
using Umbraco.Framework.Persistence.Model;
using Umbraco.Framework.Persistence.Model.Associations;

namespace Umbraco.Hive
{
    using Umbraco.Framework.Persistence.Model.Versioning;

    public class AbstractHiveEventArgs : EventArgs
    {
        public AbstractHiveEventArgs(AbstractScopedCache scopedCache)
        {
            ScopedCache = scopedCache;
        }

        /// <summary>
        /// Gets or sets the scoped cache.
        /// </summary>
        /// <value>The scoped cache.</value>
        public AbstractScopedCache ScopedCache { get; protected set; }
    }

    public class HiveSchemaPreActionEventArgs : AbstractHiveEventArgs
    {
        public HiveSchemaPreActionEventArgs(AbstractSchemaPart schemaPart, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            SchemaPart = schemaPart;
        }

        /// <summary>
        /// Gets or sets the schema part.
        /// </summary>
        /// <value>The schema part.</value>
        public AbstractSchemaPart SchemaPart { get; protected set; }
    }

    public class HiveEntityPreActionEventArgs : AbstractHiveEventArgs
    {
        public HiveEntityPreActionEventArgs(IRelatableEntity entity, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Entity = entity;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public IRelatableEntity Entity { get; protected set; }
    }

    public class HiveEntityPreDeletionEventArgs : AbstractHiveEventArgs
    {
        public HiveEntityPreDeletionEventArgs(HiveId id, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public HiveId Id { get; protected set; }
    }

    public class HiveEntityPostDeletionEventArgs : AbstractHiveEventArgs
    {
        public HiveEntityPostDeletionEventArgs(HiveId id, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public HiveId Id { get; protected set; }
    }

    public class HiveRevisionPreActionEventArgs : AbstractHiveEventArgs
    {
        public HiveRevisionPreActionEventArgs(IRevision<IVersionableEntity> entity, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Entity = entity;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public IRevision<IVersionableEntity> Entity { get; protected set; }
    }

    public class HiveRelationPreActionEventArgs : AbstractHiveEventArgs
    {
        public HiveRelationPreActionEventArgs(IReadonlyRelation<IRelatableEntity, IRelatableEntity> relation, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Relation = relation;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public IReadonlyRelation<IRelatableEntity, IRelatableEntity> Relation { get; protected set; }
    }

    public class HiveRelationPostActionEventArgs : AbstractHiveEventArgs
    {
        public HiveRelationPostActionEventArgs(IReadonlyRelation<IRelatableEntity, IRelatableEntity> relation, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Relation = relation;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public IReadonlyRelation<IRelatableEntity, IRelatableEntity> Relation { get; protected set; }
    }

    public class HiveRelationByIdPreActionEventArgs : AbstractHiveEventArgs
    {
        public HiveRelationByIdPreActionEventArgs(IRelationById relation, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Relation = relation;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public IRelationById Relation { get; protected set; }
    }

    public class HiveRelationByIdPostActionEventArgs : AbstractHiveEventArgs
    {
        public HiveRelationByIdPostActionEventArgs(IRelationById relation, AbstractScopedCache scopedCache)
            : base(scopedCache)
        {
            Relation = relation;
        }

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
        public IRelationById Relation { get; protected set; }
    }
}
