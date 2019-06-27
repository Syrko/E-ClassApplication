using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
	class Student : User
	{
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


	}
}
