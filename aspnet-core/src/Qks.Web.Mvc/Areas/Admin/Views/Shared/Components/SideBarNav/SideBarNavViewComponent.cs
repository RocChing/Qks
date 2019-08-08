using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Navigation;
using Abp.Runtime.Session;

namespace Qks.Web.Views.Shared.Components.SideBarNav
{
    public class SideBarNavViewComponent : QksViewComponent
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IAbpSession _abpSession;

        public SideBarNavViewComponent(
            IUserNavigationManager userNavigationManager,
            IAbpSession abpSession)
        {
            _userNavigationManager = userNavigationManager;
            _abpSession = abpSession;
        }

        public async Task<IViewComponentResult> InvokeAsync(string activeMenu = "")
        {
            var model = new SideBarNavViewModel
            {
                MainMenu = await _userNavigationManager.GetMenuAsync(QksConsts.AdminMenuName, _abpSession.ToUserIdentifier()),
                ActiveMenuItemName = activeMenu
            };

            return View(model);
        }
    }
}
