using TaskDay8.Models;

namespace TaskDay8.Repository
{
    public interface ITraineeRepo
    {
        public List<Trainee> GetAll();
        public Trainee GetById(int id);

        public void Create(Trainee trainee, int[] Courses);
        public void Update(int id,Trainee trainee, int[] Courses);
        public List<Trainee> FilterByTrack(int id);
        public void DeleteById(int id);
    }
}
