using Abp.Application.Navigation;
using Abp.Localization;
using Qks.Authorization;

namespace Qks.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class QksNavigationProvider : NavigationProvider
    {
        public const string MenuName = QksConsts.AdminMenuName;
        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));
            menu
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "Admin",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Admin/Tenants",
                        icon: "business",
                        requiredPermissionName: PermissionNames.Admin_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Admin/Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Admin_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Admin/Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Admin_Roles
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Admin/About",
                        icon: "info"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, QksConsts.LocalizationSourceName);
        }
    }
}
