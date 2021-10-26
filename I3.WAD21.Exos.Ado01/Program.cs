using System;
using System.Data.SqlClient;

namespace I3.WAD21.Exos.Ado01
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CONN_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True";

            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = CONN_STRING;

            SqlConnection connection = new SqlConnection(CONN_STRING);

            Console.WriteLine(connection.State);
            connection.Open();
            Console.WriteLine(connection.State);
            connection.Close();
            Console.WriteLine(connection.State);
        }
    }
}
