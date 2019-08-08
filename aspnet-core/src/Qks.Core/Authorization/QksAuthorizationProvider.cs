using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Qks.Authorization
{
    public class QksAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var userPermission = context.CreatePermission(PermissionNames.Admin_Users, L("Users"));
            userPermission.CreateChildPermission(PermissionNames.Admin_Users_Create, L("Create"));
            userPermission.CreateChildPermission(PermissionNames.Admin_Users_Delete, L("Delete"));
            userPermission.CreateChildPermission(PermissionNames.Admin_Users_Edit, L("Edit"));

            context.CreatePermission(PermissionNames.Admin_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Admin_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, QksConsts.LocalizationSourceName);
        }
    }
}
