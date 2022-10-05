using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Lecturer:Person
    {
        private int yearExperience;
        private IExperienceStrategy experienceStrategy;
        
        public int YearExperience
        {
            get { return yearExperience; }
            set { yearExperience = value; }
        }
        public IExperienceStrategy ExperienceStrategy
        {
            get { return experienceStrategy; }
            set { experienceStrategy = value; }
        }
        public Lecturer() { }
        public Lecturer(IExperienceStrategy experienceStrategy)
        {
            ExperienceStrategy = experienceStrategy;
        }
        public Lecturer(string id, string name, int age, int yearExperience):base(id,name,age)
        {
            this.YearExperience = yearExperience;
        }

        public string GettingExperience()
        {
            return experienceStrategy.RattingExperience();
        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"ID: {base.Id}, Name: {base.Name}, Age: {base.Age}" +
                $", Year experience: {this.yearExperience}, Ratting: {this.GettingExperience()}");
        }
    }
}
