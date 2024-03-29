using TaskDay8.Models;

namespace TaskDay8.Repository
{
    public class CourseRepo : ICourseRepo
    {
        public readonly AppDbContext context;
        public CourseRepo(AppDbContext context)
        {
            this.context = context; 
        }
        public bool Create(Course course)
        {

            if (course != null)
            {
                try
                {
                    context.Courses.Add(course);
                    context.SaveChanges();
                    return true;
                }catch (Exception ex) 
                {
                    throw new Exception("An error occurred while creating the course", ex);
                }

            }else { return false; }


        }
        public void DeleteById(int id)
        {
           var course = context.Courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public List<Course> GetAll()
        {
            var currCourse=context.Courses.ToList();
            return currCourse;
        }

        public Course GetById(int id)
        {
            var course = context.Courses.FirstOrDefault(c => c.Id == id);

            if(course != null)
            {
                return course;
            }
            else
            {
                throw new InvalidOperationException($"Course with ID {id} not found.");
            }

        }
        public void Update(int id,Course course)
        {
            var courr = context.Courses.FirstOrDefault(c => c.Id == id);
            if (courr != null)
            {
                courr.Name=course.Name;
                courr.Grade = course.Grade;

                context.Courses.Update(courr);
                context.SaveChanges();
            }
        }
    }
}
