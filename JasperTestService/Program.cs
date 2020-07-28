using Jasper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace JasperTestService
{
    public class Program
    {
        public static Task<int> Main(string[] args) => CreateHostBuilder(args).RunJasper(args);

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .UseJasper<JasperConfig>()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            });
    }
}
