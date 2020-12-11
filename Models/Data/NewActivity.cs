using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z01.Models.Data
{
    public class NewActivityModel
    {
        [Key]
        public string ActivityId { get; set; }
        
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
    }
}