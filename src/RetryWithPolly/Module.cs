using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RetryWithPolly
{
    [DependsOn(
    typeof(AbpAutofacModule)
)]
    public class Module : AbpModule
    {
        public override void ConfigureServices(this IServiceCollection service)
        {
            service.AddHostedService<RetryWithPollyHostedService>();
            service.AddHttpClient<IService, Service>()
                .AddPolicyHandler(PollyExtensions.WaitAndRetry()).AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(15)));
        }
    }
}
