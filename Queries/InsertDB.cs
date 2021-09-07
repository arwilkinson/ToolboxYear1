using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Toolbox_Year_1.Queries
{
    public class InsertDB
    {
        private List<Person> Persons = new List<Person>();
        private string Query = "insert into Persons ([First Name], [Last Name], [Age]) OUTPUT INSERTED.Id values (@firstName, @lastName, @age)";

        public InsertDB(Person person)
        {
            UpdateDB(person);

            OutputResult();
        }

        private string OutputResult()
        {
            return "Worked";
        }

        private void UpdateDB(Person person)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=Test;Trusted_Connection=True;";

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@firstName", person.FirstName);
            command.Parameters.AddWithValue("@lastName", person.LastName);
            command.Parameters.AddWithValue("@age", person.Age);

            try
            {
                connection.Open();

                int newID = (int)command.ExecuteScalar();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
