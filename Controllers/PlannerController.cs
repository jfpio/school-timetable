using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Z01.Data;
using Z01.Models;
using Z01.Models.Data;
using Z01.Models.Entities;
using Z01.Models.ViewModels.Planner;

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

            var activities = _context.Activities.ToList();
            
            return View(new PlannerModel(activities, availableOptions, selectedTimeTableConfig));
        }

        public IActionResult EditSlot(int? id, int slot, string key)
        {
            var selectedTimeTableConfig = new TimetableConfig() {Key = key};
            var editedActivity = _context.Activities.Find(id);
            
            var activitiesInSlot = _context.Activities.Where(a => a.SlotId == slot);
            
            var takenRooms = activitiesInSlot.Select(a => a.Room).ToList();
            var takenTeachers = activitiesInSlot.Select(a => a.Teacher).ToList();
            var takenSubjects = activitiesInSlot.Select(a => a.Subject).ToList();
            var takenClassGroups = activitiesInSlot.Select(a => a.ClassGroup).ToList();

            var availableOptions = new AvailableOptions
            {
                Rooms = _context.Rooms.Where(i => !takenRooms.Contains(i)).ToList(),
                Teachers = _context.Teachers.Where(i => !takenTeachers.Contains(i)).ToList(),
                Subjects = _context.Subjects.Where(i => !takenSubjects.Contains(i)).ToList(),
                ClassGroups = _context.ClassGroups.Where(i => !takenClassGroups.Contains(i)).ToList()
            };

            return View(new EditSlot(slot, selectedTimeTableConfig, availableOptions, editedActivity));
        }

        [HttpPost]
        public IActionResult EditSlot([Bind("ActivityId, SlotId, RoomId, SubjectId, ClassGroupId, TeacherId")]
            NewActivityModel editedActivity)
        {
            if (CheckIfNewActivityIsValid(editedActivity))
            {
                throw new Exception("Konflikt!");
            }
            if (editedActivity.ActivityId == 0)
            {
                _context.Activities.Add(new NewActivityModel
                {
                    ClassGroupId = editedActivity.ClassGroupId,
                    SubjectId = editedActivity.SubjectId,
                    RoomId = editedActivity.RoomId,
                    TeacherId = editedActivity.TeacherId,
                    SlotId = editedActivity.SlotId
                });
            }
            else
            {
                _context.Entry(editedActivity).State = EntityState.Modified;
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var activity = _context.Activities.Find(id);
            _context.Remove(activity);
            _context.SaveChanges();
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

        private bool CheckIfNewActivityIsValid(NewActivityModel activityModel)
        {
            var activitiesInSlot = _context.Activities
                .Where(a => a.SlotId == activityModel.SlotId)
                .Where(a => a.ActivityId != activityModel.ActivityId);

            return activitiesInSlot.Select(a => a.RoomId).Contains(activityModel.RoomId)
                   || activitiesInSlot.Select(a => a.SubjectId).Contains(activityModel.SubjectId)
                   || activitiesInSlot.Select(a => a.TeacherId).Contains(activityModel.TeacherId)
                   || activitiesInSlot.Select(a => a.ClassGroupId).Contains(activityModel.ClassGroupId);
        }
    }
}
