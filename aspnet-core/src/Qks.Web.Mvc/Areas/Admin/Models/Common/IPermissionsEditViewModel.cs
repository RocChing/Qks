using System.Collections.Generic;
using Qks.Roles.Dto;

namespace Qks.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}