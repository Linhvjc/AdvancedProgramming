using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Student:Person
    {
        private double grade;
        private IGradeStrategy gradeStrategy;

        public double Grade
        {
            get { return grade; }
            set { 
                if( value <0 || value > 10) throw new ArithmeticException("Grade must be from 0 to 10");
                grade = value; 
            }
        }

        public IGradeStrategy GradeStrategy
        {
            get { return gradeStrategy; }
            set { gradeStrategy = value; }
        }

        public Student() { }
        public Student(IGradeStrategy gradeStrategy)
        {
            GradeStrategy = gradeStrategy;
        }
        public Student(string id, string name, int age, double grade):base(id,name,age)
        {
            Grade = grade;
        }

        public string GettingGrade()
        {
            return gradeStrategy.RatingGrade();
        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"\t{base.Id} \t\t{base.Name} \t\t\t{base.Age} \t\t{this.Grade} \t\t{this.GettingGrade()}");
        }

        public override void DisplayInfoWhenSearchOrFilter()
        {
            Console.WriteLine($"ID: {this.Id}, Name: {this.Name}, Age: {this.Age}" +
                                $", Grade: {this.Grade}, Rating: {this.GettingGrade()}");
        }
    }
}
