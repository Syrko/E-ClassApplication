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
using Types;

namespace E_Class
{
    class Database
    {
        private static string connectionString = "Server=127.0.0.1; User id=postgres; Password=123456789; Database=eclass";

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
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem connecting to the server.");
                }
            }
        }

        /*       public static List<Course> GetCoursesForProfessor(string prof_id)
			   {
				   using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
				   {

					   try
					   {
						   con.Open();
						   string sql = "SELECT * FROM \"ProfessorsCourses\" where prof_reg_num=" + "'" + prof_id + "';";
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
						   MessageBox.Show(msg.ToString());
						   MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					   }
				   }
			   }
	   */


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void GetIds(string table)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM " + table + ";";
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
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
            }
        }

        public static string ValidateCredentials(string regNum, string password)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT reg_num FROM Users WHERE reg_num=@regNum AND password=@password";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("regNum", regNum);
                    cmd.Parameters.AddWithValue("password", password);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    if (results.Read())
                    {
                        switch (regNum[0])
                        {
                            case 'M':
                                return UserTypes.STUDENT;
                            case 'K':
                                return UserTypes.PROFESSOR;
                            case 'A':
                                return UserTypes.ADMIN;
                            default:
                                MessageBox.Show("Invalid reg_num -- Error at validation", "Error");
                                con.Close();
                                return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credentials do not match. \nCheck your input and try again.");
                        con.Close();
                        return null;
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    return null;
                }
            }
        }

        /*
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static User GetUser(string userType, string userRegNum)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();

					string sql = "SELECT * FROM Users WHERE reg_num=@regNum";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Prepare();
					cmd.Parameters.AddWithValue("regNum", userRegNum);
					NpgsqlDataReader results = cmd.ExecuteReader();
					if (results.Read())
					{
						RegNum reg_num = new RegNum(results.GetString(results.GetOrdinal("reg_num"))[0], int.Parse(results.GetString(results.GetOrdinal("reg_num")).Substring(1)));




						switch (userType)
						{
							case UserTypes.ADMIN:
						    return;
			}
					}
					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
				}
			}
		}
	}

        public static List<Course> GetCoursesForProf(string prof_reg_num)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "Select courses.id, courses.name from(users inner join professors on users.reg_num = professors.reg_num)" +
                        " inner join ProfessorsCourses on users.reg_num=professorscourses.prof_reg_num" +
                        " inner join courses on professorscourses.course_id=courses.id where professors.reg_num=@reg_num";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("reg_num", prof_reg_num);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    List<string> courses = new List<string>();
                    while (results.Read())
                    {
                        courses.Add(new Course(results[0].ToString(), results[1].ToString()));//0 = course id, 1 = course name
                    }
                    con.Close();
                    return courses;
                    
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    con.Close();
                    return null;
                }
            }
        }
        */

        public static void InsertCourse(string prof_reg_num)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "Select courses.id, courses.name from(users inner join professors on users.reg_num = professors.reg_num)" +
                        " inner join ProfessorsCourses on users.reg_num=professorscourses.prof_reg_num" +
                        " inner join courses on professorscourses.course_id=courses.id where professors.reg_num=@reg_num";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("reg_num", prof_reg_num);
                    N results = cmd.ExecuteNonQuery();
                    List<string> courses = new List<string>();
                    if(results.Read())
                    {
                        
                    }
                    con.Close();

                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    con.Close();
                    return null;
                }
            }
        }



    }

}
