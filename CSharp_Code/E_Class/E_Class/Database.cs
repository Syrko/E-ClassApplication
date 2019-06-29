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
                    string sql = "SELECT * FROM "+ table+";";
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
					cmd.Parameters.AddWithValue("regNum", userRegNum);
					NpgsqlDataReader results = cmd.ExecuteReader();
					if (results.Read())
					{
						RegNum reg_num = new RegNum(results.GetString(results.GetOrdinal("reg_num"))[0], int.Parse(results.GetString(results.GetOrdinal("reg_num")).Substring(1)));
						string name = results.GetString(results.GetOrdinal("name"));
						string surname = results.GetString(results.GetOrdinal("surname"));
						string password = results.GetString(results.GetOrdinal("password"));
						Email email = new Email(results.GetString(results.GetOrdinal("email")));

						con.Close();
						return UserFactory.getInstance().createUser(userType, reg_num, password, name, surname, email);
						
					}
					else
					{
						MessageBox.Show("No such user -- Database get user");
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

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void InsertUser(string userType, User user)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();

					string sql = "INSERT INTO Users VALUES(@reg_num, @name, @password, @surname, @email)";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("reg_Num", user.registrationNumber.getRegNumString());
					cmd.Parameters.AddWithValue("name", user.name);
					cmd.Parameters.AddWithValue("password", user.password);
					cmd.Parameters.AddWithValue("surname", user.surname);
					cmd.Parameters.AddWithValue("email", user.email.getEmailAddress());
					cmd.ExecuteNonQuery();

					sql = "INSERT INTO " + userType + "s VALUES(@reg_num)";
					cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("reg_num", user.registrationNumber.getRegNumString());
					cmd.ExecuteNonQuery();

					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					return;
				}
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteUser(string userType, User user)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql;
					NpgsqlCommand cmd;
					if(user is Admin)
					{
						sql = "DELETE FROM Admins WHERE reg_num=@reg_num";
						cmd = new NpgsqlCommand(sql, con);
						cmd.Parameters.AddWithValue("reg_Num", user.registrationNumber.getRegNumString());
					}
					else if(user is Student)
					{
						DeleteStudentFromAllTeams((Student)user);

						sql = "DELETE FROM Students WHERE reg_num=@reg_num";
						cmd = new NpgsqlCommand(sql, con);
						cmd.Parameters.AddWithValue("reg_Num", user.registrationNumber.getRegNumString());
					}
					else
					{
						DeleteProfessorFromProfessorsCourses((Professor)user);
						sql = "DELETE FROM Proffesors WHERE reg_num=@reg_num";
						cmd = new NpgsqlCommand(sql, con);
						cmd.Parameters.AddWithValue("reg_Num", user.registrationNumber.getRegNumString());
					}

					sql = "DELETE FROM Users WHERE reg_num=@reg_num";
					cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("reg_Num", user.registrationNumber.getRegNumString());

					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					return;
				}
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteStudentFromAllTeams(Student student)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();

					string sql = "DELETE FROM StudentsTeam WHERE stu_reg_num=@reg_num";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("reg_num", student.registrationNumber.getRegNumString());
					
					cmd.ExecuteNonQuery();


					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					return;
				}
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteStudentFromTeam(Student student, Team team)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();

					string sql = "DELETE FROM StudentsTeam WHERE stu_reg_num=@reg_num AND team_id=@team_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("reg_num", student.registrationNumber.getRegNumString());
					cmd.Parameters.AddWithValue("team_id", team.getTeamID());

					cmd.ExecuteNonQuery();

					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					return;
				}
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteProfessorFromProfessorsCourses(Professor professor)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();

					string sql = "DELETE FROM ProfessorsCourses WHERE prof_reg_num=@reg_num";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("reg_num", professor.registrationNumber.getRegNumString());

					cmd.ExecuteNonQuery();

					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					return;
				}
			}
		}


		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void GetCourse(string courseID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string sql = "SELECT * FROM Courses WHERE id=@courseID;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("courseID", courseID);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    if (results.Read())
                    {
                        MessageBox.Show(results.ToString());//"Invalid reg_num -- Error at validation", "Error");
                    }
                    else
                    {
                        MessageBox.Show("Credentials do not match. \nCheck your input and try again.");
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
}
