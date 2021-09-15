using System;
using System.Collections.Generic;
using Toolbox_Year_1.Models.Queries;
using static Toolbox_Year_1.Models.Queries.QueryStrings;
using static Toolbox_Year_1.Models.Queries.QueryDB;
using Toolbox_Year_1.Models;
//using c = System.Console; <-- Alias name space

namespace Toolbox_Year_1.Views
{
    public class Menu
    {
        private string UserInput { get; set; }

        public void MainMenu()
        {
            Console.WriteLine("|-------------------------|");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 : Select All Persons");
            Console.WriteLine("2 : Search For Persons");
            Console.WriteLine("3 : Create New Person");
            Console.WriteLine("4 : Update Person");
            Console.WriteLine("5 : Delete Person");
            Console.WriteLine("6 : Exit Application");
            Console.WriteLine("|-------------------------|");

            ProcessMenuSelection(Console.ReadLine()) ;
        }

        private void ProcessMenuSelection(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    Console.WriteLine();

                    DisplayPersons(SelectAll());

                    Console.WriteLine();
                    MainMenu();
                    break;

                case "2":
                    Console.WriteLine();

                    SearchMenu();

                    Console.WriteLine();
                    MainMenu();
                    break;

                case "3":
                    Console.WriteLine();

                    InsertDB();

                    Console.WriteLine();
                    MainMenu();
                    break;

                case "4":
                    Console.WriteLine();

                    UpdateDB();
                    MainMenu();

                    break;

                case "5":
                    Console.WriteLine();
                    DeletePerson();
                    MainMenu();
                    break;

                case "6":
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine();

                    Console.WriteLine($"{UserInput} is not a valid selection...");

                    Console.WriteLine();
                    MainMenu();
                    break;
            }
        }

        private void DeletePerson()
        {
            Console.WriteLine("Enter Person ID: ");

            int id = ConvertToInt(Console.ReadLine().ToString());

            if (id != -1)
            {
                QueryDB.Delete(id);

                DisplayPersons(SearchWhereId(id));
            }
            else
            {
                Console.WriteLine("Numeric values are not valid. Enter numbers ONLY.");
            }
        }

        private void UpdateDB()
        {
            Console.WriteLine("Enter Person ID: ");

            int id = ConvertToInt(Console.ReadLine().ToString());

            Console.Write("First name: ");

            string firstName = Console.ReadLine().ToString();

            Console.Write("Last name: ");

            string lastName = Console.ReadLine().ToString();

            Console.Write("Age: ");

            int age = ConvertToInt(Console.ReadLine().ToString());

            if (age != -1 && id != -1)
            {
                QueryDB.Update(new Person(firstName, lastName, age), id);

                DisplayPersons(SearchWhereId(id));
            }
            else
            {
                Console.WriteLine("Numeric values are not valid. Enter numbers ONLY.");
            }
        }

        private int ConvertToInt(string userInput)
        {
            int id = -1;

            Int32.TryParse(userInput, out id);

            return id;
        }

        private void InsertDB()
        {
            string firstName;
            string lastName;
            int age;

            Console.WriteLine();

            Console.WriteLine("Enter values to insert.");

            Console.Write("First name: ");

            firstName = Console.ReadLine().ToString();

            Console.Write("Last name: ");

            lastName = Console.ReadLine().ToString();

            Console.Write("Age: ");

            age = Convert.ToInt32(Console.ReadLine());

            Insert(new Person(firstName, lastName, age));

            Console.WriteLine("Inserted!");

            Console.WriteLine();
        }

        private void SearchMenu()
        {
            Console.WriteLine("What would you like to search by?");
            Console.WriteLine("1: First Name");
            Console.WriteLine("2: Last Name");
            Console.WriteLine("3: Age");

            ProcessSearchMenu(Console.ReadLine());
        }

        private void ProcessSearchMenu(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    Console.WriteLine();

                    Console.WriteLine("Enter First Name");

                    DisplayPersons(SearchWhereFirstName(Console.ReadLine()));

                    break;

                case "2":
                    Console.WriteLine();

                    Console.WriteLine("Enter Last Name");

                    DisplayPersons(SearchWhereLastName(Console.ReadLine()));

                    break;

                case "3":
                    Console.WriteLine();

                    Console.WriteLine("Enter Age");

                    DisplayPersons(SearchWhereAge(Console.ReadLine()));

                    break;

                default:
                    Console.WriteLine();

                    Console.WriteLine($"{UserInput} is not a valid selection...");

                    Console.WriteLine();
                    SearchMenu();
                    break;
            }
        }

        private void DisplayPersons(List<Person> persons)
        {
            Console.WriteLine("Result:");
            foreach(var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
