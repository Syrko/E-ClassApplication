﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
    class Professor : User
    {
		// User-inherited properties
		protected override RegNum registrationNumber
		{
			get
			{
				return registrationNumber;
			}
			set { }
		}
		protected override string password
		{
			get
			{
				return password;
			}
			set { }
		}
		protected override string name
		{
			get
			{
				return name;
			}
			set { }
		}
		protected override string surname
		{
			get
			{
				return surname;
			}
			set { }
		}
		protected override Email email
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
		public void createProject(Project newProject);
		public void editProject(Project project);
		public void deleteProject(Project project);
		public void createTeam(Team newTeam);
		public void editTeam(Team team);
		public void deleteTeam(Team team);
		public void gradeProject(Project project);
		
		// Setters - Getters
		public List<Course> getCourseList() { return courseList; }
		public void setCourseList(List<Course> courseList) { this.courseList = courseList; }
	}
}
