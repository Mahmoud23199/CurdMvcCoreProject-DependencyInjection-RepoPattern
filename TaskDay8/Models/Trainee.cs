using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDay8.Models
{
    [Table("Trainee")]
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MustBeString(ErrorMessage = "The field must be a string.")]
        public string Name { get; set; }

        [EnumDataType(typeof (Gender))]
        public Gender Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format"), Required]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber),RegularExpression("^(010|011|012)\\d{8}$",ErrorMessage = " phone number must be 11 digits start with 010,011 or 012")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }
        public virtual Track? Track { get; set; }

        public virtual ICollection<TraineeCourse>? Courses { get; set; } = new List<TraineeCourse>();


    }

    public enum Gender
    {
        Male =1 
        ,Female
    }
}
