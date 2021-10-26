using System;
using System.Data.SqlClient;

namespace I3.WAD21.Exos.Ado02
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONN_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT student_id, first_name, last_name FROM student";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                            Console.WriteLine($"{reader["student_id"]} {reader["first_name"]} {reader["last_name"]}");
                    }
                }

                connection.Close();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT AVG(year_result) FROM student";
                    connection.Open();
                    int moyenne = (int)command.ExecuteScalar();
                    Console.WriteLine($"La moyenne de la classe est de {moyenne} sur 20.");
                }
            }
        }
    }
}
