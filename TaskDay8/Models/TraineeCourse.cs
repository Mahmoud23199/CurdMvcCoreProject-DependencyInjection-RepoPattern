using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay8.Models
{
    public class TraineeCourse
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
