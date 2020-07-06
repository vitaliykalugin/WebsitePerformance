using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebsitePerformance.Models;
using WebsitePerformance.Services;
using WebsitePerformance.ViewModels;

namespace WebsitePerformance.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPerformanceManager _handler;
        private readonly IPerformanceSitemapService _performanceSitemapService;

        public HomeController(
            IPerformanceManager handler,
            IPerformanceSitemapService performanceSitemapService)
        {
            _handler = handler;
            _performanceSitemapService = performanceSitemapService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            var sitemaps = _performanceSitemapService.GetAll();
            return View(sitemaps);
        }

        public IActionResult UriHistory(int id)
        {
            var sitemaps = _performanceSitemapService.GetById(id);
            return View("Performance", sitemaps);
        }

        [HttpPost]
        public async Task<IActionResult> Performance(GetUriPerformanceViewModel model)
        {
            if(ModelState.IsValid){
                var performance = await _handler.GetPerformanceAsync(new Uri(model.Uri));
                _performanceSitemapService.Create(performance);
                return View(performance);
            }

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
