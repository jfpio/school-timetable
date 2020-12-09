using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z01.Models.Data
{
    public class NewActivityModel
    {
        [Key]
        public string ActivityId { get; set; }
        
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}