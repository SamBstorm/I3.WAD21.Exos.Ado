using I3.WAD21.Exos.Ado03.DTO;
using System;
using System.Data.SqlClient;

namespace I3.WAD21.Exos.Ado03
{
    class Program
    {
        static void Main(string[] args)
        {
            Student me = new Student();
            me.first_name = "Samuel";
            me.last_name = "Legrain";
            me.birth_date = new DateTime(1987,9,27);
            me.year_result = 17;
            me.section_id = 1010;
            me.course_id = "EG2210";
            me.login = "slegrain";

            const string CONN_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = 
                        $"INSERT INTO student (first_name, last_name, year_result, login, course_id, section_id, birth_date) OUTPUT inserted.student_id VALUES ('{me.first_name}', '{me.last_name}', {me.year_result}, '{me.login}', '{me.course_id}', {me.section_id}, '{me.birth_date.ToString("yyyy-MM-dd")}')";
                    connection.Open();
                    me.student_id = (int)command.ExecuteScalar();
                }
            }
            Console.WriteLine($"{me.student_id} - {me.first_name} {me.last_name}");
        }
    }
}
