using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Toolbox_Year_1.Queries
{
    public class SelectAllPersons
    {
        private List<Person> Persons = new List<Person>();
        private string Query = "SELECT [First Name], [Last Name], [Age] from Persons ORDER BY [First Name], [Last Name]";

        public SelectAllPersons()
        {
            QueryDB();

            OutputPersons();
        }

        public List<Person> OutputPersons()
        {
            return Persons;
        }

        private void QueryDB()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=Test;Trusted_Connection=True;";

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Persons.Add(new Person()
                    {
                        FirstName = reader[0].ToString(),
                        LastName = reader[1].ToString(),
                        Age = Convert.ToInt32(reader[2])
                    });
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
