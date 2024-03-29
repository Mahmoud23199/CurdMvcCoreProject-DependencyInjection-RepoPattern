using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDay8.Models;
using TaskDay8.Repository;

namespace TaskDay8.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo courseRepo;
        public CourseController(ICourseRepo courseRepo)
        {
            this.courseRepo = courseRepo;   
        }
        // GET: CourseController
        public ActionResult Index()
        {
            return View(courseRepo.GetAll());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View(courseRepo.GetById(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                
                  courseRepo.Create(course);
                  return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(course);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(courseRepo.GetById(id));
            
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Course course )
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    courseRepo.Update(id, course);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(course);
                }
               
            }
            catch
            {
                return View(course);
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(courseRepo.GetById(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                courseRepo.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
