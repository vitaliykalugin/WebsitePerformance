using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PerformanceSitemap> PerformanceSitemaps { get; set; }
        public DbSet<UriPerformance> UriPerformances { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
