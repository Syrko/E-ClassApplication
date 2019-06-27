using System;
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

		// Methods

	}
}
