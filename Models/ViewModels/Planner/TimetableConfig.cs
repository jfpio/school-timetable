using System;
using Z01.Models.Data;

namespace Z01.Models.ViewModels.Planner
{
    public class TimetableConfig
    {
        public Categories Type { get; set; }
        public string Value { get; set; }

        public string Key
        {
            get => ToString();
            set
            {
                var elements = value.Split('-', 2, StringSplitOptions.RemoveEmptyEntries);
                Type = Enum.TryParse(elements[0], out Categories type) ? type : Categories.None;
                Value = elements[1] ?? "";
            }
        }

        public override string ToString()
        {
            return $"{Type}-{Value}";
        }
    }
}