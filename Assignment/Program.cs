using System.Data;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManagement students = new StudentManagement();
            LecturerManagerment lecturers = new LecturerManagerment();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Student and Lecturer management software");
                Console.WriteLine();
                // Main menu
                Console.WriteLine("1. Student management");
                Console.WriteLine("2. Lecturer management");
                Console.WriteLine("Type \"Exit\" to exit the program");
                Console.Write("Your choice: ");
                string choiceLevel1 = Console.ReadLine();

                // Validate input
                while(choiceLevel1 != "1" && choiceLevel1 != "2"
                    && choiceLevel1 != "Exit" && choiceLevel1 != "exit")
                {
                    Console.Write("Please input 1 or 2: ");
                    choiceLevel1 = Console.ReadLine();
                    if (choiceLevel1 == "Exit" || choiceLevel1 == "exit") break;
                }

                // break while loop
                if (choiceLevel1 == "Exit" || choiceLevel1 == "exit") break;
                if (choiceLevel1 == "1") StudentMenu(students);
                if (choiceLevel1 == "2") LecturerMenu(lecturers);
            }
            


        }

        // Student menu
        static void StudentMenu(StudentManagement students)
        {
            while (true)
            {
                Console.WriteLine("_______________________________________________________________________" +
                    "_________________________________________________");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Student menu");

                // check if the list is empty
                if (students.ListOfStudent.Count == 0)
                {
                    Console.WriteLine("\t\t\t\t    No records to display");
                }
                else
                {
                    Console.WriteLine("\tID \t\tName \t\t\t\tAge \t\tGrade \t\tRating");
                    Console.WriteLine("");
                    // loop student in list and display
                    foreach (Student student in students.ListOfStudent)
                    {
                        student.DisplayInformation();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("1. Create \t2. Update \t3. Delete \t4. Search \t5.Filter \t6.Sort");
                Console.WriteLine("Type \"Exit\" to back");
                Console.Write("Your choice: ");

                // input choice
                string choice = GetChoice();
                if (choice == "Exit" || choice == "exit") break;
                if (choice == "1") students.CreateStudent();
                else if (choice == "2") students.UpdateStudent();
                else if (choice == "3") students.DeleteStudent();
                else if (choice == "4") students.SearchStudent();
                else if (choice == "5") students.FilterStudent();
                else if (choice == "6") students.SortStudent();
                Console.WriteLine("Enter to continue.");
                Console.ReadLine();
                Console.WriteLine();
            }

        }

        static void LecturerMenu(LecturerManagerment lecturers)
        {
            while(true)
            {
                Console.WriteLine("_______________________________________________________________________" +
                    "_________________________________________________");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Lecturer menu");

                // check if the list is empty
                if (lecturers.ListOfLecturer.Count == 0)
                {
                    Console.WriteLine("\t\t\t\t    No records to display");
                }
                else
                {
                    Console.WriteLine("\tID \t\tName \t\t\t\tAge \t\tYear Experience \t\tRating");
                    Console.WriteLine("");
                    // loop student in list and display
                    foreach (Lecturer lecturer in lecturers.ListOfLecturer)
                    {
                        lecturer.DisplayInformation();
                    }
                }

                Console.WriteLine();
                Console.WriteLine("1. Create \t2. Update \t3. Delete \t4. Search \t5.Filter \t6.Sort");
                Console.WriteLine("Type \"Exit\" to back");
                Console.Write("Your choice: ");

                // input choice
                string choice = GetChoice();
                if (choice == "Exit" || choice == "exit") break;
                if (choice == "1") lecturers.CreateLecturer();
                else if (choice == "2") lecturers.UpdateLecturer();
                else if (choice == "3") lecturers.DeleteLecturer();
                else if (choice == "4") lecturers.SearchLecturer();
                else if (choice == "5") lecturers.FilterLecturer();
                else if (choice == "6") lecturers.SortLecturer();
                Console.WriteLine("Enter to continue.");
                Console.ReadLine();
                Console.WriteLine();
            }
            

        }

        static string GetChoice()
        {
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" &&
                choice != "3" && choice != "4" && choice != "5" &&
                choice != "6" && choice != "Exit" && choice != "exit")
            {
                Console.Write("Please input from 1 to 5: ");
                choice = Console.ReadLine();
            }
            return choice;
        }


        

        
    }
}