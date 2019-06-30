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
using System.IO;

namespace E_Class
{
    class Database
    {
        private static string connectionString = "Server=127.0.0.1; User id=postgres; Password=123456789; Database=eclass2";

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void CreateTeam(List<string> students, string course_id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
					string team_id = RegNum.getNextValue("Team");

					string sql = "INSERT INTO teams VALUES(@team_id)";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("team_id", team_id);
					cmd.ExecuteNonQuery();

					foreach(string stu_reg_num in students)
					{
						sql = "INSERT INTO StudentsTeams VALUES(@stu_reg_num, @team_id, @course_id)";
						cmd = new NpgsqlCommand(sql, con);
						cmd.Parameters.AddWithValue("stu_reg_num", stu_reg_num);
						cmd.Parameters.AddWithValue("team_id", team_id);
						cmd.Parameters.AddWithValue("course_id", course_id);
						cmd.ExecuteNonQuery();
					}

					foreach(Project proj in GetProjectsForCourse(course_id))
					{
						sql = "INSERT INTO ProjectsOfTeam VALUES(@project_id, null, @team_id, null)";
						cmd = new NpgsqlCommand(sql, con);
						cmd.Parameters.AddWithValue("project_id", proj.getProjectID());
						cmd.Parameters.AddWithValue("team_id", team_id);
						cmd.ExecuteNonQuery();
					}

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
						returnList.Add(int.Parse(results.GetString(0).Substring(1)));
					}


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

