using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class StudentManagement
    {
        private List<Student> listOfStudent = new List<Student>();
        public List<Student> ListOfStudent
        {
            get { return listOfStudent; }
            set { listOfStudent = value; }
        }

        // Check ID exist
        private bool checkIDExist(string id)
        {
            foreach (Student student in listOfStudent)
            {
                if(student.Id == id)
                {
                    return true;
                }
            } 
            return false;
        }

        // Check Name exist
        private bool checkNameExist(string name)
        {
            foreach (Student student in listOfStudent)
            {
                if (student.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        // Setting Ratting
        private void SettingRatting(Student student)
        {
            if (student.Grade < 5) student.GradeStrategy = new FailStrategy();
            else if (student.Grade >= 5 && student.Grade <= 7) student.GradeStrategy = new PassStrategy();
            else if (student.Grade > 7 && student.Grade <= 8.5) student.GradeStrategy = new MeritStrategy();
            else if (student.Grade > 8.5 && student.Grade <= 10) student.GradeStrategy = new DistinctionStrategy();
        }

        // Remove space
        private string[] RemoveSpace(string[] arr)
        {
            for(int i =0; i<arr.Length; i++)
            {
                arr[i] = arr[i].Trim();
            }
            return arr;
        }

        // Add student
        public void CreateStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Create new student.");
            Console.WriteLine("Format: <ID>, <Name>, <Age>, <Grade>. Example: 102, Phan Nhat Linh, 20, 8.5");
            Console.Write("New student information: ");

            // Input info
            var info = Console.ReadLine();
            info = info.Trim();
            var infoArr = info.Split(",");
            infoArr = RemoveSpace(infoArr);

            // handle add student
            if (infoArr.Length == 4)
            {
                Student student = new 
                    Student(infoArr[0], infoArr[1], int.Parse(infoArr[2]), double.Parse(infoArr[3]));
                if(!checkIDExist(student.Id))
                {
                    SettingRatting(student);
                    this.listOfStudent.Add(student);
                    Console.WriteLine("Create student successfully");
                } else
                {
                    Console.WriteLine("ID already exist!");
                }
                
            } else
            {
                Console.Write("Wrong format!");
            }
        }

        // Get student by ID
        private Student GetStudentById(string id)
        {
            foreach (Student student in this.listOfStudent)
            {
                if (student.Id == id) return student;
            }
            return new Student();
        }

        private List<Student> GetStudentByName(string name)
        {
            List<Student> newList = new List<Student>();
            foreach (Student student in this.listOfStudent)
            {
                if (student.Name == name) newList.Add(student);
            }
            return newList;
        }

        // Update Student
        public void UpdateStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Update student");
            Console.Write("ID student you want to update: ");
            string id = Console.ReadLine();
            if(checkIDExist(id))
            {
                Student student = GetStudentById(id);
                // Input info
                Console.WriteLine();
                Console.WriteLine("Update student.");
                Console.WriteLine("Format: <Name>, <Age>, <Grade>. Example: Phan Nhat Linh, 20, 8.5");
                Console.Write("Student information: ");
                var info = Console.ReadLine();
                info = info.Trim();
                var infoArr = info.Split(",");
                infoArr = RemoveSpace(infoArr);
                if (infoArr.Length == 3)
                {
                    //Student student = new
                    //    Student(infoArr[0], infoArr[1], int.Parse(infoArr[2]), double.Parse(infoArr[3]));
                    student.Name = infoArr[0];
                    student.Age = int.Parse(infoArr[1]);
                    student.Grade = double.Parse(infoArr[2]);
                    SettingRatting(student);
                    Console.Write("Update successfully");
                }
                else
                {
                    Console.Write("Wrong format!");
                }
            } else
            {
                Console.Write("Student ID does not exist");
            }
        }

        // Delete student
        public void DeleteStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Delete student");
            Console.Write("ID student you want to delete: ");
            string id = Console.ReadLine();
            if (checkIDExist(id))
            {
                this.listOfStudent.Remove(GetStudentById(id));
                Console.WriteLine("Delete student successfully");
            }
            else
            {
                Console.WriteLine("Student ID does not exist");
            }
        }
        
        // Search student
        public void SearchStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Search student");
            Console.WriteLine("1. Search by ID");
            Console.WriteLine("2. Search by Name");
            Console.Write("Your choice: ");
            string choiceLevel3 = Console.ReadLine();
            while (choiceLevel3 != "1" && choiceLevel3 != "2")
            {
                Console.Write("Please input 1 or 2: ");
                choiceLevel3 = Console.ReadLine();
            }
            if (choiceLevel3 == "1")
            {
                Console.Write("ID student you want to find: ");
                string id = Console.ReadLine();
                if (checkIDExist(id))
                {
                    Student student = GetStudentById(id);
                    Console.Write("Result:");
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}" +
                        $", Grade: {student.Grade}, Ratting: {student.GettingGrade()}");
                }
                else
                {
                    Console.WriteLine("Student ID does not exist");
                }
            } else if(choiceLevel3 == "2")
            {
                Console.Write("Student's name you want to find: ");
                string name = Console.ReadLine();
                if (checkNameExist(name))
                {
                    Console.WriteLine("Result:");
                    foreach (Student student in GetStudentByName(name))
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}" +
                            $", Grade: {student.Grade}, Ratting: {student.GettingGrade()}");
                    }
                }
                else
                {
                    Console.WriteLine("Student Name does not exist");
                }

            }

            

        }
    }
}
