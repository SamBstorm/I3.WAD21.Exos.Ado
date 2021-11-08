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
                    SqlParameter p_firstname = new SqlParameter { ParameterName = "fn", Value = me.first_name };
                    command.Parameters.Add(p_firstname);
                    SqlParameter p_lastname = new SqlParameter { ParameterName = "ln", Value = me.last_name };
                    command.Parameters.Add(p_lastname);
                    //command.Parameters.AddWithValue("ln", me.last_name);
                    SqlParameter p_login = new SqlParameter { ParameterName = "lg", Value = me.login };
                    command.Parameters.Add(p_login);
                    SqlParameter p_birthdate = new SqlParameter { ParameterName = "bd", Value = me.birth_date };
                    command.Parameters.Add(p_birthdate);
                    SqlParameter p_sectionid = new SqlParameter { ParameterName = "sid", Value = me.section_id };
                    command.Parameters.Add(p_sectionid);
                    SqlParameter p_courseid = new SqlParameter { ParameterName = "cid", Value = me.course_id };
                    command.Parameters.Add(p_courseid);
                    SqlParameter p_yearresult = new SqlParameter { ParameterName = "yr", Value = me.year_result };
                    command.Parameters.Add(p_yearresult);
                    command.CommandText = 
                        $"INSERT INTO student (first_name, last_name, year_result, login, course_id, section_id, birth_date) OUTPUT inserted.student_id VALUES (@fn, @ln, @yr, @lg, @cid,@sid, @bd)";
                    connection.Open();
                    me.student_id = (int)command.ExecuteScalar();
                }
            }
            Console.WriteLine($"{me.student_id} - {me.first_name} {me.last_name}");
        }
    }
}
