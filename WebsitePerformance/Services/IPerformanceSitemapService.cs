using System.Collections.Generic;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public interface IPerformanceSitemapService
    {
        void Create(PerformanceSitemap performanceSitemap);

        IEnumerable<PerformanceSitemap> GetAll();

        PerformanceSitemap GetById(int id);
    }
}
