﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebel.Cms.Web.Templates
{
    public class TemplateParserResult
    {
        public string Layout { get; set; }
        public IEnumerable<string> Sections { get; set; }
    }
}
