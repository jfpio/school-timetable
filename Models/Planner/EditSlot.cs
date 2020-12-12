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
        public NewActivityModel EditedActivity { get; set; }
        private string Key { get; }
        private Categories ImmutableCategoryOfEditedActivity { get; }

        public int Slot { get; set; }
        
        public List<SelectListItem> Rooms { get; }
        
        public List<SelectListItem> ClassGroups { get; }
        
        public List<SelectListItem> Subjects { get; }
        
        public List<SelectListItem> Teachers { get; }
        

        public EditSlot(int slot, TimetableConfig timetableConfig, AvailableOptions availableOptions, NewActivityModel editedActivity = null)
        {
            ImmutableCategoryOfEditedActivity = timetableConfig.Type;
            Key = timetableConfig.Key;
            EditedActivity = editedActivity;
            Slot = slot;

            Rooms = availableOptions.Rooms.Select(option => new SelectListItem {Value = option.Name, Text = option.Name,}).ToList();
            ClassGroups = availableOptions.ClassGroups.Select(option => new SelectListItem {Value = option.Name, Text = option.Name,}).ToList();
            Subjects = availableOptions.Subjects.Select(option => new SelectListItem {Value = option.Name, Text = option.Name,}).ToList();
            Teachers = availableOptions.Teachers.Select(option => new SelectListItem {Value = option.Name, Text = option.Name,}).ToList();

            if (editedActivity == null) return;
            
            switch (timetableConfig.Type)
            {
                case Categories.Room:
                    Rooms = CreateDisabledListOfOptions(editedActivity, "Room");
                    break;
                case Categories.ClassGroup:
                    ClassGroups = CreateDisabledListOfOptions(editedActivity, "ClassGroup");
                    break;
                case Categories.Teacher:
                    Teachers = CreateDisabledListOfOptions(editedActivity, "Teacher");
                    break;
                default: return;
            }

        }

        private static List<SelectListItem> CreateDisabledListOfOptions(NewActivityModel editedActivity, string property)
        {
            var newDisabledSelectItem = new SelectListItem() {Value = editedActivity[property].Name, Text = editedActivity[property].Name};
            return new List<SelectListItem> {newDisabledSelectItem};
        }
    }
}