using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Conventions_One_to_One
{
    public class Student
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public int studentAge { get; set; }
        
        public virtual Address studentAddress { get; set; }

        public IList<Course> Courses { get; set; }
    }

    public class Address
    {
        public int addressId { get; set; }
        public string studentAddress { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public int studentId { get; set; }
        public virtual Student student { get; set; }
    }

    public class Course
    {
        public int courseId { get; set; }
        public string courseName { get; set; }
        public string courseDescription { get; set; }

        public IList<Student> Students { get; set; }
    }

    /*public class StudentCourse
    {
        public int studentId { get; set; }
        public Student student { get; set; }

        public int courseId { get; set; }
        public Course course { get; set; }
    }*/

    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }

        //public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SchoolDB2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasQueryFilter(c => c.studentAge >= 25);
        }

        /*public SchoolContext() : base("name=SchoolContext")
        {
            //this.OnConfiguring
            this.Configuration.LazyLoadingEnabled = false;
        }*/
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var std1 = new Student()
                {
                    studentName = "Wamik",
                    studentAge = 23
                };

                var std2 = new Student()
                {
                    studentName = "Ihtisham",
                    studentAge = 20
                };

                var std3 = new Student()
                {
                    studentName = "afaq",
                    studentAge = 29
                };

                var std4 = new Student()
                {
                    studentName = "Askari",
                    studentAge = 25
                };

                var std5 = new Student()
                {
                    studentName = "Umair",
                    studentAge = 21
                };

                var atd1 = new Address()
                {
                    studentAddress = "House # 68-B canal",
                    city = "Lahore",
                    country = "Pakistan",
                    studentId = 36
                };

                var atd2 = new Address()
                {
                    studentAddress = "House # 69",
                    city = "Islamabad",
                    country = "Capital City",
                    studentId = 37
                };

                var atd3 = new Address()
                {
                    studentAddress = "House # 894",
                    city = "Sydney",
                    country = "Australia",
                    studentId = 38
                };

                var atd4 = new Address()
                {
                    studentAddress = "House # 4569",
                    city = "Tabuk",
                    country = "Saudi Arabia",
                    studentId = 39
                };

                var atd5 = new Address()
                {
                    studentAddress = "House # 7845",
                    city = "California",
                    country = "USA",
                    studentId = 40
                };

                var ctd1 = new Course()
                {
                    courseName = "ICT",
                    courseDescription = "Good course"
                };

                var ctd2 = new Course()
                {
                    courseName = "PF",
                    courseDescription = "Not so Good course"
                };

                var ctd3 = new Course()
                {
                    courseName = ".NET",
                    courseDescription = "Very Good course"
                };

                var ctd4 = new Course()
                {
                    courseName = "DS",
                    courseDescription = "Very Bad course"
                };

                /*context.Students.Add(std1);
                context.Students.Add(std2);
                context.Students.Add(std3);
                context.Students.Add(std4);
                context.Students.Add(std5);*/

                /*context.Addresses.Add(atd1);
                context.Addresses.Add(atd2);
                context.Addresses.Add(atd3);
                context.Addresses.Add(atd4);
                context.Addresses.Add(atd5);*/

                /*context.Courses.Add(ctd1);
                context.Courses.Add(ctd2);
                context.Courses.Add(ctd3);
                context.Courses.Add(ctd4);*/

                context.SaveChanges();

                //Global filter 

                var students1 = context.Students;

                Console.WriteLine("--------------------------Without Ignore query--------------------------");
                foreach (var s in students1)
                    Console.WriteLine(s.studentName);

                var students2 = context.Students.IgnoreQueryFilters();

                Console.WriteLine("--------------------------Without Ignore query--------------------------");
                foreach (var s in students2)
                    Console.WriteLine(s.studentName);

                /*//Eager Loading
                Console.WriteLine("--------------------------Eager Loading--------------------------");

                var stud1 = context.Students.Include(s=> s.studentAddress);

                foreach (var s in stud1)
                {
                    Console.WriteLine(s.studentName + " " + s.studentAddress.studentAddress);
                }*/

                //Lazy Loading
                Console.WriteLine("--------------------------Lazy Loading--------------------------");

                //context.Configuration.LazyLoadingEnabled = false;

                var stud1 = context.Addresses;


                foreach (var s in stud1)
                {
                    Console.WriteLine(s.studentAddress);
                    
                    Console.WriteLine(s.student.studentName);
                   
                }
            }
        }
    }
}
