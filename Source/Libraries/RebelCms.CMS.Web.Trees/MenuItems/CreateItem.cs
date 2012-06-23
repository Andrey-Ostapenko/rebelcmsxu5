﻿using System;
using System.Collections.Generic;
using ClientDependency.Core;
using RebelCms.Cms.Web.Model.BackOffice.Trees;
using RebelCms.Cms.Web.Mvc.ActionFilters;
using RebelCms.Framework.Persistence.Model.Constants;
using RebelCms.Framework.Security;

namespace RebelCms.Cms.Web.Trees.MenuItems
{
    [ClientDependency(ClientDependencyType.Javascript, "Tree/MenuItems.js", "Modules")]
    [MenuItem("D0635D22-B66C-4DC9-8442-3325CE5D5EE9", "Create", false, true, "RebelCms.Controls.MenuItems.createItem", "menu-create")]
    [RebelCmsAuthorize(Permissions = new[] { FixedPermissionIds.Create })]
    public class CreateItem : RequiresDataKeyMenuItem
    {
        public override string[] RequiredKeys
        {
            get { return new[] { "createUrl" }; }
        }
    }
}
