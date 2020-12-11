using System.ComponentModel.DataAnnotations;

namespace Z01.Models.Data
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [StringLength(4000)]
        public string Comment { get; set; }
    }
    
}