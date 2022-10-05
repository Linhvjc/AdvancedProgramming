using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class MeritStrategy : IGradeStrategy
    {
        public string RattingGrade()
        {
            return "Merit";
        }
    }
}
