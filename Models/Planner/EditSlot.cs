using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Z01.Models.Data;

namespace Z01.Models.Planner
{
    public class EditSlot
    {
        public ActivityModel EditedActivity { get; set; }
        
        public List<ActivityModel> Activities { get; set; }
        public int Slot { get; set; }
        
        public List<SelectListItem> Rooms { get; set; } = new List<SelectListItem>();
        
        public List<SelectListItem> Groups { get; set; } = new List<SelectListItem>();
        
        public List<SelectListItem> Subjects { get; set; } = new List<SelectListItem>();
        
        public List<SelectListItem> Teachers { get; set; } = new List<SelectListItem>();
        
        public Categories MainCategory { get; set; } 

        public EditSlot()
        {
            
        }
    }
}