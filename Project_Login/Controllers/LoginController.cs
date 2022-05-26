using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_Login.Models;


namespace Project_Login.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ViewResult EntryInfo()
        {
            return View();
        }

        [HttpPost]
        public ViewResult EntryInfo(Users u) //login form info
        {
            if (ModelState.IsValid) //model validation
            {
                loginFunc funcs2 = new loginFunc();
                if (funcs2.checkCredentials(u) == 1) //if the entered credentials exists in database
                {
                    if (u.LoginAs == "Student") //if a student has logged in
                    {
                        return View("StuLoginSuccess");
                    }
                    else//if a librarian has logged in
                    {
                        return View("LibLoginSuccess");
                    }
                }
                else
                    return View("Error", u);//error page for user credentials that don't exist
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ViewResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ViewResult SignUp(Student s)
        {
            if (ModelState.IsValid) //model validation
            {
                SignUp funcs1 = new SignUp();
                if (funcs1.AddAcount(s) == 1)//entered info will be passed to be stored in database
                {
                    return View("StuLoginSuccess");
                }
                else
                {
                    return View();
                }
                    
            }
            else
            {
                return View();
            }
        }

        
    }
}
