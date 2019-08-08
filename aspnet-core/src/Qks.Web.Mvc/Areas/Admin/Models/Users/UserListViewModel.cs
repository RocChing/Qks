using System.Collections.Generic;
using Qks.Roles.Dto;
using Qks.Users.Dto;

namespace Qks.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
