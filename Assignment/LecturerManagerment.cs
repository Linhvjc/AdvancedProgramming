using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class LecturerManagerment
    {
        private List<Lecturer> listOfLecturer = new List<Lecturer>();
        public List<Lecturer> ListOfLecturer
        {
            get { return listOfLecturer; }
            set { listOfLecturer = value; }
        }

        public void CreateLecturer()
        {
            Console.WriteLine();
            Console.WriteLine("Create new lecturer.");
            Console.WriteLine("Format: <ID>, <Name>, <Age>, <Year>. Example: 102, Phan Nhat Linh, 20, 3");
            Console.Write("New lecturer information: ");

            // Input info
            var info = Console.ReadLine();
            info = info.Trim();
            var infoArr = info.Split(",");
            infoArr = RemoveSpace(infoArr);

            // handle add student
            if (infoArr.Length == 4)
            {
                Lecturer lecturer = new
                    Lecturer(infoArr[0], infoArr[1], int.Parse(infoArr[2]), int.Parse(infoArr[3]));
                if (!checkIDExist(lecturer.Id))
                {
                    SettingRating(lecturer);
                    this.ListOfLecturer.Add(lecturer);
                    Console.WriteLine("Create lecturer successfully");
                }
                else
                {
                    Console.WriteLine("ID already exist!");
                }

            }
            else
            {
                Console.WriteLine("Wrong format!");
            }
        }

        // Remove space
        private string[] RemoveSpace(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim();
            }
            return arr;
        }

        // Check ID exist
        private bool checkIDExist(string id)
        {
            foreach (Lecturer lecturer in listOfLecturer)
            {
                if (lecturer.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        // Setting Rating
        private void SettingRating(Lecturer lecturer)
        {
            if (lecturer.YearExperience < 2) lecturer.ExperienceStrategy = new JuniorStrategy();
            else if (lecturer.YearExperience <4) lecturer.ExperienceStrategy = new MiddleStrategy();
            else if (lecturer.YearExperience > 6 ) lecturer.ExperienceStrategy = new SeniorStrategy();
        }

        public void UpdateLecturer()
        {
            Console.WriteLine();
            Console.WriteLine("Update lecturer");
            Console.Write("ID lecturer you want to update: ");
            string id = Console.ReadLine();
            if (checkIDExist(id))
            {
                Lecturer lecturer = GetLecturerById(id);
                // Input info
                Console.WriteLine();
                Console.WriteLine("Format: <Name>, <Age>, <Year>. Example: Phan Nhat Linh, 20, 6");
                Console.Write("Student information: ");
                var info = Console.ReadLine();
                info = info.Trim();
                var infoArr = info.Split(",");
                infoArr = RemoveSpace(infoArr);
                if (infoArr.Length == 3)
                {
                    //Student student = new
                    //    Student(infoArr[0], infoArr[1], int.Parse(infoArr[2]), double.Parse(infoArr[3]));
                    lecturer.Name = infoArr[0];
                    lecturer.Age = int.Parse(infoArr[1]);
                    lecturer.YearExperience = int.Parse(infoArr[2]);
                    SettingRating(lecturer);
                    Console.WriteLine("Update successfully");
                }
                else
                {
                    Console.WriteLine("Wrong format!");
                }
            }
            else
            {
                Console.WriteLine("Student ID does not exist");
            }
        }

        // Get lecturer by ID
        private Lecturer GetLecturerById(string id)
        {
            foreach (Lecturer lecturer in this.ListOfLecturer)
            {
                if (lecturer.Id == id) return lecturer;
            }
            return new Lecturer();
        }

        // Delete lecturer
        public void DeleteLecturer()
        {
            Console.WriteLine();
            Console.WriteLine("Delete lecturer");
            Console.Write("ID lecturer you want to delete: ");
            string id = Console.ReadLine();
            if (checkIDExist(id))
            {
                this.listOfLecturer.Remove(GetLecturerById(id));
                Console.WriteLine("Delete lecturer successfully");
            }
            else
            {
                Console.WriteLine("Lecturer ID does not exist");
            }
        }

        private string GetChoice()
        {
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" &&
                choice != "3" && choice != "4" && choice != "5" &&
                choice != "6" && choice != "Exit" && choice != "exit")
            {
                Console.Write("Please input from 1 to 6: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        // Search lecturer
        public void SearchLecturer()
        {
            Console.WriteLine();
            Console.WriteLine("Search lecturer");
            Console.WriteLine("1. Search by ID");
            Console.WriteLine("2. Search by Name");
            Console.Write("Your choice: ");
            string choice = GetChoice();
            if (choice == "1")
            {
                Console.Write("ID lecturer you want to find: ");
                string id = Console.ReadLine();
                if (checkIDExist(id))
                {
                    Lecturer lecturer = GetLecturerById(id);
                    Console.WriteLine("Result:");
                    Console.WriteLine($"ID: {lecturer.Id}, Name: {lecturer.Name}, Age: {lecturer.Age}" +
                        $", Year: {lecturer.YearExperience}, Rating: {lecturer.GettingExperience()}");
                }
                else
                {
                    Console.WriteLine("Lecturer ID does not exist");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Lecturer's name you want to find: ");
                string name = Console.ReadLine();
                if (checkNameExist(name))
                {
                    Console.WriteLine("Result:");
                    foreach (Lecturer lecturer in GetLecturerByName(name))
                    {
                        Console.WriteLine($"ID: {lecturer.Id}, Name: {lecturer.Name}, Age: {lecturer.Age}" +
                            $", Year: {lecturer.YearExperience}, Rating: {lecturer.GettingExperience()}");
                    }
                }
                else
                {
                    Console.WriteLine("Lecturer Name does not exist");
                }

            }
        }

        // Check Name exist
        private bool checkNameExist(string name)
        {
            foreach (Lecturer lecturer in ListOfLecturer)
            {
                if (lecturer.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        // Get student by name
        private List<Lecturer> GetLecturerByName(string name)
        {
            List<Lecturer> newList = new List<Lecturer>();
            foreach (Lecturer lecturer in this.listOfLecturer)
            {
                if (lecturer.Name == name) newList.Add(lecturer);
            }
            return newList;
        }

        // filter lecturer
        public void FilterLecturer()
        {
            Console.WriteLine();
            Console.WriteLine("Filter Lecturer");
            Console.WriteLine("1. Filter by year experience");
            Console.WriteLine("2. Filter by rating");
            Console.Write("Your choice: ");
            string choice = GetChoice();
            if (choice == "1")
            {
                Console.Write("Lecturer's year experience you want to filter: ");
                int year = int.Parse(Console.ReadLine());
                FilterByYear(year);

            }
            else if (choice == "2")
            {
                Console.Write("Lecturer's rating you want to filter: ");
                string rate = Console.ReadLine();
                FilterByRating(rate);
            }
        }

        // Filter by Year
        public void FilterByYear(int year)
        {
            List<Lecturer> newList = new List<Lecturer>();
            foreach (Lecturer lecturer in this.listOfLecturer)
            {
                if (lecturer.YearExperience == year) newList.Add(lecturer);
            }
            if (newList.Count > 0)
            {
                foreach (Lecturer lecturer in newList)
                {
                    Console.WriteLine($"ID: {lecturer.Id}, Name: {lecturer.Name}, Age: {lecturer.Age}" +
                            $", Grade: {lecturer.YearExperience}, Rating: {lecturer.GettingExperience()}");
                }
            }
            else
            {
                Console.WriteLine("No records to display");
            }
        }

        // Filter By Rating
        public void FilterByRating(string rate)
        {
            List<Lecturer> newList = new List<Lecturer>();
            foreach (Lecturer lecturer in this.listOfLecturer)
            {
                if (lecturer.GettingExperience() == rate) newList.Add(lecturer);
            }
            if (newList.Count > 0)
            {
                foreach (Lecturer lecturer in newList)
                {
                    Console.WriteLine($"ID: {lecturer.Id}, Name: {lecturer.Name}, Age: {lecturer.Age}" +
                            $", Grade: {lecturer.YearExperience}, Rating: {lecturer.GettingExperience()}");
                }
            }
            else
            {
                Console.WriteLine("No records to display");
            }
        }

        // Sort lecturer
        public void SortLecturer()
        {
            List<Lecturer> newList = new List<Lecturer>();
            foreach (Lecturer lecturer in this.ListOfLecturer)
            {
                newList.Add(lecturer);
            }
            Console.WriteLine();
            Console.WriteLine("Sort Lecturer");
            Console.WriteLine("1. Sort by name");
            Console.WriteLine("2. Sort by year experience");
            Console.Write("Your choice: ");
            string choice = GetChoice();
            if (choice == "1")
            {
                newList.Sort((x, y) =>
                {
                    int ret = String.Compare(x.Name, y.Name);
                    return ret;
                });
                Console.WriteLine("\tID \t\tName \t\t\t\tAge \t\tGrade \t\tRating");
                Console.WriteLine("");
                // loop student in list and display
                foreach (Lecturer lecturer in newList)
                {
                    lecturer.DisplayInformation();
                }

            }
            else if (choice == "2")
            {
                newList = newList.OrderBy(x => x.YearExperience).ToList();
                Console.WriteLine("\tID \t\tName \t\t\t\tAge \t\tYear Experience \t\tRating");
                Console.WriteLine("");
                // loop student in list and display
                foreach (Lecturer lecturer in newList)
                {
                    lecturer.DisplayInformation();
                }
            }
        }
    }
}
