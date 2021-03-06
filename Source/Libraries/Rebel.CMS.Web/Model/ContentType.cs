﻿using System.Collections.Generic;
using Rebel.Framework;

namespace Rebel.Cms.Web.Model
{
    public class ContentType : NodeWithAlias
    {
        public ContentType(string @alias, LocalizedString name, IEnumerable<FieldDefinition> definitions)
        {
            Alias = alias;
            Name = name;
            Definitions = definitions;
            foreach (var fieldDefinition in Definitions)
            {
                fieldDefinition.ContentType = this;
            }
        }

        public IEnumerable<FieldDefinition> Definitions { get; protected set; }
    }
}
