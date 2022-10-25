
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Program
    {
        static void Main(string[] args)
        {
            var table = new ConsoleTable("one", "two", "three");
            table.AddRow(1, 2, 3)
                 .AddRow("this line should be longerwwwwwwwwwwwwwwwwwwwww", "yes it is", "oh");
            Console.WriteLine(table.ToString());
        }
    }

    interface IGradeStrategy
    {
        string RatingGrade();
    }
    class FailStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Fail";
        }
    }
    internal class PassStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Pass";
        }
    }
    class MeritStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Merit";
        }
    }
    class DistinctionStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Distinction";
        }
    }
    class Student
    {
        public double Grade { get; set; }
        public IGradeStrategy GradeStrategy { get; set; }
        public string GettingGrade()
        {
            if (Grade < 5) GradeStrategy = new FailStrategy();
            else if (Grade <= 7) GradeStrategy = new PassStrategy();
            else if (Grade <= 8.5) GradeStrategy = new MeritStrategy();
            else if (Grade <= 10) GradeStrategy = new DistinctionStrategy();
            return GradeStrategy.RatingGrade();
        }
    }


}