using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsitePerformance.Models
{
    public class Sitemap : BaseSitemap
    {
        public IEnumerable<Uri> Uris { get; set; }
    }
}
