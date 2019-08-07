using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Qks.Controllers
{
    public abstract class QksControllerBase: AbpController
    {
        protected QksControllerBase()
        {
            LocalizationSourceName = QksConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
