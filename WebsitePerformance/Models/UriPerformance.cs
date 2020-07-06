using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsitePerformance.Models
{
    public class UriPerformance
    {
        public int Id { get; set; }

        public Uri Uri { get; set; }

        public long MaxTime { get; set; }

        public long MinTime { get; set; }
        
        public double AverageTime { get; set; }
    }
}
