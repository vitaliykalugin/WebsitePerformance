using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Models;

namespace WebsitePerformance.Services
{
    public interface IUriPerformanceHandler
    {
        Task<UriPerformance> GetUriPerformanceAsync(Uri uri);
    }
}
