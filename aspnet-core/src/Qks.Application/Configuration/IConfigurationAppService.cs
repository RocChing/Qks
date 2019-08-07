using System.Threading.Tasks;
using Qks.Configuration.Dto;

namespace Qks.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
