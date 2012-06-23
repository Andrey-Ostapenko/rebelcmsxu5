﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using RebelCms.Cms.Web.Context;
using RebelCms.Cms.Web.Model.BackOffice;
using RebelCms.Framework;
using RebelCms.Framework.Persistence;
using RebelCms.Framework.Persistence.Model;
using RebelCms.Framework.Persistence.Model.Constants;
using RebelCms.Framework.Persistence.Model.Constants.AttributeDefinitions;
using RebelCms.Hive;
using RebelCms.Hive.RepositoryTypes;

namespace RebelCms.Cms.Web.Mvc.Controllers.BackOffice
{
    public class TreePickerController : Controller
    {
        private readonly IRoutableRequestContext _requestContext;

        public TreePickerController(IRoutableRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        /// <summary>
        /// Renders a tree picker
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Index(TreePickerRenderModel model)
        {
            if(model != null && model.SelectedValue != null && !model.SelectedValue.Value.IsNullValueOrEmpty() && string.IsNullOrWhiteSpace(model.SelectedText))
            {
                model.SelectedText = "Unknown";

                var treeMetaData = _requestContext.RegisteredComponents
                    .TreeControllers
                    .Where(x => x.Metadata.Id == model.TreeControllerId)
                    .SingleOrDefault();

                if(treeMetaData != null && model.SelectedValue.Value.Value == model.TreeVirtualRootId.Value)
                {
                    model.SelectedText = treeMetaData.Metadata.TreeTitle;
                }
                else
                {
                    var hive = _requestContext.Application.Hive.GetReader<IContentStore>(model.SelectedValue.Value.ToUri());
                    if (hive != null)
                    {
                        using (var uow = hive.CreateReadonly())
                        {
                            var entity = uow.Repositories.Get<TypedEntity>(model.SelectedValue.Value);
                            if (entity != null)
                            {
                                var nameAttr = entity.GetAttributeValueAsString(NodeNameAttributeDefinition.AliasValue, "Name");
                                    // TODO: Can't guarantee attribute is "name"?)
                                if (!string.IsNullOrEmpty(nameAttr))
                                    model.SelectedText = Server.UrlEncode(nameAttr).Replace("+", "%20");
                            }
                        }
                    }
                }
            }

            return PartialView("TreePickerPartial", model);
        }
    }
}
