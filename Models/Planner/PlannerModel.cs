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


        public PlannerModel(DataModel data, TimetableConfig timetableConfig = null)
        {
            InitializeSelect(data);
            if (timetableConfig != null) 
                InitializeTable(data, timetableConfig);
        }

        private void InitializeTable(DataModel data, TimetableConfig timetableConfig)
        {
            TableModel = new Timetable(data.Activities, timetableConfig);
        }

        private void InitializeSelect(DataModel data)
        {
            var classGroup = new SelectListGroup {Name = "Klasy"};
            var teacherGroup = new SelectListGroup {Name = "Nauczyciele"};
            var roomGroup = new SelectListGroup {Name = "Sale"};

            foreach (var group in data.Groups)
            {
                GroupedOptions.Add(
                    new SelectListItem
                    {
                        Value = $"Group-{group}",
                        Text = group,
                        Group = classGroup
                    });
            }

            foreach (var teacher in data.Teachers)
            {
                GroupedOptions.Add(
                    new SelectListItem
                    {
                        Value = $"Teacher-{teacher}",
                        Text = teacher,
                        Group = teacherGroup
                    });
            }

            foreach (var room in data.Rooms)
            {
                GroupedOptions.Add(
                    new SelectListItem
                    {
                        Value = $"Room-{room}",
                        Text = room,
                        Group = roomGroup
                    });
            }
        }
    }
}