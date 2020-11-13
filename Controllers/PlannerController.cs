using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Z01.Models;
using Z01.Models.Data;
using Z01.Models.Planner;

namespace Z01.Controllers
{
    public class PlannerController : Controller
    {
        private readonly ILogger<PlannerController> _logger;

        public PlannerController(ILogger<PlannerController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index([Bind("Key")] TimetableConfig selectedTimeTableConfig = null)
        {
            var dataModel = DataStorage.GetDataModel();
   
            return View(new PlannerModel(dataModel, selectedTimeTableConfig));
        }

        public IActionResult EditSlot(int? id, int slot)
        {
            var dataModel = DataStorage.GetDataModel();
            var editedActivity = dataModel.Activities.Find(activity => activity.Id == id);

            return View(new EditSlot(){EditedActivity = editedActivity, Slot = slot});
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
