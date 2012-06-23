﻿using System;
using System.Linq;
using NUnit.Framework;
using System.Web.Mvc;
using RebelCms.Cms.Web.System;
using RebelCms.Tests.Cms.Stubs;
using RebelCms.Cms.Web;
using RebelCms.Cms.Web.Mvc.Metadata;
using System.Reflection;
using System.IO;
using RebelCms.Cms.Web.Mvc.ModelBinders.BackOffice;
using RebelCms.Framework;
using RebelCms.Tests.Extensions;

namespace RebelCms.Tests.Cms.Mvc.ModelBinders
{
    [TestFixture]
    public abstract class ModelBinderTest : StandardWebTest
    {
        
        #region Initialize

        //static bool _isInit = false;

        /// <summary>
        /// Initialize test class, this only runs once per class
        /// </summary>
        [SetUp]
        public void InitTest()
        {
            Init();

            //if (_isInit)
            //{
            //    return;
            //}

            ////ControllerBuilder.Current.SetControllerFactory(new TestControllerFactory());
            ////ModelMetadataProviders.Current = new RebelCmsModelMetadataProvider();

            //var binFolder = TestHelper.CurrentAssemblyDirectory;

            ////init auto mapper
            //new WebDomainMapInitializer(null).Initialize();

            ////setup the demo data
            //DevDataset = DemoDataHelper.GetDemoData();

            //var settingsFile = new FileInfo(Path.Combine(binFolder, "web.config"));
            //Settings = new RebelCmsSettings(settingsFile);

            ////add the model binders

            //if (!System.Web.Mvc.ModelBinders.Binders.ContainsKey(typeof(HiveId)))
            //    System.Web.Mvc.ModelBinders.Binders.Add(typeof(HiveId), new HiveIdModelBinder());

            //_isInit = true;
        }

        #endregion

    }
}
