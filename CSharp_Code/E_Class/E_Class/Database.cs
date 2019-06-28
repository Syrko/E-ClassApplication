using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Npgsql;


namespace E_Class
{
    class Database
    {
        private static string connectionString="Server=127.0.0.1; User id=postgres; Password=123456789; Database=eclass";

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void CreateTeam(string team_id, List<string> students)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem connecting to the server.");
                }
            }
        }

        public static void GetCoursesForProfessor(string prof_id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    try
                    {
                        con.Open();
                        string sql = "SELECT * FROM \"ProfessorsCourses\" where prof_reg_num="+"'"+prof_id + "';";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                        {
                            using (NpgsqlDataReader dataReader = command.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    MessageBox.Show(String.Format("{0}", dataReader[0]));
                                }
                            }
                        }
                        con.Close();
                    }
                    catch (Exception msg)
                    {
                        //MessageBox.Show(msg.ToString());
                        MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    }
                }
            }
        }








        public static void GetIds(string table)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {           
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM \""+ table+"\";";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, con))
                    {
                        using (NpgsqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                MessageBox.Show(String.Format("{0}", dataReader[0]));
                            }
                        }
                    }
                    con.Close();
                }
                catch (Exception msg)
                {
                    //MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
            }
        }
    }
}
