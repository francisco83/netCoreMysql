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
    public class DatosSensoresController : Controller
    {
        private readonly ILogger<DatosSensoresController> _logger;

        public DatosSensoresController(ILogger<DatosSensoresController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //return View();
            SensoresContext context = HttpContext.RequestServices.GetService(typeof(coreNetMysql.Models.SensoresContext)) as SensoresContext;

            return View(context.GetAll());
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