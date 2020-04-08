using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelpingHand.Models;
using HelpingHand.ActionFilters;
using HelpingHand.Library.Models;

namespace HelpingHand.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly GeocodeService _geocodeService; //Shae added per powerpoint
        private readonly ILogger<HomeController> _logger;

        public HomeController(GeocodeService geocodeService, ILogger<HomeController> logger)
        {
            _geocodeService = geocodeService; //Shae added per powerpoint.
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
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
