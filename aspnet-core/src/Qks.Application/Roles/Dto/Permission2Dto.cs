using Abp.Authorization;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qks.Roles.Dto
{
    [AutoMapFrom(typeof(Permission))]
    public class Permission2Dto : PermissionDto
    {
        public IReadOnlyList<Permission2Dto> Children { get; set; }
    }
}
