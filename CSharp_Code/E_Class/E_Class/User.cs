namespace E_Class
{
	// Base class of all users with the necessary properties
	abstract class User
	{
		protected abstract RegNum registrationNumber
		{
			get;
			set;
		}
		protected abstract string password
		{
			get;
			set;
		}
		protected abstract string name
		{
			get;
			set;
		}
		protected abstract string surname
		{
			get;
			set;
		}
		protected abstract Email email
		{
			get;
			set;
		}
	}
}
