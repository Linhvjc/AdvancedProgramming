using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class PassStrategy : IGradeStrategy
    {
        public string RatingGrade()
        {
            return "Pass";
        }
    }
}
