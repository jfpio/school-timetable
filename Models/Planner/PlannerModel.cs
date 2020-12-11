using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Z01.Models.Data;

namespace Z01.Models.Planner
{

    public class PlannerModel
    {
        public TimetableConfig SelectedTimetableConfig { get; set; }

        public List<SelectListItem> GroupedOptions { get; } = new List<SelectListItem>();
        public Timetable TableModel { get; private set; }


        public PlannerModel(
            List<NewActivityModel> activities,
            AvailableOptions availableOptions,
            TimetableConfig timetableConfig = null)
        {
            InitializeSelect(activities, availableOptions);
            if (timetableConfig != null) 
                InitializeTable(activities, timetableConfig);
        }

        private void InitializeTable(List<NewActivityModel> activities, TimetableConfig timetableConfig)
        {
            TableModel = new Timetable(activities, timetableConfig);
        }

        private void InitializeSelect(List<NewActivityModel> activities, AvailableOptions availableOptions)
        {
            var classGroup = new SelectListGroup {Name = "Klasy"};
            var teacherGroup = new SelectListGroup {Name = "Nauczyciele"};
            var roomGroup = new SelectListGroup {Name = "Sale"};

            foreach (var group in availableOptions.ClassGroups)
            {
                GroupedOptions.Add(
                    new SelectListItem
                    {
                        Value = $"ClassGroup-{group.Name}",
                        Text = group.Name,
                        Group = classGroup
                    });
            }

            foreach (var teacher in availableOptions.Teachers)
            {
                GroupedOptions.Add(
                    new SelectListItem
                    {
                        Value = $"Teacher-{teacher.Name}",
                        Text = teacher.Name,
                        Group = teacherGroup
                    });
            }

            foreach (var room in availableOptions.Rooms)
            {
                GroupedOptions.Add(
                    new SelectListItem
                    {
                        Value = $"Room-{room.Name}",
                        Text = room.Name,
                        Group = roomGroup
                    });
            }
        }
    }
}