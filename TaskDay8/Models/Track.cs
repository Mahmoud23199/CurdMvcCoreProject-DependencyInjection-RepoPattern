using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay8.Models
{
    [Table("Track")]
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Trainee>? Trainees { get; set;}=new List<Trainee>();
    }
}
