using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Net.Http;

namespace RetryWithPolly.Extensions
{
    public static class PollyExtensions
    {
        public static AsyncPolicy<HttpResponseMessage> WaitAndRetry()
        {
            var retry = Policy.HandleResult<HttpResponseMessage>(e => e.StatusCode != System.Net.HttpStatusCode.OK)
                .WaitAndRetryAsync(new[]
                {
                TimeSpan.FromSeconds(3), 
                TimeSpan.FromSeconds(5), 
                TimeSpan.FromSeconds(10)
                });

            var circuit = Policy.HandleResult<HttpResponseMessage>(e => e.StatusCode != System.Net.HttpStatusCode.OK)
                .CircuitBreakerAsync(1, TimeSpan.FromSeconds(30));

            return circuit.WrapAsync(retry);
        }

    }
}
