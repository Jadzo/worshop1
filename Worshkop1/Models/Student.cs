using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Worshkop1.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        [Required]
        public int nbOfCourses { get; set; }


    }
}