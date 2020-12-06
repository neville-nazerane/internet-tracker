using InternetTracker.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTracker.MobileApp.Services
{
    public class BerryClient
    {
        private readonly HttpClient _client;

        public BerryClient(HttpClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<FailedLog>> GetLogsAsync(
                                                        DateTime start,
                                                        DateTime end,
                                                        CancellationToken cancellationToken = default)
            
            => _client.GetFromJsonAsync<IEnumerable<FailedLog>>($"logs/start={start}&end={end}", cancellationToken);

    }
}
