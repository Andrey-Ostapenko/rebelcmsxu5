using Umbraco.Framework.Persistence.Model.Constants;
using Umbraco.Framework.Security;

namespace Umbraco.Cms.Web.Security.Permissions
{
    [Permission(FixedPermissionIds.PublicAccess, "Public Access", FixedPermissionTypes.EntityAction, UserType.User)]
    public class PublicAccessPermission : Permission
    { }
}