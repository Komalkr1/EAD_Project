using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Project_Login.Models
{
    public class loginFunc
    {
        public int checkCredentials(Users u) //to check credentials from database
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();        
            string query;
            if (u.LoginAs == "Student")
                query = $"SELECT * FROM Student WHERE Username=@u AND Password=@p";
            else
                query = $"SELECT * FROM Librarian WHERE Username=@u AND Password=@p";
            SqlParameter p1 = new SqlParameter("u", u.Username);
            SqlParameter p2 = new SqlParameter("p", u.Password);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return 1;
            }
            con.Close();
            return 2;
        }

        public List<Users> printLibrarian()//to print librarians
        {
            List<Users> librarians = new List<Users>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Librarian";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Users u = new Users();
                u.id = Convert.ToInt32(dr[0]);
                u.Username = Convert.ToString(dr[1]);
                u.PhoneNo = Convert.ToString(dr[3]);
                librarians.Add(u);
            }
            return librarians;
        }
    }

    public class SignUp
    {
        public int AddAcount(Student s)//to enroll students in database
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            //assigning the username to every new user based on its id AND first name
            string[] curUsername = s.Name.Split(' ');
            s.Username = curUsername[0] + findId();
            string query = $"INSERT INTO Student(Name, Username,Department,Semester_No,Phone_No,Password) " +
                $"VALUES('{s.Name}', '{s.Username}', '{s.Dept}', '{s.SemNo}', '{s.PhoneNo}','{s.Password}')";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                con.Close();
                return 1;
            }
            con.Close();
            return 2;
        }

        public int findId()//finding id for user
        {
            int id = 0;
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            int rand = (new Random()).Next(100, 1000);
            string query = $"SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);
                }
                return (id + 1);
            }
            else
                return rand;
        }

        public List<Student> printStudents()//print student info
        {
            List<Student> students = new List<Student>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Student";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Student s = new Student();
                s.id = Convert.ToInt32(dr[0]);
                s.Name = Convert.ToString(dr[1]);
                s.Username = Convert.ToString(dr[2]);
                s.Dept = Convert.ToString(dr[3]);
                s.SemNo = Convert.ToInt32(dr[4]);
                s.PhoneNo = Convert.ToString(dr[5]);
                students.Add(s);
            }
            return students;
        }
    }
}

