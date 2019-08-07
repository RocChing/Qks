using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Qks.Configuration.Dto;

namespace Qks.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : QksAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
