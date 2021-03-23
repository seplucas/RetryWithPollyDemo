using Microsoft.Extensions.Hosting;
using RetryWithPolly.Configurations;
using System.Threading.Tasks;

namespace RetryWithPolly
{
    public class Program
    {
        async public static Task<int> Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
            return 0;
        }

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
  
                .ConfigureAppConfiguration((context, config) =>
                {
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddConfigureServices();
                });

    }
}
