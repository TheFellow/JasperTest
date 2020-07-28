using Jasper;
using Jasper.Persistence.EntityFrameworkCore;
using Jasper.Persistence.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JasperTestService
{
    public class JasperConfig : JasperOptions
    {
        public override void Configure(IHostEnvironment hosting, IConfiguration config)
        {
            if (hosting.IsDevelopment())
            {
                Advanced.StorageProvisioning = StorageProvisioning.Rebuild;
            }

            var connectionString = config.GetConnectionString("sqlserver");

            Extensions.PersistMessagesWithSqlServer(connectionString);

            Extensions.UseEntityFrameworkCorePersistence();

            Services.AddDbContext<ItemsDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}