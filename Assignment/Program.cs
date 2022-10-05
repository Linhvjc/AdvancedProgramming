namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManagement students = new StudentManagement();
            while(true)
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
                if (choiceLevel1 == "2") LecturerMenu();
            }
            


        }

        // Display list student
        static void DisplayStudentTable(StudentManagement students)
        {
            Console.WriteLine("List of student");
            Console.WriteLine("\tID \t\tName \t\t\t\tAge \t\tGrade \t\tRatting");
            Console.WriteLine("");

            // loop student in list and display
            foreach (Student student in students.ListOfStudent)
            {
                student.DisplayInformation();
            }
        }


        // Student menu
        static void StudentMenu(StudentManagement students)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Student menu");

                // check if the list is empty
                if(students.ListOfStudent.Count ==0)
                {
                    Console.WriteLine("\t\t\t\t    No records to display");
                } else
                {
                    DisplayStudentTable(students);
                }

                Console.WriteLine();
                Console.WriteLine("1. Create \t2. Update \t3. Delete \t4. Search \t5.Filter");
                Console.WriteLine("Type \"Exit\" to back");
                Console.Write("Your choice: ");

                // input choice
                string choiceLevel2 = Console.ReadLine();
                while (choiceLevel2 != "1" && choiceLevel2 != "2" &&
                    choiceLevel2 != "3" && choiceLevel2 != "4" && choiceLevel2 != "5" &&
                    choiceLevel2 != "Exit" && choiceLevel2 != "exit")
                {
                    Console.Write("Please input from 1 to 5: ");
                    choiceLevel2 = Console.ReadLine();
                    if (choiceLevel2 == "Exit" || choiceLevel2 == "exit") break;
                }

                // break while loop
                if (choiceLevel2 == "Exit" || choiceLevel2 == "exit") break;
                if (choiceLevel2 == "1") students.CreateStudent();
                if (choiceLevel2 == "2") students.UpdateStudent();
                if (choiceLevel2 == "3") students.DeleteStudent();
                if (choiceLevel2 == "4") students.SearchStudent();
                Console.WriteLine();
            }
            
        }

        static void LecturerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Lecturer menu");
        }

        
    }
}