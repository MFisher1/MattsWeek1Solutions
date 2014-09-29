using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; }

        //constructor
        public Student(int studentID, string firstName, string lastName)
        {
            this.StudentID = studentID;
            this.FirstName = firstName;
            this.LastName = lastName;
            //remember to initialize course list
            this.Courses = new List<Course>();
        }
            //methods and function
            public void PrintInfo()
            {
                Console.WriteLine("{0} {1}", this.FirstName, this.LastName);
                Console.WriteLine("Student ID: {0}", this.StudentID);
                //Write out course and grade
                Console.WriteLine("Courses:");
                Console.Write(string.Join("/n",this.Courses.Select(x => x.GetCourseInfo())));
                
                //Write total gpa
                Console.WriteLine("GPA: ", this.Courses.Average(x => x.GradePoints));
            }
        }
    
}
