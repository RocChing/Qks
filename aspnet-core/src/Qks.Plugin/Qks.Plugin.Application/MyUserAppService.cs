using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Qks.Plugin.Core;
using Abp.Domain.Repositories;
using Abp.Authorization;
using Qks.Authorization;
using Qks.Authorization.Users;

namespace Qks.Plugin.Application
{
    [AbpAuthorize(PermissionNames.Admin_Users)]
    public class MyUserAppService : QksPluginAppServiceBase, IMyUserAppService
    {
        private readonly IRepository<UserEntity> _userRep;
        public MyUserAppService(IRepository<UserEntity> userRep)
        {
            _userRep = userRep;
        }

        public async Task<UserDto> GetUser(int id)
        {
            UserEntity user = await _userRep.GetAsync(id);
            return ObjectMapper.Map<UserDto>(user);
        }

        public async Task<UserDto> InsertOrUpdate(UserDto model)
        {
            var user = ObjectMapper.Map<UserEntity>(model);

            model.Id = await _userRep.InsertOrUpdateAndGetIdAsync(user);

            return model;
        }

        public virtual async Task<User> GetCurrentUser()
        {
            return await base.GetCurrentUserAsync();
        }
    }
}
