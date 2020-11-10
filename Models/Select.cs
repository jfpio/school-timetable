using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Z01.Models
{

    public class Select
    {
        public List<SelectListItem> GroupedOptions { get; } = new List<SelectListItem>();
        
        public Select(DataModel data)
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