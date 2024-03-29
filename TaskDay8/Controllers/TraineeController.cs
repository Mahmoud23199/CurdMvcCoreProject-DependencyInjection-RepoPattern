using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDay8.Models;
using TaskDay8.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TaskDay8.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepo traineeRepo;
        AppDbContext context;
        private ITrackRepo trackRepo;

        public TraineeController(ITraineeRepo traineeRepo, AppDbContext dbContext,ITrackRepo trackRepo)
        {
            this.traineeRepo = traineeRepo;
            this.context = dbContext;
            this.trackRepo=trackRepo;

        }

        // GET: TraineeController
        public ActionResult Index()
        {
            ViewBag.SearchCourse = new SelectList(trackRepo.GetAll(), "Id", "Name");

            return View(traineeRepo.GetAll());
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            ViewBag.SearchCourse = new SelectList(trackRepo.GetAll(), "Id", "Name",id);

            var data = traineeRepo.FilterByTrack(id);
            return View(data);
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {

            return View(traineeRepo.GetById(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {
            ViewBag.CourseId= context.Courses.ToList();

            ViewBag.TrackId = new SelectList(context.tracks.ToList(), "Id", "Name");

            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee trainee,int [] Courses)
        {
            ViewBag.CourseId = context.Courses.ToList();

            ViewBag.TrackId = new SelectList(context.tracks.ToList(), "Id", "Name");
            try
            {
                if(ModelState.IsValid) 
                {
                    traineeRepo.Create(trainee, Courses);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(trainee);
                }
            }
            catch
            {
                return View(trainee);
            }
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SelectedCourseIds=context.TraineeCourses.Where(i=>i.TraineeId==id).Select(i=>i.CourseId).ToList();
            ViewBag.CourseId = context.Courses.ToList();

            ViewBag.TrackId = new SelectList(context.tracks.ToList(), "Id", "Name",id);

            return View(traineeRepo.GetById(id));

        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Trainee trainee, int[] Courses)
        {
            ViewBag.SelectedCourseIds = context.TraineeCourses.Where(i => i.TraineeId == id).Select(i => i.CourseId).ToList();
            ViewBag.CourseId = context.Courses.ToList();
            ViewBag.TrackId = new SelectList(context.tracks.ToList(), "Id", "Name", id);

            try
            {
                if (ModelState.IsValid)
                {
                    var oldSelectCours = context.TraineeCourses.Where(i => i.TraineeId == id).ToList();
                    if(oldSelectCours != null)
                    {
                        for(int i = 0; i < oldSelectCours.Count; i++) 
                        {
                            context.TraineeCourses.Remove(oldSelectCours[i]);
                        }
                    }

                    traineeRepo.Update(id, trainee, Courses);
                    return RedirectToAction(nameof(Index));
                }
                else { return View(trainee); }
            }
            catch
            {
                return View(trainee);
            }
        }

        // GET: TraineeController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.SelectedCourseIds = context.TraineeCourses.Where(i => i.TraineeId == id).Select(i => i.CourseId).ToList();
            ViewBag.CourseId = context.Courses.ToList();

            ViewBag.TrackId = new SelectList(context.tracks.ToList(), "Id", "Name", id);

            return View(traineeRepo.GetById(id));
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Trainee trainee)
        {
            try
            {
                traineeRepo.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
