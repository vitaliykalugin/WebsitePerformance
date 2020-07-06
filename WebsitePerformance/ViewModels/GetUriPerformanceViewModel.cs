using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebsitePerformance.ViewModels
{
    public class GetUriPerformanceViewModel
    {
        [Required]
        [Url]
        public string Uri { get; set; }
    }
}
