using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Project_Login.Models
{
    public class Users
    {
        public string LoginAs { get; set; }
        [Required(ErrorMessage = "*Must enter a value")] //making sure username field is required
        public string Username { get; set; }
        [StringLength(8)]//length of password is 8
        [RegularExpression("([0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Enter data in required format")]  //pattern for password is only digits     
        [Required(ErrorMessage = "*Must enter a value")]        
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public int id { get; set; }
    }

    public class Student
    {
        public int id { get; set; }
        public string Username { get; set; }
        [Required(ErrorMessage = "*Must enter a value")]
        public string Name { get; set; }
        public string Dept { get; set; }
        public int SemNo { get; set; }
        [StringLength(12)]//length of password is 8
        [RegularExpression("([0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Enter data in required format")]
        [Required(ErrorMessage = "*Must enter a value")]
        public string PhoneNo { get; set; }
        [StringLength(8)]//length of password is 8
        [RegularExpression("([0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Enter data in required format")]
        [Required(ErrorMessage = "Must enter a value")]
        public string Password { get; set; }
        [StringLength(8)]//length of password is 8
        [RegularExpression("([0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Enter data in required format")]
        [Compare("Password", ErrorMessage = "Doesn't match your entered password")]
        [Required(ErrorMessage = "*Must enter a value")]
        public string ConfirmPassword { get; set; }
    }   
}
