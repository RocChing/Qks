using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Qks.Configuration;
using Qks.Web;

namespace Qks.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class QksDbContextFactory : IDesignTimeDbContextFactory<QksDbContext>
    {
        public QksDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<QksDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            QksDbContextConfigurer.Configure(builder, configuration.GetConnectionString(QksConsts.ConnectionStringName));

            return new QksDbContext(builder.Options);
        }
    }
}
