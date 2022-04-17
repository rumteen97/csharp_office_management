using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace office_DB
{

    public class Person {
        [Key] public int PersonID { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int Discriminator { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<OfficeAssignment> Offices { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; }
    }

    public class Department {
       [Key] public int DepartmentID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public virtual List<Course> Courses { get; set; }
    }

    public class OfficeAssignment {
        [Key] public int PersonID { get; set; }
        public string Location { get; set; }
        public virtual Person Person { get; set; }

    }

    public class Course {
       [Key] public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Enrollment> Enrollments { get; set; }
    }
    public class CourseInstructor
    {
        [Key] public int PersonID { get; set; }
        public int CourseID { get; set; }
        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }
    }
    public class Enrollment {
        [Key] public int EnrollmentID { get; set; }
        public int PersonID { get; set; }
        public int CourseID { get; set; }
        public int Grade { get; set; }
        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }
    }

    public class office_DB_context : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var DB = new office_DB_context()) { 
                Console.WriteLine("name: ");
                var fname = Console.ReadLine();
                Console.WriteLine("last name: ");
                var lname = Console.ReadLine();
                Console.WriteLine("hire date: ");
                var hdate = Console.ReadLine();
                Console.WriteLine("enrollment date: ");
                var edate = Console.ReadLine();

                var person = new Person
                {
                    Firstname = fname,
                    Lastname = lname, 
                    //string to date convertion needed for edat and hdate
                };
                DB.Persons.Add(person);
                DB.SaveChanges();
                //we can add other informations like the one above to our database
            }
            }
        }
    }

