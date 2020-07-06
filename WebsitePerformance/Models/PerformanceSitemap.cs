using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsitePerformance.Models
{
    public class PerformanceSitemap : BaseSitemap
    {
        public IEnumerable<UriPerformance> UriPerformances { get; set; }
    }
}
