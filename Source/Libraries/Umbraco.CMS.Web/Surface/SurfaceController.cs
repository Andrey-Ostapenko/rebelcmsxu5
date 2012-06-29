﻿using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Cms.Web.Context;
using Umbraco.Cms.Web.Model;
using Umbraco.Cms.Web.Mvc;
using Umbraco.Cms.Web.Mvc.ActionFilters;
using Umbraco.Cms.Web.Mvc.ActionInvokers;
using Umbraco.Cms.Web.Routing;
using Umbraco.Framework;
using Umbraco.Framework.Persistence.Model;

namespace Umbraco.Cms.Web.Surface
{
    /// <summary>
    /// The base controller that all Presentation Add-in controllers should inherit from
    /// </summary>
    [MergeModelStateToChildAction]
    public abstract class SurfaceController : Controller, IRequiresRoutableRequestContext
    {
        public IRoutableRequestContext RoutableRequestContext { get; set; }

        /// <summary>
        /// Useful for debugging
        /// </summary>
        public Guid InstanceId { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="routableRequestContext"></param>
        protected SurfaceController(IRoutableRequestContext routableRequestContext)
        {
            RoutableRequestContext = routableRequestContext;
            InstanceId = Guid.NewGuid();
        }

        /// <summary>
        /// Empty constructor, uses DependencyResolver to resolve the IRoutableRequestContext
        /// </summary>
        protected SurfaceController()
        {
            RoutableRequestContext = DependencyResolver.Current.GetService<IRoutableRequestContext>();
            InstanceId = Guid.NewGuid();
        }

        /// <summary>
        /// Redirects to the Umbraco page with the given id
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        protected RedirectToUmbracoPageResult RedirectToUmbracoPage(HiveId pageId)
        {
            return new RedirectToUmbracoPageResult(pageId, RoutableRequestContext);
        }

        /// <summary>
        /// Redirects to the Umbraco page with the given id
        /// </summary>
        /// <param name="pageEntity"></param>
        /// <returns></returns>
        protected RedirectToUmbracoPageResult RedirectToUmbracoPage(TypedEntity pageEntity)
        {
            return new RedirectToUmbracoPageResult(pageEntity, RoutableRequestContext);
        }

        /// <summary>
        /// Redirects to the currently rendered Umbraco page
        /// </summary>
        /// <returns></returns>
        protected RedirectToUmbracoPageResult RedirectToCurrentUmbracoPage()
        {
            return new RedirectToUmbracoPageResult(CurrentPage, RoutableRequestContext);
        }

        /// <summary>
        /// Returns the currently rendered Umbraco page
        /// </summary>
        /// <returns></returns>
        protected UmbracoPageResult CurrentUmbracoPage()
        {
            return new UmbracoPageResult();
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        protected Content CurrentPage
        {
            get
            {
                if (!ControllerContext.RouteData.DataTokens.ContainsKey("umbraco-route-def"))
                    throw new InvalidOperationException("Can only use " + typeof(UmbracoPageResult).Name + " in the context of an Http POST when using the BeginUmbracoForm helper");

                var routeDef = (RouteDefinition)ControllerContext.RouteData.DataTokens["umbraco-route-def"];
                return routeDef.RenderModel.CurrentNode;
            }
        }

    }
}