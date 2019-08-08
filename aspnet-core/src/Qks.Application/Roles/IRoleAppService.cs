using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qks.Roles.Dto;

namespace Qks.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<ListResultDto<FlatPermissionWithLevelDto>> GetAllPermissions2();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}
