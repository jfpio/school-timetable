using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Z01.Models
{
    public class ActivityModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonIgnore] public string Key => $"{Slot}-{Room}";

        [JsonPropertyName("room")]
        [DisplayName("Sala")]
        public String Room { get; set; }

        [JsonPropertyName("group")]
        [DisplayName("Klasa")]
        public String Group { get; set; }

        [JsonPropertyName("subject")]
        [DisplayName("Przedmiot")]
        public String Subject { get; set; }

        [JsonPropertyName("slot")]
        [DisplayName("Pozycja")]
        public int Slot { get; set; }

        [JsonPropertyName("teacher")]
        [DisplayName("Nauczyciel")]
        public String Teacher { get; set; }

        
        public override string ToString() => $"{Id}-{Slot}-{Room}-{Subject}-{Group}-{Teacher}";
    }
}