using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Qks.Plugin.Core;

namespace Qks.Plugin.Application
{
    public interface IMyUserAppService : IApplicationService
    {
        Task<UserDto> GetUser(int id);

        Task<UserDto> InsertOrUpdate(UserDto model);
    }
}
