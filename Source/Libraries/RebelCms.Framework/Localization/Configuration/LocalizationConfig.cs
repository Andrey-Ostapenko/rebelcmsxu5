﻿using System;

namespace RebelCms.Framework.Localization.Configuration
{
    
    public static class LocalizationConfig
    {
        public const string DefaultXmlFileName = "LocalizationEntries.xml";

        public static Func<TextManager> TextManagerResolver { get; set; }

        /// <summary>
        /// Gets the current text manager as defined by TextManagerResolver.
        /// </summary>
        public static TextManager TextManager
        {
            get
            {
                return TextManagerResolver != null ? TextManagerResolver() : null;
            }
        }        

        public static DefaultTextManager SetupDefault()
        {
            var manager = new DefaultTextManager();
            //manager.PrepareAssemblyTextSources();
            TextManagerResolver = () => manager;
            return manager;
        }
    }
}
