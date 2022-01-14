using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstates.Services;
using RealEstates.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstates.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistrictService districtService;

        public HomeController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }

        public IActionResult Index()
        {
            var districts = this.districtService.GetTopDistrictsByAveragePrice(50);
            return View(districts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
