using System;
using System.Collections;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public interface ISitemapHandler
    {
        Task<Sitemap> GetSitemapAsync(Uri baseUri);
    }
}
