using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Z01.Models.Data
{
    public class NewActivityModel
    {
        [Key]
        public int ActivityId { get; set; }
        
        [ForeignKey("Slot")]
        public int SlotId { get; set; }
        public virtual Slot Slot { get; set; }
        
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        
        [ForeignKey("ClassGroup")]
        public int ClassGroupId { get; set; }
        public virtual ClassGroup ClassGroup { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

        
        public dynamic this[string propertyName]
        {
            get => GetType().GetProperty(propertyName)?.GetValue(this, null);
            set => GetType().GetProperty(propertyName)?.SetValue(this, value);
        }
        
        public string Key => $"{SlotId}-{Room}";
        
        public string ToLabel(Categories categories)
        {
            if (ActivityId == 0)
            {
                return " ";
            }
            var label = new StringBuilder();
            switch (categories)
            {
                case Categories.ClassGroup:
                    label.AppendJoin(" ", Room.Name, Subject.Name);
                    break;
                case Categories.Teacher:
                    label.AppendJoin(" ", Room.Name, Subject.Name, ClassGroup.Name);
                    break;
                case Categories.Room:
                    label.Append(ClassGroup.Name);
                    break;
            }

            return label.ToString();
        }
    }
}