using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OPServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger)
        {
            log = logger;
        }

        private ILogger log;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(int? id)
        {
            if(id.HasValue)
            {
                ViewData["Message"] = $"Your application description page. for ID {id.Value}";
            }
            else
            {
                ViewData["Message"] = "Your application description page.";
            }
            

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        
    }
}
