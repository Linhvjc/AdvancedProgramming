using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class SeniorStrategy : IExperienceStrategy
    {
        public string RattingExperience()
        {
            return "Senior";
        }
    }
}
