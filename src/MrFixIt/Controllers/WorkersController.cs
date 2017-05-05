using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

namespace MrFixIt.Controllers
{
    public class WorkersController : Controller
    {
        private MrFixItContext db = new MrFixItContext();
        public IActionResult Index()
        {
            var thisWorker = db.Workers.Include(i =>i.Jobs).FirstOrDefault(i => i.UserName == User.Identity.Name);
            if (thisWorker != null)
            {
                return View(thisWorker);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        //right now, even if a worker object is already created by the signed-in user, they can access the create page by manually typing in the url. I've tried to create two workers singed into the same user account: creates multiple entries in db with same username, but the views still work. I'm assuming its because FIRSTordefault grabs the one that was created first. Still, this is a loophole that we should close.
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            //is this the only connection between the two tables? 
            //the two classes of user and worker are linked forever once made. unless we wanted to add functionality that allows user to disassociate two classes
            worker.UserName = User.Identity.Name;
            db.Workers.Add(worker); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
