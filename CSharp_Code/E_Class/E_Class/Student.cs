using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
	class Student : User
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

		// Constructors
		public Student(RegNum registrationNumber, string password, string name, string surname, Email email)
		{
			this.registrationNumber = registrationNumber;
			this.password = password;
			this.name = name;
			this.surname = surname;
			this.email = email;
		}

		// Methods
		public void uploadProjectFile(ProjectFile projectToUpload);
		public void viewCourseGrades(Course course);
	}
}
