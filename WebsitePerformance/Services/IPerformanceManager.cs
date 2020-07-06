using System;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public interface IPerformanceManager
    {
        Task<PerformanceSitemap> GetPerformanceAsync(Uri baseUri);
    }
}
