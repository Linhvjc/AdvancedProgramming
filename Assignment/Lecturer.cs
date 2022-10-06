﻿using System;
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
            Console.WriteLine($"\t{base.Id} \t\t{base.Name} \t\t\t{base.Age} " +
                $"\t\t{this.yearExperience} \t\t\t\t{this.GettingExperience()}");
        }

        public override void DisplayInfoWhenSearchOrFilter()
        {
            Console.WriteLine($"ID: {this.Id}, Name: {this.Name}, Age: {this.Age}" +
                                $", Year: {this.YearExperience}, Rating: {this.GettingExperience()}");
        }
    }
}
