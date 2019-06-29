using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
    class Admin : User
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


		// Constructors
		public Admin(RegNum registrationNumber, string password, string name, string surname, Email email)
		{
			this.registrationNumber = registrationNumber;
			this.password = password;
			this.name = name;
			this.surname = surname;
			this.email = email;
		}

		// Methods
		public bool createUser(User newUser) { throw new NotImplementedException(); }
		public bool editUser(User user) { throw new NotImplementedException(); }
		public bool deleteUser(User user) { throw new NotImplementedException(); }
		public bool createCourse(Course newCourse) { throw new NotImplementedException(); }
		public bool editCourse(Course course) { throw new NotImplementedException(); }
		public bool deleteCourse(Course course) { throw new NotImplementedException(); }

	}
}
