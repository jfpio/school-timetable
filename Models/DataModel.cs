using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Z01.Models
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
    }
}