using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public abstract class BaseSitemapHandler : ISitemapHandler
    {

        private readonly IHttpClientFactory _clientFactory;

        protected abstract string SitemapName { get; }

        public BaseSitemapHandler(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Sitemap> GetSitemapAsync(Uri baseUri)
        {
            var response = await GetResponseAsync(baseUri);

            if (response.IsSuccessStatusCode)
            {
                var uris = await ReadResponseAsync(response);

                return new Sitemap { BaseUri = baseUri, Uris = uris };
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        protected abstract Task<IEnumerable<Uri>> ReadResponseAsync(HttpResponseMessage response);

        private async Task<HttpResponseMessage> GetResponseAsync(Uri baseUri)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseUri, SitemapName));

            using var client = _clientFactory.CreateClient();

            return await client.SendAsync(request);
        }
    }
}
