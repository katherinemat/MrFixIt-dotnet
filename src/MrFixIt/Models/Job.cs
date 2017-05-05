using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool Pending { get; set; }
        public virtual Worker Worker { get; set; }

        public Job(string _title, string _description)
        {
            Title = _title;
            Description = _description;
            Completed = false;
            Pending = false;
        }

        public Job()
        {

        }

        //since starting the .net unit, we haven't been storing methods in the class.cs document. This method could go into the controller upon refactoring?
        public Worker FindWorker(string UserName)
        {
            Worker thisWorker = new MrFixItContext().Workers.FirstOrDefault(i => i.UserName == UserName);
            return thisWorker;
        }
    }
}
