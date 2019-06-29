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
        private static string connectionString = "Server=127.0.0.1; User id=postgres; Password=123456789; Database=eclassmirror";

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

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static List<int> GetIds(string table)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

					string sql = "SELECT * FROM " + table;
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					NpgsqlDataReader results = cmd.ExecuteReader();

					List<int> returnList = new List<int>();

					while (results.Read())
					{
						returnList.Add(results.GetInt32(0));
					}
					
                    con.Close();
					return returnList;
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
		public static void InsertUser(string userType, string name, string password, string surname, Email email)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();

					string sql = "INSERT INTO Users VALUES(@reg_num, @name, @password, @surname, @email)";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					
					RegNum regNum = new RegNum(RegNum.getNextValue(userType));
					cmd.Parameters.AddWithValue("reg_num", regNum.getRegNumString());
					cmd.Parameters.AddWithValue("name", name);
					cmd.Parameters.AddWithValue("password", password);
					cmd.Parameters.AddWithValue("surname", surname);
					cmd.Parameters.AddWithValue("email", email.getEmailAddress());
					cmd.ExecuteNonQuery();

					sql = "INSERT INTO " + userType + "s VALUES(@reg_num)";
					cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("reg_num", regNum.getRegNumString());
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
		public static Project GetProject(string projectID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Projects WHERE id = @ID";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("ID", projectID);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    if (results.Read())
                    {
                        string name = results.GetString(results.GetOrdinal("name"));
                        string description = results.GetString(results.GetOrdinal("description"));
                        int max_grade = results.GetInt32(results.GetOrdinal("max_grade"));
                        con.Close();
                        return new Project(projectID, name, description, max_grade);
                    }
                    else
                    {
                        MessageBox.Show("No project with id: " + projectID + " found!");
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
        public static List<Project> GetProjectsForCourse(string courseID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT id FROM Projects WHERE course_id = @ID";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("ID", courseID);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    List<Project> Projects = new List<Project>();
                    while (results.Read())
                    {
                        string id = results.GetString(results.GetOrdinal("course_id"));
                        Projects.Add(GetProject(id));
                    }
                    return Projects;
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
		public static void InsertProject(string name, string description, int max_grade)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Projects VALUES(@id, @name, @description, @max_grade)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", RegNum.getNextValue("project"));
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("max_grade", max_grade);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
            }
        }

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteProject(Project proj)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "DELETE FROM Projects WHERE id = @id)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", proj.getProjectID());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void GradeProject(ProjectFile projectFile, int grade)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE ProjectsOfTeam SET grade = @grade WHERE project_file_id = @fileID";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("grade", grade);
                    cmd.Parameters.AddWithValue("fileID", projectFile.getProjectFileID());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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
                    List<Course> courses = new List<Course>();
                    while (results.Read())
                    {
                        courses.Add(new Course(results[0].ToString(), results[1].ToString(), (Professor)GetUser("Professor", prof_reg_num), GetProjectsForCourse(results[0].ToString()),GetTeams(results[0].ToString())));//0 = course id, 1 = course name
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

/*
		[MethodImpl(MethodImplOptions.Synchronized)]
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
                    return;
                }
            }
        }
        */

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void InsertStudentToTeam(Course course, Student student, Team team)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql = "INSERT INTO StudentsTeam VALUES(@stu_reg_num, @team_id, @course_id)";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("stu_reg_num", student.registrationNumber.getRegNumString());
					cmd.Parameters.AddWithValue("team_id", team.getTeamID());
					cmd.Parameters.AddWithValue("course_id", course.getCourseID());
					cmd.ExecuteNonQuery();
					con.Close();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
				}
			}
		}


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void UploadProject(string id, byte[] file, string name, string date)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO files VALUES(@id, @file, @name, @date)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("file", file);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("date", date);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
                con.Close();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void InsertTeam(string id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO files VALUES(@id)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
                con.Close();
            }
        }
        
        /*
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static List<Team> GetTeams(string courseID) 
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "select teams.id from teams inner join StudentsTeams on teams.id=StudentsTeams.team_id where course_id=@courseID";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("courseID", courseID);
                    NpgsqlDataReader results = cmd.ExecuteReader();

                    List<string> teams = new List<string>();
                    while (results.Read())
                    {
                        teams.Add(new Team(results[0].ToString(), );
                    }
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());
                    
                }
                con.Close();
            }
        }
        */

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Dictionary<Project, ProjectFile> GetTeamsProjectFiles(string teamID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "select project_id, project_file_id from ProjectsOfTeam where team_id=@teamID;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("teamID", teamID);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    Dictionary<Project, ProjectFile> dict = new Dictionary<Project, ProjectFile>();
                    while (results.Read())
                    {
                        dict.Add(GetProject(results[0].ToString()), GetFileDetails(teamID, results[0].ToString()));
                    }
                    con.Close();
                    return dict;
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());
                    return null;
                }
                con.Close();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ProjectFile GetFileDetails(string teamID, string projectID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "select * from projectfiles where id=(select project_file_id from Projectsofteam where team_id=@teamID  and project_id=@projectID);";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("teamID", teamID);
                    cmd.Parameters.AddWithValue("projectID", projectID);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    if (results.Read())
                    {
                        con.Close();
                        return new ProjectFile(results[0].ToString(), (byte[])results[1], results[2].ToString(),GetGrade(teamID, projectID), results.GetTimeStamp(3).ToDateTime());
                    }
                    else
                    {
                        con.Close();
                        return null;
                    }
                    
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());
                    return null;

                }
                con.Close();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static int GetGrade(string teamID, string projectID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "select grade from Projectsofteam where team_id=@teamID  and project_id=@projectID;";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("teamID", teamID);
                    cmd.Parameters.AddWithValue("projectID", projectID);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    if (results.Read())
                    {
                        return results.GetInt32(3);
                    }
                    else
                    {
                        return -1;
                    }
                    con.Close();
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());
                    return -1;
                }
                con.Close();
            }

        }


    }
}
