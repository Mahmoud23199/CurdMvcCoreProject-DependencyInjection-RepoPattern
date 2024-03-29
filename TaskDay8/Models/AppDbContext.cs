using Microsoft.EntityFrameworkCore;

namespace TaskDay8.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Track> tracks { get; set; }
        public DbSet<TraineeCourse> TraineeCourses { get; set; }


    }
}
