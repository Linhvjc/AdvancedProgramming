using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class MiddleStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Middle";
        }
    }
}
