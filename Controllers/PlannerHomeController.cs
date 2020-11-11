using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Z01.Models;

namespace Z01.Controllers
{
    public class PlannerHomeController : Controller
    {
        private readonly ILogger<PlannerHomeController> _logger;

        public PlannerHomeController(ILogger<PlannerHomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index([Bind("Key")] TimetableConfig selected = null)
        {
            var dataModel = DataStorage.GetDataModel();
   
            return View(new PlannerModel(dataModel, selected));
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
