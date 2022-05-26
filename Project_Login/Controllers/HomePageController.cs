using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Login.Models;

namespace Project_Login.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult LibInfo()
        {
            loginFunc funcs2 = new loginFunc();
            List<Users> Librarians = new List<Users>();
            Librarians = funcs2.printLibrarian();
            return View("LibInfo", Librarians);
        }

        public ActionResult StuInfo()
        {
            SignUp funcs1 = new SignUp();
            List<Student> students = new List<Student>();
            students = funcs1.printStudents(); //a students list will be created to be printed
            return View("StuInfo", students);
        }
    }
}
