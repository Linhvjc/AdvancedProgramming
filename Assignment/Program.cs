using System;
using System.Collections.Generic;
using System.Data;
using ConsoleTables;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List object
            List<Person> students = new List<Person>();
            List<Person> lecturers = new List<Person>();

            // Display main menu
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Student and Lecturer management software");
                Console.WriteLine();
                // Main menu
                Console.WriteLine("|------------------------------------------------------------------------|");
                Console.WriteLine("|     1. Student management         |         2. Lecturer management     |");
                Console.WriteLine("|------------------------------------------------------------------------|");
                Console.WriteLine("Type \"Exit\" to exit the program");
                Console.Write("Your choice: ");
                string choiceLevel1 = Console.ReadLine();

                // Validate input
                while (choiceLevel1 != "1" && choiceLevel1 != "2"
                    && choiceLevel1 != "Exit" && choiceLevel1 != "exit")
                {
                    Console.Write("Please input 1 or 2: ");
                    choiceLevel1 = Console.ReadLine();
                    if (choiceLevel1 == "Exit" || choiceLevel1 == "exit") break;
                }

                // break while loop
                if (choiceLevel1 == "Exit" || choiceLevel1 == "exit") break;
                // switch to other menu
                if (choiceLevel1 == "1") StudentMenu(students);
                if (choiceLevel1 == "2") LecturerMenu(lecturers);
            }
        }

        // Student menu
        static void StudentMenu(List<Person> students)
        {
            while (true)
            {
                // create table
                var tableStudent = new ConsoleTable("ID", "Name", "Age", "Grade", "Rating");
                Console.WriteLine("_______________________________________________________________________" +
                    "_________________________________________________");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Student menu");
                Console.WriteLine("List student");

                // check if the list is empty
                if (students.Count == 0)
                {
                    Console.WriteLine("\t\t\t\t    No records to display");
                }
                else
                {
                    // add row to table
                    foreach (Student student in students)
                    {
                        student.AddRowTable(tableStudent);
                    }
                    Console.WriteLine(tableStudent.ToString());
                }

                Console.WriteLine();
                Console.WriteLine("Action:");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|1. Create |\t2. Update |\t3. Delete |\t4. Search |\t5.Filter |\t6.Sort |\t7.Reset  |");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("Type \"Exit\" to back");
                Console.Write("Your choice: ");

                // input choice
                string choice = GetChoiceLevel1();
                if (choice == "Exit" || choice == "exit") break;
                if (choice == "1") Create(students, "Student");
                else if (choice == "2") Update(students, "Student");
                else if (choice == "3") Delete(students, "Student");
                else if (choice == "4") Search(students, "Student");
                else if (choice == "5") Filter(students, "Student");
                else if (choice == "6") Sort(students, "Student");
                else if (choice == "7") Reset(students, "Student");
                Console.WriteLine("Enter to continue.");
                Console.ReadLine();
                Console.WriteLine();
            }

        }

        // Lecturer menu
        static void LecturerMenu(List<Person> lecturers)
        {
            while (true)
            {
                // create table
                var tableTeacher = new ConsoleTable("ID", "Name", "Age", "Year Experience", "Rating");
                Console.WriteLine("_______________________________________________________________________" +
                    "_________________________________________________");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t Lecturer menu");
                Console.WriteLine("List lecturer");

                // check if the list is empty
                if (lecturers.Count == 0)
                {
                    Console.WriteLine("\t\t\t\t    No records to display");
                }
                else
                {
                    // add row to table
                    foreach (Lecturer lecturer in lecturers)
                    {
                        lecturer.AddRowTable(tableTeacher);
                    }
                    Console.WriteLine(tableTeacher.ToString());
                }

                Console.WriteLine();
                Console.WriteLine("Action:");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("|1. Create |\t2. Update |\t3. Delete |\t4. Search |\t5.Filter |\t6.Sort |\t7.Reset  |");
                Console.WriteLine("|--------------------------------------------------------------------------------------------------------|");
                Console.WriteLine("Type \"Exit\" to back");
                Console.Write("Your choice: ");

                // input choice
                string choice = GetChoiceLevel1();
                if (choice == "Exit" || choice == "exit") break;
                if (choice == "1") Create(lecturers, "Lecturer");
                else if (choice == "2") Update(lecturers, "Lecturer");
                else if (choice == "3") Delete(lecturers, "Lecturer");
                else if (choice == "4") Search(lecturers, "Lecturer");
                else if (choice == "5") Filter(lecturers, "Lecturer");
                else if (choice == "6") Sort(lecturers, "Lecturer");
                else if (choice == "7") Reset(lecturers, "Lecturer");
                Console.WriteLine("Enter to continue.");
                Console.ReadLine();
                Console.WriteLine();
            }

        }

        // 1. Create object
        static void Create(List<Person> list, string objName)
        {
            Console.WriteLine();
            Console.WriteLine($"Create new {objName}");

            //Display example
            if (objName == "Student")
            {
                Console.WriteLine("Format: <ID>, <Name>, <Age>, <Grade>. Example: 102, Phan Nhat Linh, 20, 8.5");
            }
            else if (objName == "Lecturer")
            {
                Console.WriteLine("Format: <ID>, <Name>, <Age>, <YearExperience>. Example: 102, Phan Nhat Linh, 20, 3");
            }
            Console.WriteLine();

            // input information 
            while (true)
            {
                Console.Write($"New {objName} information (type \"End\" to cancel): ");
                // Input info
                var info = Console.ReadLine();
                info = info.Trim();
                if (info == "") continue;
                if (info == "end" || info == "End") break;
                var infoArr = info.Split(",");
                infoArr = RemoveSpace(infoArr);

                // handle add student
                if (infoArr.Length == 4) // check length of argument
                {
                    try
                    {
                        Person newObj = new Person();

                        // Throw exception when input wrong type of Age
                        try
                        {
                            int.Parse(infoArr[2]);
                        } catch (Exception e) {
                            throw new Exception("Type of Age must be integer");
                        }

                        // if object is Student
                        if (objName == "Student")
                        {
                            // Throw exception when input wrong type of Grade
                            try
                            {
                                double.Parse(infoArr[3]);
                            } catch (Exception e)
                            {
                                throw new Exception("Type of Grade must be Double");
                            }
                            // Create new Student
                            newObj = new
                                Student(infoArr[0], infoArr[1], int.Parse(infoArr[2]), double.Parse(infoArr[3]));
                        }
                        // if object is lecturer
                        else if (objName == "Lecturer")
                        {
                            // Throw exception when input wrong type of Year experience
                            try
                            {
                                int.Parse(infoArr[3]);
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Type of Year experience must be integer");
                            }
                            //Create new Lecturer
                            newObj = new
                                Lecturer(infoArr[0], infoArr[1], int.Parse(infoArr[2]), int.Parse(infoArr[3]));
                        }

                        // Check if object is exist
                        if (!checkIDExist(newObj.Id, list))
                        {
                            list.Add(newObj);
                            Console.WriteLine($"Create {objName} successfully");
                        }
                        else
                        {
                            Console.WriteLine("ID already exist!");
                        }
                    // Catch exception in own class 
                    } catch (ArgumentOutOfRangeException a)
                    {
                        Console.WriteLine(a.Message);
                        Console.WriteLine("Create failed");
                    }
                    // Catch exception in above
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Create failed");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format!");
                }
            }
        }

        // 2. Update Object
        static void Update(List<Person> list, string objName)
        {
            if (list.Count >0)
            {
                Console.WriteLine();
                Console.WriteLine($"Update {objName}");
                Console.Write($"ID {objName} you want to update: ");

                // input id to update
                string id = Console.ReadLine();

                // check if object is exist
                if (checkIDExist(id, list))
                {
                    // get object by ID
                    Person person = GetObjectById(id, list);
                    Console.WriteLine();
                    Console.Write("Information: ");
                    person.DisplayInfoWhenSearchOrFilter();

                    // display example
                    if (objName == "Student")
                    {
                        Console.WriteLine("Update Format: <Name>, <Age>, <Grade>. Example: Phan Nhat Linh, 20, 8.5");
                    }
                    else if (objName == "Lecturer")
                    {
                        Console.WriteLine("Update Format: <Name>, <Age>, <Year>. Example: Phan Nhat Linh, 20, 6");
                    }

                    // input information
                    Console.Write($"{objName} information: ");
                    var info = Console.ReadLine();
                    info = info.Trim();
                    var infoArr = info.Split(",");
                    infoArr = RemoveSpace(infoArr);

                    // check length of argument
                    if (infoArr.Length == 3)
                    {
                        try
                        {
                            // Throw exception when input wrong type of Age
                            try
                            {
                                int.Parse(infoArr[1]);
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Type of Age must be integer");
                            }
                            // set Name and Age to new object
                            person.Name = infoArr[0];
                            person.Age = int.Parse(infoArr[1]);

                            // check object name
                            if (objName == "Student")
                            {
                                // Throw exception when input wrong type of Grade
                                try
                                {
                                    double.Parse(infoArr[2]);
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("Type of Grade must be Double");
                                }
                                // Set grade to new object
                                ((Student)person).Grade = double.Parse(infoArr[2]);
                            }
                            else if (objName == "Lecturer")
                            {
                                // Throw exception when input wrong type of Year experience
                                try
                                {
                                    int.Parse(infoArr[2]);
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("Type of Year experience must be integer");
                                }
                                // set year experience to new object
                                ((Lecturer)person).YearExperience = int.Parse(infoArr[2]);
                            }
                            Console.WriteLine("Update successfully");
                        }
                        // Catch exception in own class
                        catch (ArgumentOutOfRangeException a)
                        {
                            Console.WriteLine(a.Message);
                            Console.WriteLine("Update failed");
                        }
                        // Catch exception in above
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Update failed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong format!");
                    }
                }
                else
                {
                    Console.WriteLine($"{objName} ID does not exist");
                }
            } else
            {
                Console.WriteLine("Your list is empty");
            }
        }

        // 3.Delete Object
        static void Delete(List<Person> list, string objName)
        {
            if(list.Count >0)
            {
                Console.WriteLine();
                Console.WriteLine($"Delete {objName}");
                Console.Write($"ID {objName} you want to delete: ");

                // input id to delete
                string id = Console.ReadLine();

                // check if ID is exist
                if (checkIDExist(id, list))
                {
                    // delete object is found
                    list.Remove(GetObjectById(id, list));
                    Console.WriteLine($"Delete {objName} successfully");
                }
                else
                {
                    Console.WriteLine($"{objName} ID does not exist");
                }
            } else
            {
                Console.WriteLine("Your list is empty");
            }
        }

        // 4.Search Object
        static void Search(List<Person> list, string objName)
        {
            if (list.Count >0)
            {
                Console.WriteLine();
                Console.WriteLine($"Search {objName}");
                Console.WriteLine("|-------------------------------------------------------------------|");
                Console.WriteLine("|     1. Search by ID         |         2. Search by Name           |");
                Console.WriteLine("|-------------------------------------------------------------------|");
                Console.Write("Your choice: ");

                // input choice
                string choice = GetChoiceLevel2();
                // Search by ID
                if (choice == "1")
                {
                    Console.Write($"ID {objName} you want to find: ");

                    // input id to search
                    string id = Console.ReadLine();

                    // check object is exist
                    if (checkIDExist(id, list))
                    {
                        // get object by ID
                        Person person = GetObjectById(id, list);
                        Console.WriteLine("Result:");
                        // display information
                        person.DisplayInfoWhenSearchOrFilter();
                    }
                    else
                    {
                        Console.WriteLine($"{objName} ID does not exist");
                    }
                }
                // Search by name
                else if (choice == "2")
                {
                    Console.Write($"{objName}'s name you want to find: ");
                    // input name to search
                    string name = Console.ReadLine();

                    // check if object is exist
                    if (checkNameExist(name, list))
                    {
                        Console.WriteLine("Result:");
                        foreach (Person person in GetObjectByName(name, list))
                        {
                            // display information
                            person.DisplayInfoWhenSearchOrFilter();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{objName} Name does not exist");
                    }

                } 
            } else
            {
                Console.WriteLine("Your list is empty");
            }

        }

        // 5.Filter Object
        static void Filter(List<Person> list, string objName)
        {
            if(list.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Filter {objName}");

                // display option when object is Stdent
                if (objName == "Student")
                {
                    Console.WriteLine("|------------------------------------------------------------------------|");
                    Console.WriteLine("|     1. Filter by grade         |         2. Filter by rating           |");
                    Console.WriteLine("|------------------------------------------------------------------------|");
                }
                // display option when object is Lecturer
                else if (objName == "Lecturer")
                {
                    Console.WriteLine("|-------------------------------------------------------------------------------|");
                    Console.WriteLine("|     1. Filter by year experience         |         2. Filter by rating        |");
                    Console.WriteLine("|-------------------------------------------------------------------------------|");
                }

                // input choice
                Console.Write("Your choice: ");
                string choice = GetChoiceLevel2();

                if (choice == "1")
                {
                    // Input and filter by grade
                    if (objName == "Student")
                    {
                        Console.Write("Student's grade you want to filter: ");
                        try
                        {
                            double grade = double.Parse(Console.ReadLine());
                            if (grade <0 || grade > 10)
                            {
                                Console.WriteLine("Grade must be from 0 to 10");
                            } else
                            {
                                FilterByGrade(grade, list);
                            }
                        } catch (Exception e)
                        {
                            Console.WriteLine("Age must be double");
                        }
                    }
                    // Input and filter by year experience
                    else if (objName == "Lecturer")
                    {
                        Console.Write("Lecturer's year experience you want to filter: ");
                        int year = int.Parse(Console.ReadLine());
                        FilterByYear(year, list);
                    }

                }
                // Input and filter by rating
                else if (choice == "2")
                {
                    Console.Write($"{objName}'s rating you want to filter: ");
                    string rate = Console.ReadLine();
                    rate = rate.Trim();
                    if (objName == "Student" && rate != "Fail" && rate != "Pass" && rate != "Merit" && rate != "Distinction")
                    {
                        Console.WriteLine("Rating must be Fail, Pass, Merit or Distinction");
                    }
                    else if (objName == "Lecturer" && rate != "Junior" && rate != "Middle" && rate != "Senior")
                    {
                        Console.WriteLine("Rating must be Junior, Middle or Senior");
                    } else
                    {
                        FilterByRating(rate, list, objName);
                    }
                }
            } else
            {
                Console.WriteLine("Your list is empty");
            }
        }

        // 6. Sort Object 
        static void Sort(List<Person> list, string objName)
        {
            if(list.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"Sort {objName}");
                Console.WriteLine("|-------------------------------------------------------------|");
                Console.Write("|    1. Sort by name     |    ");

                // create new table
                var table = new ConsoleTable();

                // check object name to add header to the table
                if (objName == "Student")
                {
                    Console.WriteLine("     2. Sort by grade           |");
                    table = new ConsoleTable("ID", "Name", "Age", "Grade", "Rating");
                }
                else if (objName == "Lecturer")
                {
                    Console.WriteLine("2. Sort by year experience      |");
                    table = new ConsoleTable("ID", "Name", "Age", "Year Experience", "Rating");
                }
                Console.WriteLine("|-------------------------------------------------------------|");
                // create new list
                List<Person> newList = new List<Person>();

                // add person to new list
                foreach (Person person in list)
                {
                    newList.Add(person);
                }

                // input choice
                Console.Write("Your choice: ");
                string choice = GetChoiceLevel2();

                // Sort by name
                if (choice == "1")
                {
                    newList.Sort((x, y) =>
                    {
                        int ret = String.Compare(x.Name, y.Name);
                        return ret;
                    });
                    Console.WriteLine();

                    // add row to new table
                    if (objName == "Student")
                    {
                        foreach (Student student in newList)
                        {
                            student.AddRowTable(table);
                        }
                    }
                    else if (objName == "Lecturer")
                    {
                        foreach (Lecturer lecturer in newList)
                        {
                            lecturer.AddRowTable(table);
                        }
                    }
                    Console.WriteLine(table.ToString());

                }
                else if (choice == "2")
                {
                    // sort by grade
                    if (objName == "Student")
                    {
                        newList = newList.OrderBy(x => ((Student)x).Grade).ToList();
                        foreach (Student student in newList)
                        {
                            student.AddRowTable(table);
                        }
                    }
                    // sort by year experience
                    else if (objName == "Lecturer")
                    {
                        newList = newList.OrderBy(x => ((Lecturer)x).YearExperience).ToList();
                        foreach (Lecturer lecturer in newList)
                        {
                            lecturer.AddRowTable(table);
                        }
                    }
                    // display table
                    Console.WriteLine(table.ToString());
                }
            } else
            {
                Console.WriteLine("Your list is empty");
            }

        }

        // 7.Reset list
        static void Reset(List<Person> list, string objName)
        {
            if (list.Count >0)
            {
                // confirm to reset list
                Console.WriteLine();
                Console.Write($"Are you sure to reset list {objName}? (Y/N) Default Y: ");
                string choice = Console.ReadLine();
                choice = choice.Trim();

                // validate choice
                while (choice != "Y" && choice != "y" &&
                    choice != "N" && choice != "n" && choice != "")
                {
                    Console.Write("Wrong input. Please type Y or N: ");
                    choice = Console.ReadLine();
                    choice = choice.Trim();
                }
                // reset list
                if (choice == "Y" || choice == "y" || choice == "")
                {
                    list.Clear();
                    Console.WriteLine("Reset list successfully");
                }
                else if (choice == "N" || choice == "n")
                {
                    Console.WriteLine("You canceled the action");
                }
            } else
            {
                Console.WriteLine("Your list is empty");
            }
        }

        // Remove space
        static string[] RemoveSpace(string[] arr)
        {
            // clear space of each item
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i].Trim();
            }
            return arr;
        }

        // Check ID exist
        static bool checkIDExist(string id, List<Person> list)
        {
            // loop the list to check the person is exist
            foreach (Person obj in list)
            {
                if (obj.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        // Get Object by ID
        static Person GetObjectById(string id, List<Person> list)
        {
            // loop the list and find ID to return object by id
            foreach (Person person in list)
            {
                if (person.Id == id) return person;
            }
            return new Person();
        }

        // Getchoicelevel2
        static string GetChoiceLevel2()
        {
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2")
            {
                Console.Write("Please input 1 or 2: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        // Check Name exist
        static bool checkNameExist(string name, List<Person> list)
        {
            foreach (Person person in list)
            {
                if (person.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        // Get Object by name
        static List<Person> GetObjectByName(string name, List<Person> list)
        {
            // create new list to contain object found by name
            List<Person> newList = new List<Person>();
            foreach (Person person in list)
            {
                if (person.Name == name) newList.Add(person);
            }
            return newList;
        }

        static string GetChoiceLevel1()
        {
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" &&
                choice != "3" && choice != "4" && choice != "5" &&
                choice != "6" && choice != "7" && choice != "Exit" && choice != "exit")
            {
                Console.Write("Please input from 1 to 7: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        // Filter by grade
        static void FilterByGrade(double grade, List<Person> list)
        {
            // create new list to contain object filter by grade
            List<Person> newList = new List<Person>();
            foreach (Student student in list)
            {
                if (student.Grade == grade) newList.Add(student);
            }
            if (newList.Count > 0)
            {
                foreach (Student student in newList)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}" +
                            $", Grade: {student.Grade}, Rating: {student.GettingGrade()}");
                }
            }
            else
            {
                Console.WriteLine("No records to display");
            }
        }

        // Filter by Year
        static void FilterByYear(int year, List<Person> list)
        {
            // create new list to contain object filter by year experience
            List<Lecturer> newList = new List<Lecturer>();
            foreach (Lecturer lecturer in list)
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
        static void FilterByRating(string rate, List<Person> list, string objName)
        {
            // create new list to contain object filter by rating
            List<Person> newList = new List<Person>();
            foreach (Person person in list)
            {
                if (objName == "Student")
                {
                    if (((Student)person).GettingGrade() == rate) newList.Add(person);
                }
                else if (objName == "Lecturer")
                {
                    if (((Lecturer)person).GettingExperience() == rate) newList.Add(person);
                }
            }
            if (newList.Count > 0)
            {
                foreach (Person person in newList)
                {
                    person.DisplayInfoWhenSearchOrFilter();
                }
            }
            else
            {
                Console.WriteLine("No records to display");
            }
        }

    }
}