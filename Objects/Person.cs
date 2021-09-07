using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox_Year_1
{
    public class Person
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }

        public Person(string firstName, string lastName, int age, int id = 0)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Age = age;
            Id = id;
        }

        // Try doing it this way
        public override string ToString() => $"Id {Id}: Name {FirstName} {LastName}, Age {Age}";
    }
}
