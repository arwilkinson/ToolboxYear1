using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox_Year_1.Queries;

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
            Console.WriteLine("3 : Exit Application");
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

                    DisplayPersons(new SelectAllPersons().OutputPersons());

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

        private void SearchMenu()
        {
            var person = new Person();
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

                    DisplayPersons(new SearchPersons("1", UserInput).OutputPersons());

                    break;

                case "2":
                    Console.WriteLine();

                    Console.WriteLine("Enter Last Name");

                    GetInput();

                    DisplayPersons(new SearchPersons("2", UserInput).OutputPersons());

                    break;

                case "3":
                    Console.WriteLine();

                    Console.WriteLine("Enter Age");

                    GetInput();

                    DisplayPersons(new SearchPersons("3", UserInput).OutputPersons());

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
