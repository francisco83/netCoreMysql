using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using coreNetMysql.Models;

namespace coreNetMysql.Controllers
{
    public class MongoController : Controller
    {
        private readonly ILogger<MongoController> _logger;

        public MongoController(ILogger<MongoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //return View();
            MongoContext context2 = HttpContext.RequestServices.GetService(typeof(coreNetMysql.Models.MongoContext)) as MongoContext;

            return View(context2.GetAll());
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