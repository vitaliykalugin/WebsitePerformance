using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Data
{
    public interface IPerformanceSitemapRepository
    {
        void Create(PerformanceSitemap performanceSitemap);
        
        IEnumerable<PerformanceSitemap> GetAll();

        PerformanceSitemap GetById(int id);
    }
}
