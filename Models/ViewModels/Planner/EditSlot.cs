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

            Rooms = availableOptions.Rooms.Select(option => new SelectListItem {Value = $"{option.RoomId}", Text = option.Name,}).ToList();
            ClassGroups = availableOptions.ClassGroups.Select(option => new SelectListItem {Value = $"{option.ClassGroupId}", Text = option.Name,}).ToList();
            Subjects = availableOptions.Subjects.Select(option => new SelectListItem {Value = $"{option.SubjectId}", Text = option.Name,}).ToList();
            Teachers = availableOptions.Teachers.Select(option => new SelectListItem {Value = $"{option.TeacherId}", Text = option.Name,}).ToList();

            if (editedActivity == null)
            {
                EditedActivity = new NewActivityModel {SlotId = slot, ActivityId = 0};
                return;
            }
            
            switch (timetableConfig.Type)
            {
                case Categories.Room:
                    Rooms = new List<SelectListItem>
                        {new SelectListItem {Value = $"{editedActivity.RoomId}", Text = editedActivity.Room.Name}};
                    break;
                case Categories.ClassGroup:
                    ClassGroups = new List<SelectListItem>
                    {
                        new SelectListItem
                            {Value = $"{editedActivity.ClassGroupId}", Text = editedActivity.ClassGroup.Name}
                    };
                    break;
                case Categories.Teacher:
                    Teachers = new List<SelectListItem>
                    {
                        new SelectListItem
                            {Value = $"{editedActivity.TeacherId}", Text = editedActivity.Teacher.Name}
                    };
                    break;
                default: return;
            }

        }
    }
}