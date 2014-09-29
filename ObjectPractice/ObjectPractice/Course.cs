using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Course
    {
        public string Name { get; set; }
        public int GradePoints { get; set; }

        //Declare a custom property for letter grade
        private string _letterGrade;

        public string LetterGrade
        {
            get { return _letterGrade; }
            set 
            {
                _letterGrade = _letterGrade.ToUpper(); 
                //letter grade was set update the grade points
                if (_letterGrade == "A")
                {
                    this.GradePoints = 4;
                }
                else if (_letterGrade == "B")
                {
                    this.GradePoints = 3;
                }
                else if (_letterGrade == "C")
                {
                    this.GradePoints = 2;
                }
                else if (_letterGrade == "D")
                {
                    this.GradePoints = 1;
                }
                else
                {
                    this.GradePoints = 0;
                }
            }
        }

            //Constructors
            public Course(string name, string grade)
            {
                //set the name of course
                this.Name = name;
                //set letter grade
                this.LetterGrade = _letterGrade;
            }

            //Methods
            public string GetCourseInfo()
            {
                return this.Name + " " + this.LetterGrade + " " + this.GradePoints;
            }
        }
        
    }

