using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Zero.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qks.EntityFrameworkCore
{
    public class MyDbPerTenantConnectionStringResolver : DbPerTenantConnectionStringResolver
    {
        public MyDbPerTenantConnectionStringResolver(
           IAbpStartupConfiguration configuration,
           ICurrentUnitOfWorkProvider currentUnitOfWorkProvider,
           ITenantCache tenantCache)
           : base(configuration, currentUnitOfWorkProvider, tenantCache)
        {
            //_currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            //_tenantCache = tenantCache;

            //AbpSession = NullAbpSession.Instance;
        }

        public override string GetNameOrConnectionString(DbPerTenantConnectionStringResolveArgs args)
        {
            return base.GetNameOrConnectionString(args);
        }
    }
}
