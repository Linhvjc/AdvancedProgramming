using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            set {
                if (value < 6 || value > 100) throw 
                        new ArgumentOutOfRangeException(nameof(Age), "Age must be from 6 to 100");
                age = value; 
            }
        }

        public Person() { }
        public Person(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public virtual void DisplayInformation(){}
        public virtual void DisplayInfoWhenSearchOrFilter(){}
        public virtual void AddRowTable(ConsoleTable table){}
    }
}
