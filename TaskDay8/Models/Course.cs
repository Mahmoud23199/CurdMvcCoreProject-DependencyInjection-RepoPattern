using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay8.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Grade { get; set; }

        public virtual ICollection<TraineeCourse> ?Courses { get; set; }=new List<TraineeCourse>();
    }
}
