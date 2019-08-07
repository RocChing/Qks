using System.Threading.Tasks;
using Abp.Application.Services;
using Qks.Sessions.Dto;

namespace Qks.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
