using System;
using Z01;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Z01.Models.Data;

namespace Z01.Models.Planner
{
    public class EditSlot
    {
        public ActivityModel EditedActivity { get; set; }
        public string Key { get; }
        public Categories ImmutableCategoryOfEditedActivity { get; }

        public int Slot { get; set; }
        
        public List<SelectListItem> Rooms { get; }
        
        public List<SelectListItem> Groups { get; }
        
        public List<SelectListItem> Subjects { get; }
        
        public List<SelectListItem> Teachers { get; }
        

        public EditSlot(int slot, TimetableConfig timetableConfig, ActivityModel editedActivity = null)
        {
            ImmutableCategoryOfEditedActivity = timetableConfig.Type;
            Key = timetableConfig.Key;
            EditedActivity = editedActivity;
            Slot = slot;
            var data = DataStorage.GetDataModel();
            var activitiesInSlot = data.Activities.Where(activity => activity.Slot == Slot).ToList();

            Rooms = GetAvailableOptions(data.Rooms, "Room", activitiesInSlot, editedActivity);
            Groups = GetAvailableOptions(data.Groups, "Group", activitiesInSlot, editedActivity);
            Subjects = GetAvailableOptions(data.Subjects, "Subject", activitiesInSlot, editedActivity);
            Teachers = GetAvailableOptions(data.Teachers, "Teacher", activitiesInSlot, editedActivity);

            if (editedActivity == null) return;
            switch (timetableConfig.Type)
            {
                case Categories.Room:
                    Rooms = CreateDisabledListOfOptions(editedActivity, "Room");
                    break;
                case Categories.ClassGroup:
                    Groups = CreateDisabledListOfOptions(editedActivity, "Group");
                    break;
                case Categories.Teacher:
                    Teachers = CreateDisabledListOfOptions(editedActivity, "Teacher");
                    break;
                default: return;
            }

        }
        
        private static List<SelectListItem> GetAvailableOptions(IEnumerable<string> allOptions, string propertyName, List<ActivityModel> activitiesInSlot, ActivityModel editedActivity)
        {
            var optionsTakenInSlot = activitiesInSlot.Select(activity => activity[propertyName]).ToList().Distinct();
            var selectListItem = allOptions.Except(optionsTakenInSlot).Select(option => new SelectListItem {Value = option, Text = option,}).ToList();

            if (editedActivity != null)
            {
                selectListItem.Add(new SelectListItem {Value = editedActivity[propertyName], Text = editedActivity[propertyName]});
            }

            return selectListItem;
        }

        private static List<SelectListItem> CreateDisabledListOfOptions(ActivityModel editedActivity, string property)
        {
            var newDisabledSelectItem = new SelectListItem() {Value = editedActivity[property], Text = editedActivity[property]};
            return new List<SelectListItem> {newDisabledSelectItem};
        }
    }
}