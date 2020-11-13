using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Z01.Models.Data
{
    public class DataModel
    {
        [JsonPropertyName("rooms")]
        public List<string> Rooms { get; set; }

        [JsonPropertyName("groups")]
        public List<string> Groups { get; set; }

        [JsonPropertyName("subjects")]
        public List<string> Subjects { get; set; }

        [JsonPropertyName("teachers")]
        public List<string> Teachers { get; set; }

        [JsonPropertyName("activities")]
        public List<ActivityModel> Activities { get; set; }

        public void AddActivity(ActivityModel activity)
        {
            // TODO Validation
            Activities.Add(activity);
        }
        
        public void DeleteActivity(int id)
        {
            Activities.RemoveAll(activity => activity.Id == id);
        }
        
        // public bool CheckForConflicts(ActivityModel activity)
        // {
        //     var activitiesInSlot = Activities.Where(helperActivity => helperActivity.Slot == activity.Slot);
        //     return CheckForConflictForOption("Room", activitiesInSlot, activity);
        // }
        //
        // private static bool CheckForConflictForOption(string propertyName, List<ActivityModel> activitiesInSlot, ActivityModel editedActivity)
        // {
        //     var optionsTakenInSlot = activitiesInSlot.Select(activity => activity[propertyName]).ToList().Distinct();
        //     var selectListItem = allOptions.Except(optionsTakenInSlot).Select(option => new SelectListItem {Value = option, Text = option,}).ToList();
        //
        //     if (editedActivity != null)
        //     {
        //         selectListItem.Add(new SelectListItem {Value = editedActivity[propertyName], Text = editedActivity[propertyName]});
        //     }
        //
        //     return selectListItem;
        // }
    }
}