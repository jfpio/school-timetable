using System.ComponentModel.DataAnnotations;

namespace Z01.Models.Data
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        
    }
}