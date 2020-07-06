using System.Collections.Generic;
using System.Linq;
using WebsitePerformance.Data;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public class PerformanceSitemapService : IPerformanceSitemapService
    {
        private readonly IPerformanceSitemapRepository _repository;

        public PerformanceSitemapService(IPerformanceSitemapRepository repository)
        {
            _repository = repository;
        }

        public void Create(PerformanceSitemap performanceSitemap)
        {
            _repository.Create(performanceSitemap);
        }

        public IEnumerable<PerformanceSitemap> GetAll()
        {
            return _repository.GetAll();
        }

        public PerformanceSitemap GetById(int id)
        {
            var performanceSitemap = _repository.GetById(id);
            performanceSitemap.UriPerformances = performanceSitemap.UriPerformances.OrderByDescending(p => p.AverageTime).ToList();

            return performanceSitemap;
        }
    }
}
