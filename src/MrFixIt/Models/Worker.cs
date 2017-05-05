using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace MrFixIt.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Avaliable { get; set; }
        public string UserName { get; set; }
        //this comes from Identity.User. 
        //I don't understand how this happens, since the relationship between ApplicationUser and worker is not defined in MrFixItContext nor in the SSMS table schema

        //One-to-many relationship. One worker has many jobs.
        public virtual ICollection<Job> Jobs { get; set; }

        //workers are automatically available upon signing up
        public Worker()
        {
            Avaliable = true;
        }

    }
}