using Microsoft.Extensions.DependencyInjection;
using RetryWithPolly.Extensions;
using RetryWithPolly.Services;
using RetryWithPolly.Services.Handlers;

namespace RetryWithPolly.Configurations
{
    public static class Bootstrapper
    {
        public static void AddConfigureServices(this IServiceCollection service)
        {
            service.AddHostedService<RetryWithPollyHostedService>()
                .AddHttpClient<IService, Service>()
                .AddPolicyHandler(PollyExtensions.WaitAndRetry());
        }


    }
}
