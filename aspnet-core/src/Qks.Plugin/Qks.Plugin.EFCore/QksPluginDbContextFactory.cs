using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Qks.Configuration;
using Qks.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qks.Plugin.EFCore
{
    public class QksPluginDbContextFactory : IDesignTimeDbContextFactory<QksPluginDbContext>
    {
        public QksPluginDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QksPluginDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            //可以在这里切换数据库
            QksPluginDbContextConfigurer.Configure(builder, configuration.GetConnectionString(QksConsts.ConnectionStringName));

            return new QksPluginDbContext(builder.Options);
        }
    }
}
