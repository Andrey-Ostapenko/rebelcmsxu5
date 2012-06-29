﻿using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Cms.Web.System;
using Umbraco.Framework;
using log4net.Config;
using Umbraco.Cms.Web.Context;
using Umbraco.Cms.Web.DependencyManagement.DemandBuilders;
using Umbraco.Cms.Web.Mvc.Areas;
using Umbraco.Cms.Web.Mvc.ControllerFactories;
using Umbraco.Cms.Web.System.Boot;
using Umbraco.Cms.Web.Tasks;
using Umbraco.Cms.Web.Trees;
using Umbraco.Framework.DependencyManagement;
using Umbraco.Framework.DependencyManagement.Autofac;
using System.Collections.Generic;
using Umbraco.Framework.Diagnostics;
using IDependencyResolver = Umbraco.Framework.DependencyManagement.IDependencyResolver;
using Umbraco.Cms.Web.DependencyManagement;
using Umbraco.Framework.Tasks;

namespace Umbraco.Cms.Web.UI 
{
    using global::System.Threading;

    public class MvcApplication : HttpApplication
    {
        private static bool _isInitialised = false;
        private static readonly ReaderWriterLockSlim InitialiserLocker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        static MvcApplication()
        {
            LogHelper.TraceIfEnabled<MvcApplication>("Http application warmup");
        }

        protected static UmbracoWebApplication UmbracoWebApplication { get; set; }

        /// <summary>
        /// Initializes the application
        /// </summary>
        protected virtual void Application_Start()
        {
            using (new WriteLockDisposable(InitialiserLocker))
            {
                if (_isInitialised) return;
                UmbracoWebApplication = CreateUmbracoApplication();
                UmbracoWebApplication.Start();
                _isInitialised = true;
            }
        }
        
        protected virtual void Application_End()
        {
            var reason = HostingEnvironment.ShutdownReason;

            LogHelper.TraceIfEnabled<MvcApplication>("Shutting down due to: " + reason.ToString());
            LogHelper.TraceIfEnabled<MvcApplication>("Stack on shutdown: " + TryGetShutdownStack());
        }

        private static string TryGetShutdownStack()
        {
            try
            {
                var runtime = (HttpRuntime) typeof (HttpRuntime)
                                                .InvokeMember("_theRuntime",
                                                              BindingFlags.NonPublic | BindingFlags.Static |
                                                              BindingFlags.GetField,
                                                              null,
                                                              null,
                                                              null);

                if (runtime != null)
                {
                    return (string) runtime
                                        .GetType()
                                        .InvokeMember("_shutDownStack",
                                                      BindingFlags.NonPublic
                                                      | BindingFlags.Instance
                                                      | BindingFlags.GetField,
                                                      null,
                                                      runtime,
                                                      null);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error<MvcApplication>("Couldn't get shutdown stack: " + ex.Message, ex);
            }
            return string.Empty;
        }

        // UmbracoWebApplication cannot hook this event programatically in the Start event due to a known
        // bug in ASP.NET causing a NullRef in PipelineRequestManager if events are hooked in the application init (http://forums.asp.net/t/1327102.aspx/1)
        protected virtual void Application_EndRequest(object sender, EventArgs e)
        {
            UmbracoWebApplication.IfNotNull(x => x.OnEndRequest(sender, e));
        }

        /// <summary>
        /// Creates the container builder. Override this if you'd like to use an alternative <see cref="AbstractContainerBuilder"/> to the default.
        /// </summary>
        /// <returns></returns>
        protected virtual AbstractContainerBuilder CreateContainerBuilder()
        {
            return new AutofacContainerBuilder();
        }

        protected virtual Func<IDependencyResolver, global::System.Web.Mvc.IDependencyResolver> MvcResolverFactory()
        {
            return x => new AutofacMvcResolver(x);
        }

        /// <summary>
        /// Creates the Umbraco application. Override this if you'd like to use your own extended version of <see cref="UmbracoWebApplication"/>.
        /// </summary>
        /// <returns></returns>
        protected virtual UmbracoWebApplication CreateUmbracoApplication()
        {
            return new UmbracoWebApplication(
                this, 
                CreateContainerBuilder(), 
                MvcResolverFactory(),
                RegisterMvcAreas,
                () => RegisterMvcGlobalFilters(GlobalFilters.Filters),
                () => RegisterCustomMvcRoutes(RouteTable.Routes),
                () => RegisterDefaultMvcRoutes(RouteTable.Routes));
        }

        /// <summary>
        /// Registers MVC Areas
        /// </summary>
        protected virtual void RegisterMvcAreas()
        {
            UmbracoWebApplication.RegisterAllDefaultMvcAreas();
        }

        /// <summary>
        /// Registers custom MVC Routes which occur before the Umbraco catch all route
        /// </summary>
        /// <param name="routes"></param>
        protected virtual void RegisterCustomMvcRoutes(RouteCollection routes)
        {
            
        }

        /// <summary>
        /// Registers default MVC Routes which occur after the Umbraco catch all route
        /// </summary>
        /// <param name="routes"></param>
        protected virtual void RegisterDefaultMvcRoutes(RouteCollection routes)
        {
            UmbracoWebApplication.RegisterDefaultRoutes(routes);
        }

        /// <summary>
        /// Registers MVC Global Filters
        /// </summary>
        /// <param name="filters"></param>
        protected virtual void RegisterMvcGlobalFilters(GlobalFilterCollection filters)
        {
            UmbracoWebApplication.RegisterDefaultGlobalFilters(filters);  
        }

    }
}