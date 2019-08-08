using Abp.AspNetCore.Mvc.ViewComponents;

namespace Qks.Web.Views
{
    public abstract class QksViewComponent : AbpViewComponent
    {
        protected QksViewComponent()
        {
            LocalizationSourceName = QksConsts.LocalizationSourceName;
        }
    }
}
