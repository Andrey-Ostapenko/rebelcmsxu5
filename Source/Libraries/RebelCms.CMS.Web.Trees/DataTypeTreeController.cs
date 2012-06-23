﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RebelCms.Cms.Web.Context;
using RebelCms.Cms.Web.Editors;
using RebelCms.Cms.Web.Model.BackOffice.Trees;
using RebelCms.Cms.Web.Trees.MenuItems;
using RebelCms.Framework;
using RebelCms.Framework.Persistence;
using RebelCms.Framework.Persistence.Model.Attribution.MetaData;
using RebelCms.Hive;
using RebelCms.Hive.RepositoryTypes;
using RebelCms.Framework.Persistence.Model.Constants;

namespace RebelCms.Cms.Web.Trees
{

    /// <summary>
    /// Tree controller to render out the data types
    /// </summary>
    [Tree(CorePluginConstants.DataTypeTreeControllerId, "Data types")]
    [RebelCmsTree]
    public class DataTypeTreeController : SupportsEditorTreeController
    {

        public DataTypeTreeController(IBackOfficeRequestContext requestContext)
            : base(requestContext)
        {
        }

        /// <summary>
        /// Returns a unique tree root node id
        /// </summary>
        /// <remarks>
        /// We are assigning a static unique id to this tree in order to facilitate tree node syncing
        /// </remarks>
        protected override HiveId RootNodeId
        {
            get { return new HiveId(FixedSchemaTypes.SystemRoot, null, new HiveIdValue(new Guid(CorePluginConstants.DataTypeTreeRootNodeId))); }
        }


        /// <summary>
        /// Defines the data type editor
        /// </summary>
        public override Guid EditorControllerId
        {
            get { return new Guid(CorePluginConstants.DataTypeEditorControllerId); }
        }

        /// <summary>
        /// Customize the created root node
        /// </summary>
        /// <param name="queryStrings"></param>
        /// <returns></returns>
        protected override TreeNode CreateRootNode(FormCollection queryStrings)
        {
            var n = base.CreateRootNode(queryStrings);

            //add some menu items to the created root node
            n.AddEditorMenuItem<CreateItem>(this, "createUrl", "CreateNew");
            n.AddMenuItem<Reload>();

            return n;
        }

        protected override RebelCmsTreeResult GetTreeData(HiveId parentId, FormCollection queryStrings)
        {
            //if its the first level
            if (parentId == RootNodeId)
            {
                using (var uow = BackOfficeRequestContext.Application.Hive.OpenReader<IContentStore>())
                {
                    var items = uow.Repositories.Schemas.GetAll<AttributeType>()
                        .Where(x => !x.Id.IsSystem())
                        .OrderBy(x => x.Name.Value);

                    foreach (var treeNode in items.Select(dt =>
                                                          CreateTreeNode(
                                                              dt.Id,
                                                              queryStrings,
                                                              dt.Name,
                                                              Url.GetEditorUrl(dt.Id, EditorControllerId, BackOfficeRequestContext.RegisteredComponents, BackOfficeRequestContext.Application.Settings),
                                                              false,
                                                              "tree-data-type")))
                    {
                        //add the menu items
                        treeNode.AddEditorMenuItem<Delete>(this, "deleteUrl", "Delete");

                        NodeCollection.Add(treeNode);
                    }
                }

            }
            else if (!AddRootNodeToCollection(parentId, queryStrings))
            {
                throw new NotSupportedException("The DataType tree does not support more than 1 level");
            }

            return RebelCmsTree();
        }

    }
}
