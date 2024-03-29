using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskDay8.Models;
using TaskDay8.Repository;

namespace TaskDay8.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackRepo trackRepo;
        public TrackController(ITrackRepo tRepo)
        {
            this.trackRepo = tRepo;
        }
        // GET: TrackController
        public ActionResult Index()
        {
            return View(trackRepo.GetAll());
        }

        // GET: TrackController/Details/5
        public ActionResult Details(int id)
        {
            return View(trackRepo.GetById(id));
        }

        // GET: TrackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Track track)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trackRepo.Create(track);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(track);
            }
        }

        // GET: TrackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(trackRepo.GetById(id));
        }

        // POST: TrackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Track track)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                 trackRepo.Update(id, track);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(track);
            }
        }

        // GET: TrackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(trackRepo.GetById(id));
        }

        // POST: TrackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                trackRepo.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
