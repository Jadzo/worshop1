using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Worshkop1.Models;

namespace Worshkop1.Controllers
{
    public class StudentController : ApiController
    {
        static List<Student> students = new List<Student> {

        new Student{id = 1, firstName = "Jad",lastName = "Kaddour",nbOfCourses=2,phoneNumber = 76715089,},
        new Student{id = 2, firstName = "George",lastName = "Ters",nbOfCourses=2,phoneNumber = 76715089,}
        };

        // GET: api/Student
        public IHttpActionResult Get([FromUri]string firstName = "")
        {
            List<Student> returnStudent = students.FindAll(s => s.firstName.Contains(firstName));   
            if(returnStudent.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "No user with this name was found");
            }
            return Content(HttpStatusCode.OK, returnStudent);
        }

        // GET: api/Student/5
        public IHttpActionResult Get(int id)
        {
            Student student = students.Find(s => s.id == id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "User not found");
            }
            return Content(HttpStatusCode.OK, student);
        }

        // POST: api/Student
        public IHttpActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "All fields are required!!");
            }
            students.Add(student);
            return Content(HttpStatusCode.Created, "Student was created successfully!");
        }

        // PUT: api/Student/5
        public IHttpActionResult Put(int id, [FromBody]Student student)
        {

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "All fields are required");
            }
            bool found = false;
            Student updatedStudent = new Student();
            students.ForEach(s => {
            if (s.id == id)
                {
                    s.firstName = student.firstName; 
                    s.lastName = student.lastName;
                    s.phoneNumber = student.phoneNumber;
                    s.nbOfCourses = student.nbOfCourses;
                    updatedStudent = s;
                    found = true;
                }
            });
            if (!found)
            {
                return Content(HttpStatusCode.NotFound, "User does not exist");
            }
            return Content(HttpStatusCode.OK, updatedStudent);
        }

        // DELETE: api/Student/5
        public IHttpActionResult Delete(int id)
        {
            Student student = students.Find(s => s.id == id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, "User does not exist!");
            }
            students.Remove(student);   
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
