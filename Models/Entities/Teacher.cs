using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z01.Models.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Comment { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Timestamp { get; set; }

    }
}