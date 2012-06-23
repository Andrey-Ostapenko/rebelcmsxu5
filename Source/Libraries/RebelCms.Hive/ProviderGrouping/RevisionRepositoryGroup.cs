﻿using System;
using System.Collections.Generic;
using System.Linq;
using RebelCms.Framework;
using RebelCms.Framework.Persistence.Model.Versioning;
using RebelCms.Hive.ProviderSupport;
using RebelCms.Hive.RepositoryTypes;

namespace RebelCms.Hive.ProviderGrouping
{
    public class RevisionRepositoryGroup<TFilter, T>
        : AbstractRepositoryGroup, IRevisionRepositoryGroup<TFilter, T>
        where T : class, IVersionableEntity
        where TFilter : class, IProviderTypeFilter
    {
        public RevisionRepositoryGroup(IEnumerable<AbstractRevisionRepository<T>> childRepositories, Uri idRoot, AbstractScopedCache scopedCache, RepositoryContext hiveContext)
            : base(childRepositories, idRoot, scopedCache, hiveContext)
        {
            ChildSessions = childRepositories;
        }
        
        protected IEnumerable<ProviderSupport.AbstractRevisionRepository<T>> ChildSessions { get; set; }

        protected override void DisposeResources()
        {
            ChildSessions.Dispose();
        }

        public Revision<TEntity> Get<TEntity>(HiveId entityId, HiveId revisionId) where TEntity : class, T
        {
            return ChildSessions.Get<TEntity>(entityId, revisionId, IdRoot);
        }

        public IEnumerable<Revision<TEntity>> GetAll<TEntity>() where TEntity : class, T
        {
            return ChildSessions.GetAll<TEntity>(IdRoot);
        }

        public void AddOrUpdate<TEntity>(Revision<TEntity> revision) where TEntity : class, T
        {
            ChildSessions.Add<TEntity>(revision, IdRoot);
        }

        public EntitySnapshot<TEntity> GetLatestSnapshot<TEntity>(HiveId hiveId, RevisionStatusType revisionStatusType = null) where TEntity : class, T
        {
            return ChildSessions.GetLatestSnapshot<TEntity>(hiveId, IdRoot, revisionStatusType);
        }

        public Revision<TEntity> GetLatestRevision<TEntity>(HiveId entityId, RevisionStatusType revisionStatusType = null) where TEntity : class, T
        {
            return ChildSessions.GetLatestRevision<TEntity>(entityId, IdRoot, revisionStatusType);
        }

        public IEnumerable<Revision<TEntity>> GetAll<TEntity>(HiveId entityId, RevisionStatusType revisionStatusType = null) where TEntity : class, T
        {
            return ChildSessions.GetAll<TEntity>(entityId, IdRoot, revisionStatusType);
        }

        public IEnumerable<Revision<TEntity>> GetLatestRevisions<TEntity>(bool allOrNothing, RevisionStatusType revisionStatusType = null, params HiveId[] entityIds) where TEntity : class, T
        {
            return ChildSessions.GetLatestRevisions<TEntity>(allOrNothing, IdRoot, revisionStatusType, entityIds);
        }
    }
}