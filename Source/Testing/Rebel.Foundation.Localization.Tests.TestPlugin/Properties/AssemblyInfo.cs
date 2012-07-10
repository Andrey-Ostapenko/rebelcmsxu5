﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rebel.Foundation.Localization.Tests.TestPlugin;
using System.Web.UI;
using Rebel.Foundation.Localization.Configuration;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Rebel.Foundation.Localization.Tests.TestPlugin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Rebel.Foundation.Localization.Tests.TestPlugin")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2011")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("c80d1dd8-05cb-4820-9371-f33e2d477ad2")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]


[assembly: LocalizationXmlSource("Redirect.Texts.xml")]
[assembly: LocalizationXmlSource("Redirect.en-US.xml")]


[assembly: LocalizationSourceFactory(typeof(MutatingTextSourceFactory))]
[assembly: LocalizationSourceFactory(typeof(CustomTextSourceFactory))]

[assembly: WebResource("Rebel.Foundation.Localization.Tests.TestPlugin.Tulips.jpg", "image/jpeg")]