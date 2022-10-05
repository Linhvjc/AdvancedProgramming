using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class FailStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Fail";
        }
    }
}
