﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Rebel.Framework;

namespace Rebel.Cms.Web.Model.BackOffice.Editors
{
    using Rebel.Framework.Persistence.Model;
    using Rebel.Framework.Persistence.Model.Versioning;
    using global::System.ComponentModel;

    public class RollbackModel : DialogModel
    {
        public HiveId Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public IEnumerable<SelectListItem> Versions { get; set; }

        [ReadOnly(true)]
        public Revision<TypedEntity> LastRevision { get; set; }

        public RollbackModel()
        {
            Versions = new List<SelectListItem>();
        }
    }
}
