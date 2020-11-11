using System;
using System.Collections.Generic;


namespace Z01.Models
{
    public enum TimetableType
    {
        None,
        Group,
        Teacher,
        Room
    }
    public class TimetableConfig
    {
        public TimetableType Type { get; set; }
        public string Value { get; set; }

        public string Key
        {
            get => ToString();
            set
            {
                var elements = value.Split('-', 2, StringSplitOptions.RemoveEmptyEntries);
                Type = Enum.TryParse(elements[0], out TimetableType type) ? type : TimetableType.None;
                Value = elements[1] ?? "";
            }
        }

        public override string ToString()
        {
            return $"{Type}-{Value}";
        }
    }
}