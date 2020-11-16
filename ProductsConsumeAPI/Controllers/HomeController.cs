using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsConsumeAPI.Models;
using ProductsConsumeAPI.Services;

namespace ProductsConsumeAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductAPIService _service;

        public HomeController(ILogger<HomeController> logger, IProductAPIService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {

            var product = _service.GetProduct(2).GetAwaiter().GetResult();

            return View(product);
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
