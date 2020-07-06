using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public class PerformanceManager : IPerformanceManager
    {
        private readonly ISitemapHandler _sitemapHandler;
        
        private readonly IUriPerformanceHandler _uriPerformanceHandler;

        public PerformanceManager(
            ISitemapHandler sitemapHandler,
            IUriPerformanceHandler uriPerformanceHandler)
        {
            _sitemapHandler = sitemapHandler;
            _uriPerformanceHandler = uriPerformanceHandler;
        }

        public async Task<PerformanceSitemap> GetPerformanceAsync(Uri baseUri)
        {
            try
            {
                var sitemap = await _sitemapHandler.GetSitemapAsync(baseUri);

                List<UriPerformance> uriPerformances = new List<UriPerformance>();

                foreach (var uri in sitemap.Uris)
                {
                    uriPerformances.Add(await _uriPerformanceHandler.GetUriPerformanceAsync(uri));
                }

                uriPerformances = uriPerformances.OrderByDescending(p => p.AverageTime).ToList();

                return new PerformanceSitemap
                {
                    BaseUri = baseUri,
                    UriPerformances = uriPerformances
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
