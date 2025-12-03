using BelajarDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelajarDotNet.Controllers
{
    [Route("Home")]
    public class RoutingController : Controller
    {
        //[Route("")]
        //[Route("/")]
        //[Route("Index")]
        public string StartPage()
        {
            return "HomeController StartPage() multiple routing try this route /Student/3/Details ";
        }

        [Route("    Details/{id=10}")]
        public string Details(int id)
        {
            return "Details() Action Method of HomeController, ID Value = " + id;
        }
        [HttpGet("~/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        static List<StudentR> students = new List<StudentR>()
        {
            new StudentR() { Id = 1, Name = "Berka" },
            new StudentR() { Id = 2, Name = "Egy" },
            new StudentR() { Id = 3, Name = "Fauzi" },
            new StudentR() { Id = 4, Name = "Sigit" }
        };

        //This method is going to return all the Students
        [Route("Student/All")]
        public List<StudentR> GetAllStudents()
        {
            return students;
        }

        //This method is going to return a student based on the student id
        [Route("Student/{studentID}/Details")]
        public StudentR GetStudentByID(int studentID)
        {
            //Returning the First Student Information
            StudentR? studentDetails = students.FirstOrDefault(s => s.Id == studentID);
            return studentDetails ?? new StudentR();
        }

        //This method is going to return the courses of a student based on the student id
        [Route("Student/{studentID}/Courses")]
        public List<string> GetStudentCourses(int studentID)
        {
            //Real-Time you will get the courses from database, here we have hardcoded the data
            List<string> CourseList = new List<string>();
            if (studentID == 1)
                CourseList = new List<string>() { "ASP.NET Core", "C#.NET", "SQL Server" };
            else if (studentID == 2)
                CourseList = new List<string>() { "ASP.NET Core MVC", "C#.NET", "ADO.NET Core" };
            else if (studentID == 3)
                CourseList = new List<string>() { "ASP.NET Core WEB API", "C#.NET", "Entity Framework Core" };
            else
                CourseList = new List<string>() { "Bootstrap", "jQuery", "AngularJs" };

            return CourseList;
        }
    }
}
