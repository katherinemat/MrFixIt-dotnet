using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Claim(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisJob);
        }

        [HttpPost]
        public IActionResult ClaimConfirmed(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Worker = db.Workers.FirstOrDefault(workers => workers.UserName == User.Identity.Name);
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return Json(thisJob);
        }

        [HttpPost]
        public IActionResult Activate(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Worker = db.Workers.FirstOrDefault(workers => workers.UserName == User.Identity.Name);

            thisJob.Worker.Avaliable = false;
            thisJob.Pending = true;

            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return Json(thisJob);
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Worker = db.Workers.FirstOrDefault(workers => workers.UserName == User.Identity.Name);

            thisJob.Worker.Avaliable = true;
            thisJob.Pending = false;
            thisJob.Completed = true;

            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            return Json(thisJob);
        }
    }
}
