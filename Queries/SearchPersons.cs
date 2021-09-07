using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Toolbox_Year_1.Queries
{
    public class SearchPersons
    {
        private List<Person> Persons = new List<Person>();
        private string QueryFirstName = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [First Name] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

        private string QueryLastName = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [Last Name] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

        private string QueryAge = "SELECT [First Name], [Last Name], [Age], [Id] "
                                        + "FROM Persons "
                                        + "WHERE [Age] like @searchValue "
                                        + "ORDER BY[First Name], [Last Name]";

        public SearchPersons(string userInput, string searchValue)
        {
            if (userInput == "1")
            {
                QueryDB(QueryFirstName, searchValue);
            }
            else if (userInput == "2")
            {
                QueryDB(QueryLastName, searchValue);
            }
            else if (userInput == "3")
            { 
                QueryDB(QueryAge, searchValue);
            }


            OutputPersons();
        }

        public List<Person> OutputPersons()
        {
            return Persons;
        }

        private void QueryDB(string query, string searchValue)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=Test;Trusted_Connection=True;";

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@searchValue", searchValue);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Persons.Add(new Person(reader[0].ToString(), reader[1].ToString(), Convert.ToInt32(reader[2]), Convert.ToInt32(reader[3])));
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
