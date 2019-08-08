using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Qks.Web.Views
{
    public abstract class QksRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected QksRazorPage()
        {
            LocalizationSourceName = QksConsts.LocalizationSourceName;
        }
    }
}
