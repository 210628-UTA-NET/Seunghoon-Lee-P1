using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seunghoon_Lee_P1.Models;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Repository<Product> data { get; set; }
        public HomeController(P1Context context) => data = new Repository<Product>(context);
 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var random = data.Get(new QueryOptions<Product>
            {
                OrderBy = p => Guid.NewGuid()
            });
            return View(random);
        }

        public ContentResult Register()
        {
            return Content("To do");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
