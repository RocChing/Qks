namespace Qks
{
    public class QksConsts
    {
        public const string Qks = "Qks";
        public const string LocalizationSourceName = "Qks";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public const int DefaultOrderValue = 100;

        public const string QksApplication = "Qks.Application";
        public const string QksCore = "Qks.Core";
        public const string QksWebHost = "Qks.Web.Host";

        public class Field
        {
            public const int Len50 = 50;
            public const int Len100 = 100;
            public const int Len200 = 200;
        }

        public class Plugin
        {
            public const string Name = "Plugin";
            public const string AllDll = "*.dll";
            public const string Plugins = "Plugins";
            public const string QksPlugin = "Qks.Plugin";
            public const string Core = "Qks.Plugin.Core";
            public const string Application = "Qks.Plugin.Application";
            public const string EFCore = "Qks.Plugin.EFCore";

            public const string EFCoreInit = EFCore + ".QksPluginEFCoreInit";
            public const string EFCoreInitDbContext = "InitDbContext";
            public const string EFCoreRegisterAssembly = "RegisterAssembly";
        }
    }
}
