using TaskDay8.Models;

namespace TaskDay8.Repository
{
    public interface ICourseRepo
    {
        public List<Course> GetAll();
        public Course GetById(int id);

        public bool Create(Course course);
        public void Update(int id,Course course);

        public void DeleteById(int id);


    }
}
