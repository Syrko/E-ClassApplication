using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
    class Professor : User
    {
		// User-inherited properties
		public override RegNum registrationNumber
		{
			get
			{
				return registrationNumber;
			}
			set { }
		}
		public override string password
		{
			get
			{
				return password;
			}
			set { }
		}
		public override string name
		{
			get
			{
				return name;
			}
			set { }
		}
		public override string surname
		{
			get
			{
				return surname;
			}
			set { }
		}
		public override Email email
		{
			get
			{
				return email;
			}
			set { }
		}

		// Fields
		private List<Course> courseList;

		// Constructors
		public Professor(RegNum registrationNumber, string password, string name, string surname, Email email, List<Course> courseList)
		{
			this.registrationNumber = registrationNumber;
			this.password = password;
			this.name = name;
			this.surname = surname;
			this.email = email;

			this.courseList = courseList;
		}

		// Methods
		public void createProject(string name, string description, int max_grade) { Database.InsertProject(name, description, max_grade); }
		public void editProject(Project project) { throw new NotImplementedException(); }
		public void deleteProject(Project project) { Database.DeleteProject(project); }
		public void createTeam(Team newTeam) { throw new NotImplementedException(); }
		public void editTeam(Team team) { throw new NotImplementedException(); }
		public void deleteTeam(Team team) { throw new NotImplementedException(); }
		public void gradeProject(Project project) { throw new NotImplementedException(); }


		// Setters - Getters
		public List<Course> getCourseList() { return courseList; }
		public void setCourseList(List<Course> courseList) { this.courseList = courseList; }
	}
}