								return null;
						}
					}
					else
					{
						MessageBox.Show("Credentials do not match. \nCheck your input and try again.");

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
						RegNum reg_num = new RegNum(results.GetString(results.GetOrdinal("reg_num")));
						string name = results.GetString(results.GetOrdinal("name"));
						string surname = results.GetString(results.GetOrdinal("surname"));
						string password = results.GetString(results.GetOrdinal("password"));
						Email email = new Email(results.GetString(results.GetOrdinal("email")));

						return UserFactory.getInstance().createUser(userType, reg_num, password, name, surname, email);

					}
					else
					{
						MessageBox.Show("No such user -- Database get user");

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

					string sql = "DELETE FROM StudentsTeams WHERE stu_reg_num=@reg_num";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("reg_num", student.registrationNumber.getRegNumString());

					cmd.ExecuteNonQuery();



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

					string sql = "DELETE FROM StudentsTeams WHERE stu_reg_num=@reg_num AND team_id=@team_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("reg_num", student.registrationNumber.getRegNumString());
					cmd.Parameters.AddWithValue("team_id", team.getTeamID());

					cmd.ExecuteNonQuery();


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
                        DateTime due_date = results.GetTimeStamp(results.GetOrdinal("due_date")).ToDateTime();

                        return new Project(projectID, name, description, max_grade, due_date);
                    }
                    else
                    {
                        MessageBox.Show("No project with id: " + projectID + " found!");

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
                        string id = results[0].ToString();
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
		public static void InsertProject(string name, string description, int max_grade, string course_id, DateTime due_date)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
					string project_id = RegNum.getNextValue("Project");
					

                    string sql = "INSERT INTO Projects VALUES(@id, @name, @description, @max_grade, @course_id, @due_date)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", project_id);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.Parameters.AddWithValue("max_grade", max_grade);
                    cmd.Parameters.AddWithValue("course_id", course_id);
                    cmd.Parameters.AddWithValue("due_date", due_date);
                    cmd.ExecuteNonQuery();

                    foreach (Team team in GetTeams(course_id))
                    {
                        string sql_temp = "INSERT INTO ProjectsOfTeam VALUES(@project_id, null, @team_id, null)";
                        NpgsqlCommand cmd_temp = new NpgsqlCommand(sql_temp, con);
                        cmd_temp.Parameters.AddWithValue("project_id", project_id);
                        cmd_temp.Parameters.AddWithValue("team_id", team.getTeamID());
                        cmd_temp.ExecuteNonQuery();
                    }

                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }
            }
        }

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteProject(string project_id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

					string sql = "DELETE FROM ProjectsOfTeam WHERE project_id = @project_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("project_id", project_id);
					cmd.ExecuteNonQuery();

                    sql = "DELETE FROM Projects WHERE id = @id";
                    cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("id", project_id);
                    cmd.ExecuteNonQuery();
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

                    return courses;

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


                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");

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
					string sql = "INSERT INTO StudentsTeams VALUES(@stu_reg_num, @team_id, @course_id)";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("stu_reg_num", student.registrationNumber.getRegNumString());
					cmd.Parameters.AddWithValue("team_id", team.getTeamID());
					cmd.Parameters.AddWithValue("course_id", course.getCourseID());
					cmd.ExecuteNonQuery();

				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
				}
			}
		}


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void UploadProject(byte[] file, string name, DateTime date, string team_id, string project_id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string sql = "SELECT project_file_id FROM Projectsofteam WHERE team_id=@team_id AND project_id=@project_id";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("team_id", team_id);
                    cmd.Parameters.AddWithValue("project_id", project_id);
                    NpgsqlDataReader results = cmd.ExecuteReader();

                    string file_id = null;
                    if (results.Read())
                    {
                        file_id = results[0].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Could not upload file");
                        return;
                    }
                    results.Close();

					if(file_id == null)
					{
						string id = RegNum.getNextValue("projectfile");

						sql = "INSERT INTO projectfiles VALUES(@id, @file, @name, @date)";
                        NpgsqlCommand cmd2 = new NpgsqlCommand(sql, con);

						cmd2.Parameters.AddWithValue("id", id);
						cmd2.Parameters.AddWithValue("file", file);
						cmd2.Parameters.AddWithValue("name", name);
						cmd2.Parameters.AddWithValue("date", date);
						cmd2.ExecuteNonQuery();

						sql = "UPDATE projectsofteam SET project_file_id=@project_file_id WHERE team_id=@team_id AND project_id=@project_id";
                        NpgsqlCommand cmd3 = new NpgsqlCommand(sql, con);
						cmd3.Parameters.AddWithValue("project_file_id", id);
						cmd3.Parameters.AddWithValue("team_id", team_id);
						cmd3.Parameters.AddWithValue("project_id", project_id);
						cmd3.ExecuteNonQuery();

					}
					else
					{ 
						sql = "UPDATE projectfiles SET (file, name, date)=(@file, @name, @date) WHERE id=@id";
                        NpgsqlCommand cmd4 = new NpgsqlCommand(sql, con);

						cmd4.Parameters.AddWithValue("file", file);
						cmd4.Parameters.AddWithValue("name", name);
						cmd4.Parameters.AddWithValue("date", date);
						cmd4.Parameters.AddWithValue("id", file_id);
						cmd4.ExecuteNonQuery();
					}

                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }

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

                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                }

            }
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static List<Team> GetTeams(string courseID)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "select distinct teams.id from teams inner join StudentsTeams on teams.id=StudentsTeams.team_id where course_id=@courseID";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("courseID", courseID);
                    NpgsqlDataReader results = cmd.ExecuteReader();

                    List<Team> teams = new List<Team>();
                    while (results.Read())
                    {
                        teams.Add(new Team(results[0].ToString(), getStudentsOfTeam(results[0].ToString()), GetTeamsProjectFiles(results[0].ToString())));

                    }

                    return teams;
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());
                    return null;
                }

            }
        }


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

                    return dict;
                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());
                    return null;
                }
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
                        Console.Write(results[0].ToString());
                        Console.Write((byte[])results[1]);
                        Console.Write(results[2].ToString());
                        Console.Write(GetGrade(teamID, projectID));
                        Console.Write(DateTime.Parse(results[3].ToString()));



                        return new ProjectFile(results[0].ToString(), (byte[])results[1], results[2].ToString(),GetGrade(teamID, projectID), DateTime.Parse(results[3].ToString()));

                    }
                    else
                    {

                        return null;
                    }

                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());

                    return null;

                }
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
                        if (results[0] is null)
                        {
                            return -1;
                        }
                        else
                        {
                            return int.Parse(results[0].ToString());
                        }
                        
                    }
                    else
                    {
                        return -1;
                    }

                }
                catch (Exception msg)
                {
                    MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
                    MessageBox.Show(msg.ToString());

                    return -1;
                }
            }

        }

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static List<Student> getStudentsOfTeam(string team_id)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql = "SELECT stu_reg_num FROM StudentsTeams WHERE team_id=@team_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

					cmd.Parameters.AddWithValue("team_id", team_id);
					NpgsqlDataReader results = cmd.ExecuteReader();

					List<Student> returnList = new List<Student>();
					while (results.Read())
					{
						returnList.Add((Student)(Database.GetUser("student", results.GetString(0))));
					}

					return returnList;
				}
				catch (Exception msg)
				{
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					MessageBox.Show(msg.ToString());
					return null;
				}

			}
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void EditTeam(string team_id, string course_id, List<string> teamsStudents)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql = "DELETE FROM StudentsTeams WHERE team_id=@team_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("team_id", team_id);
					cmd.ExecuteNonQuery();

					foreach(string student_reg_num in teamsStudents)
					{
						sql = "INSERT INTO StudentsTeams VALUES(@stu_reg_num, @team_id, @course_id)";
						cmd = new NpgsqlCommand(sql, con);
						cmd.Parameters.AddWithValue("stu_reg_num", student_reg_num);
						cmd.Parameters.AddWithValue("team_id", team_id);
						cmd.Parameters.AddWithValue("course_id", course_id);
						cmd.ExecuteNonQuery();
					}
				}
				catch (Exception msg)
				{
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					MessageBox.Show(msg.ToString());
				}


			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void DeleteTeam(string team_id)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql = "DELETE FROM StudentsTeams WHERE team_id=@team_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("team_id", team_id);
					cmd.ExecuteNonQuery();

					sql = "DELETE FROM ProjectsOfTeam WHERE team_id=@team_id";
					cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("team_id", team_id);
					cmd.ExecuteNonQuery();

					sql = "DELETE FROM Teams WHERE id=@team_id";
					cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("team_id", team_id);
					cmd.ExecuteNonQuery();
				}
				catch (Exception msg)
				{
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					MessageBox.Show(msg.ToString());
				}

			}
		}


        public static Dictionary<string, string> getAllCourses()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM Courses";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader results = cmd.ExecuteReader();
                    Dictionary<string, string> courses = new Dictionary<string, string>();
                    while (results.Read())
                    {
                        courses.Add(results[0].ToString(), results[1].ToString());
                    }
                    return courses;
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
		public static void DownloadProject(string project_id, string team_id)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					byte[] downloadedFile = null;
					string path = Path.GetDirectoryName(Application.ExecutablePath);
					con.Open();
					string sql = "SELECT * FROM ProjectFiles WHERE id=(SELECT project_file_id FROM ProjectsOfTeam WHERE project_id=@project_id AND team_id=@team_id)";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("project_id", project_id);
					cmd.Parameters.AddWithValue("team_id", team_id);
					NpgsqlDataReader results = cmd.ExecuteReader();
					while (results.Read())
					{
						downloadedFile = (byte[])results["file"];
					}

					File.WriteAllBytes(@path + "//" + results["name"], downloadedFile);
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
				}
			}
		}


		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void EditProject(string project_id, string name, string description, int max_grade, DateTime due_date)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql = "UPDATE Projects SET (name, description, max_grade, due_date) = (@name, @description, @max_grade, @due_date) WHERE id=@id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("id", project_id);
					cmd.Parameters.AddWithValue("name", name);
					cmd.Parameters.AddWithValue("description", description);
					cmd.Parameters.AddWithValue("max_grade", max_grade);
					cmd.Parameters.AddWithValue("due_date", due_date);
					cmd.ExecuteNonQuery();
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
				}
			}
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static Team GetTeamOfStudent(Student student, string course_id)
		{
			using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
			{
				try
				{
					con.Open();
					string sql = "SELECT team_id FROM StudentsTeams WHERE stu_reg_num=@stu_reg_num AND course_id=@course_id";
					NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
					cmd.Parameters.AddWithValue("stu_reg_num", student.registrationNumber.getRegNumString());
					cmd.Parameters.AddWithValue("course_id", course_id);
					NpgsqlDataReader results = cmd.ExecuteReader();
					if (results.Read())
						return new Team(results[0].ToString(), getStudentsOfTeam(results[0].ToString()), GetTeamsProjectFiles(results[0].ToString()));
					else
						return null;
				}
				catch (Exception msg)
				{
					MessageBox.Show(msg.ToString());
					MessageBox.Show("There was a problem while executing this action. Please contact the developers.");
					return null;
				}
			}
		}

	}
}
