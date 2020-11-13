using System;
using System.Collections.Generic;
using System.Linq;
using Z01.Models.Data;


namespace Z01.Models.Planner
{
    public class Timetable
    { 
        public TimetableConfig TimetableConfig { get; }

        public static readonly List<string> ColumnLabels = new List<string>() {"Czas", "Pon", "Wt", "Śr", "Cz", "Pt"};

        private static readonly Dictionary<int, string> TableRowLabels = new Dictionary<int, string>()
        {
            {0, "8:00-8:45"},
            {1, "8:55-9:40"},
            {2, "9:50-11.35"},
            {3, "11:55-12:40"},
            {4, "12:50-13:35"},
            {5, "13:45-14.30"},
            {6, "14:40-15:25"},
            {7, "15:35-16:20"},
            {8, "16:30-17:15"}
        };

        public Dictionary<string, Dictionary<string, ActivityModel>> Records;

        public Timetable(List<ActivityModel> activities, TimetableConfig timetableConfig)
        {
            TimetableConfig = timetableConfig;
            Records = ParseActivitiesToRecords(activities, timetableConfig);
        }

        private static Dictionary<string, Dictionary<string, ActivityModel>> ParseActivitiesToRecords(
                List<ActivityModel> activities,
                TimetableConfig timetableConfig
            )
        {
            if (timetableConfig.Type == Categories.None)
                return new Dictionary<string, Dictionary<string, ActivityModel>>();

            var categoryName = timetableConfig.Type.ToString();

            var slots = Enumerable
                .Range(1, 48)
                .Select(slot =>
                activities.FirstOrDefault(
                    activity => 
                        activity[categoryName].Equals(timetableConfig.Value) && activity.Slot == slot
                        ) ?? new ActivityModel() {Slot = slot}
            );

            return TableRowLabels.ToDictionary(
                label => label.Value,
                label => slots.Skip(5 * label.Key).Take(5)
                    .ToDictionary(obj => obj.Key, obj => obj)
            );
        }
    }
}