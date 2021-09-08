using System;
using System.Collections.Generic;
using Toolbox_Year_1.Queries;
using static Toolbox_Year_1.Queries.QueryStrings;
using static Toolbox_Year_1.Queries.QueryDB;
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
            Console.WriteLine("5 : Exit Application");
            Console.WriteLine("|-------------------------|");

            GetInput();

            ProcessMenuSelection();
        }

        private void ProcessMenuSelection()
        {
            switch (UserInput)
            {
                case "1":
                    Console.WriteLine();

                    DisplayPersons(SelectAll(SelectAllPersonsSql));

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

                    break;

                case "5":
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
                QueryDB.Update(new Person(firstName, lastName, age, id), UpdateSql);

                DisplayPersons(SearchPersons(QueryIdSql, id));
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

            DisplayPersons(Insert(new Person(firstName, lastName, age), InsertSql));

            Console.WriteLine("Inserted!");

            Console.WriteLine();
        }

        private void SearchMenu()
        {
            Console.WriteLine("What would you like to search by?");
            Console.WriteLine("1: First Name");
            Console.WriteLine("2: Last Name");
            Console.WriteLine("3: Age");

            GetInput();

            ProcessSearchMenu();
        }

        private void ProcessSearchMenu()
        {
            switch (UserInput)
            {
                case "1":
                    Console.WriteLine();

                    Console.WriteLine("Enter First Name");

                    GetInput();

                    DisplayPersons(SearchPersons(QueryFirstNameSql, UserInput));

                    break;

                case "2":
                    Console.WriteLine();

                    Console.WriteLine("Enter Last Name");

                    GetInput();

                    DisplayPersons(SearchPersons(QueryLastNameSql, UserInput));

                    break;

                case "3":
                    Console.WriteLine();

                    Console.WriteLine("Enter Age");

                    GetInput();

                    DisplayPersons(SearchPersons(QueryAgeSql, UserInput));

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

        private void GetInput()
        {
            Console.Write("Selection: ");
            UserInput = Console.ReadLine();
        }
    }
}
