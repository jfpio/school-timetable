using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Z01.Data;
using Z01.Models;
using Z01.Models.Data;
using Z01.Models.Planner;

namespace Z01.Controllers
{
    public class PlannerController : Controller
    {
        private readonly PlannerContext _context;

        public PlannerController(PlannerContext context)
        {
            _context = context;
        }

        public IActionResult Index([Bind("Key")] TimetableConfig selectedTimeTableConfig = null)
        {
            var availableOptions = new AvailableOptions
            {
                ClassGroups = _context.ClassGroups.ToList(),
                Rooms = _context.Rooms.ToList(),
                Subjects = _context.Subjects.ToList(),
                Teachers = _context.Teachers.ToList()
            };
            var slots = _context.Slots.ToList();

            var activities = _context.Activities.ToList();
            
            return View(new PlannerModel(activities, availableOptions, selectedTimeTableConfig));
        }

        public IActionResult EditSlot(int? id, int slot, string key)
        {
            
            var selectedTimeTableConfig = new TimetableConfig() {Key = key};
            var dataModel = DataStorage.GetDataModel();
            var editedActivity = dataModel.Activities.Find(activity => activity.Id == id);

            return View(new EditSlot(slot, selectedTimeTableConfig, editedActivity));
        }

        [HttpPost]
        public IActionResult EditSlot([Bind("Id, Slot, Room, Subject, Group, Teacher")]
            ActivityModel editedActivity)
        {
            var data = DataStorage.GetDataModel();
            
            if (editedActivity.Id != 0)
            {
                data.DeleteActivity(editedActivity.Id);
            }
            
            // TODO Error handling
            
            data.AddActivity(editedActivity);
            
            DataStorage.SaveDataModel(data);
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var data = DataStorage.GetDataModel();
            data.DeleteActivity(id);
            DataStorage.SaveDataModel(data);
            return RedirectToAction(nameof(Index));
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
