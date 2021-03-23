using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetryWithPolly.Services
{
    public class Service : IService
    {
        private readonly HttpClient _client;
        private readonly ILogger<Service> _logger;

        public Service(HttpClient client, ILogger<Service> logger)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://random.dog");
            _logger = logger;
        }

        public async Task CallApi()
        {
            try
            {
                _logger.LogInformation("Tentativa de chamada");
                var result = await _client.GetAsync("/wo.json");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

        }
    }
}
