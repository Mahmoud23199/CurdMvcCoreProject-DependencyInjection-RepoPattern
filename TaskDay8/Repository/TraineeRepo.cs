using Microsoft.EntityFrameworkCore;
using TaskDay8.Models;

namespace TaskDay8.Repository
{
    public class TraineeRepo:ITraineeRepo
    {
        public readonly AppDbContext context;
        public TraineeRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Trainee trainee, int[] Courses)
        {
            context.Trainees.Add(trainee);
            context.SaveChanges();

            for (int i = 0; i < Courses.Length; i++)
            {
                context.TraineeCourses.Add(new TraineeCourse() { TraineeId = trainee.Id, CourseId = Courses[i] });
                context.SaveChanges();

            }
        }

        public void DeleteById(int id)
        {
            var currTrainee=context.Trainees.Include(c=>c.Courses).FirstOrDefault(t => t.Id == id);
            if (currTrainee != null)
            {
                context.Remove(currTrainee);
                context.SaveChanges() ;
            }
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees.Include(t => t.Track).Include(sc => sc.Courses).ThenInclude(sc => sc.Course).ToList();
        }

        public Trainee GetById(int id)
        {
            var currTrainee = context.Trainees.Include(t => t.Track).Include(sc => sc.Courses).ThenInclude(sc => sc.Course).FirstOrDefault(i => i.Id == id);

            if (currTrainee != null)
            {
                return currTrainee;
            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public void Update(int id, Trainee trainee, int[] Courses)
        {
            var currTrainee = context.Trainees.FirstOrDefault(i => i.Id == id);
            if (currTrainee != null)
            {
                currTrainee.Name = trainee.Name;
                currTrainee.Email= trainee.Email;
                currTrainee.Birthdate= trainee.Birthdate;
                currTrainee.Courses= trainee.Courses;
                currTrainee.Gender= trainee.Gender;
                currTrainee.Phone= trainee.Phone;
                currTrainee.TrackId= trainee.TrackId;
                // context.SaveChanges();

                for (int i = 0; i < Courses.Length; i++)
                {
                    context.TraineeCourses.Update(new TraineeCourse() { TraineeId = trainee.Id, CourseId = Courses[i] });

                }
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public List<Trainee> FilterByTrack(int id)
        {
            var data = context.Trainees
                               .Include(t => t.Track)
                               .Include(sc => sc.Courses)
                               .ThenInclude(sc => sc.Course)
                               .Where(i => i.TrackId == id)
                               .ToList();

            return data;
           
        }

    }
}
