using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Data
{
    public class PerformanceSitemapRepository : IPerformanceSitemapRepository
    {
        private readonly ApplicationContext _context;

        public PerformanceSitemapRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(PerformanceSitemap performanceSitemap)
        {
            _context.PerformanceSitemaps.Add(performanceSitemap);
            _context.SaveChanges();
        }

        public IEnumerable<PerformanceSitemap> GetAll()
        {
            return _context.PerformanceSitemaps.ToList();
        }

        public PerformanceSitemap GetById(int id)
        {
            return _context.PerformanceSitemaps
                .Where(sitemap => sitemap.Id == id)
                .Include(sitemap => sitemap.UriPerformances)
                .FirstOrDefault();
        }
    }
}
