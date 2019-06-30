using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
    class Professor : User
    {
        // User-inherited properties
        private RegNum _registrationNumber;
        private string _password;
        private string _name;
        private string _surname;
        private Email _email;

        // User-inherited properties
        public override RegNum registrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                _registrationNumber = value;
            }
        }
        public override string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public override string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public override Email email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        // Fields
        private List<Course> courseList;

		// Constructors
		public Professor(RegNum registrationNumber, string password, string name, string surname, Email email, List<Course> courseList)
		{
			this._registrationNumber = registrationNumber;
			this._password = password;
			this._name = name;
			this._surname = surname;
			this._email = email;

			this.courseList = courseList;
		}

		// Methods
		public void createProject(string name, string description, int max_grade, string course_id, DateTime due_date) { Database.InsertProject(name, description, max_grade, course_id, due_date); }
		public void editProject(Project project) { throw new NotImplementedException(); }
		public void deleteProject(string project_id) { Database.DeleteProject(project_id); }
		public void createTeam(List<string> students, string newTeam) { Database.CreateTeam(students, newTeam); }
		public void editTeam( string team_id, string course_id, List<string> teamStudents) { Database.EditTeam(team_id, course_id, teamStudents); }
		public void deleteTeam(string team_id) { Database.DeleteTeam(team_id); }
		public void gradeProject(Project project) { throw new NotImplementedException(); }


		// Setters - Getters
		public List<Course> getCourseList() { return courseList; }
		public void setCourseList(List<Course> courseList) { this.courseList = courseList; }
	}
}
