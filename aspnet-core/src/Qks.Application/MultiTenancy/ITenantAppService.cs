using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Qks.MultiTenancy.Dto;

namespace Qks.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

