using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public class UriPerformanceHandler : IUriPerformanceHandler
    {
        private const int ATTEMPTS = 5;

        private readonly IHttpClientFactory _clientFactory;

        public UriPerformanceHandler(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<UriPerformance> GetUriPerformanceAsync(Uri uri)
        {
            long[] timeArray = new long[ATTEMPTS];

            using (var client = _clientFactory.CreateClient())
            {
                Stopwatch stopwatch;

                for (int i = 0; i < ATTEMPTS; i++)
                {
                    using var request = new HttpRequestMessage(HttpMethod.Get, uri);

                    stopwatch = Stopwatch.StartNew();
                    await client.SendAsync(request);
                    timeArray[i] = stopwatch.ElapsedMilliseconds;
                }
            };

            timeArray = timeArray.OrderBy(t => t).ToArray();

            return new UriPerformance
            {
                Uri = uri,
                MinTime = timeArray.First(),
                MaxTime = timeArray.Last(),
                AverageTime = timeArray.Average()
            };
        }
    }
}
