using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Toolbox_Year_1.Queries
{
    public static class QueryDB
    {
        private static string connectionString = @"Server=hawksoft.database.windows.net;Database=AustinToolbox;User id = darylbehrens;Password=AustinDaryl2021!";


        public static List<Person> SelectAll(string query)
        {
            List<Person> Persons = new List<Person>();
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

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

            return Persons;
        }
        public static List<Person> SearchPersons(string query, string searchValue)
        {
            List<Person> Persons = new List<Person>();
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

            return Persons;
        }
        public static List<Person> SearchPersons(string query, int searchValue)
        {
            List<Person> Persons = new List<Person>();
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

            return Persons;
        }
        public static List<Person> Insert(Person person, string query)
        {
            List<Person> Persons = new List<Person>();
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@firstName", person.FirstName);
            command.Parameters.AddWithValue("@lastName", person.LastName);
            command.Parameters.AddWithValue("@age", person.Age);

            try
            {
                connection.Open();

                Persons.Add(new Person(person.FirstName, person.LastName, person.Age, (int)command.ExecuteScalar()));

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Persons;
        }
        public static List<Person> Update(Person person, string query)
        {
            List<Person> Persons = new List<Person>();
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@firstName", person.FirstName);
            command.Parameters.AddWithValue("@lastName", person.LastName);
            command.Parameters.AddWithValue("@age", person.Age);
            command.Parameters.AddWithValue("@id", person.Id);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Persons;
        }
        public static List<Person> Delete(int id, string query)
        {
            List<Person> Persons = new List<Person>();
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Persons;
        }
    }
}
