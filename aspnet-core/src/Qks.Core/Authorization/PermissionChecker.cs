using Abp.Authorization;
using Qks.Authorization.Roles;
using Qks.Authorization.Users;

namespace Qks.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
