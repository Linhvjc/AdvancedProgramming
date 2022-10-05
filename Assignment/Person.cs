using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Person
    {
        private string id;
        private string name;
        private int age;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person() { }
        public Person(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public virtual void DisplayInformation()
        {
            
        }
    }
}
