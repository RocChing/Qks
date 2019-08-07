using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Qks.Configuration;

namespace Qks.EntityFrameworkCore
{
    public class MyConnectionStringResolver : DefaultConnectionStringResolver
    {
        private readonly IConfigurationRoot _root;
        private readonly IHostingEnvironment _env;
        public MyConnectionStringResolver(IAbpStartupConfiguration configuration, IHostingEnvironment hostingEnvironment)
            : base(configuration)
        {
            _env = hostingEnvironment;
            _root = AppConfigurations.Get(_env.ContentRootPath, _env.EnvironmentName, _env.IsDevelopment());
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            var connectStringName = GetConnectionStringName(args);
            if (connectStringName != null)
            {
                return _root.GetConnectionString(connectStringName);
            }
            return base.GetNameOrConnectionString(args);
        }

        private string GetConnectionStringName(ConnectionStringResolveArgs args)
        {
            //var type = args["DbContextConcreteType"] as Type;
            //if (type == typeof(MASTERDATADbContext))
            //{
            //    return DxpConsts.MDConnectionString;//返回数据库二的节点名称
            //}
            return null;//采用默认数据库
        }
    }
}
