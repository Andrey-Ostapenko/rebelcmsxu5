using Umbraco.Framework.Persistence.Model.Constants;
using Umbraco.Framework.Security;

namespace Umbraco.Cms.Web.Security.Permissions
{
    [Permission(FixedPermissionIds.SendToTranslate, "Send to Translate", FixedPermissionTypes.EntityAction, UserType.User)]
    public class SendToTranslatePermission : Permission
    { }
}