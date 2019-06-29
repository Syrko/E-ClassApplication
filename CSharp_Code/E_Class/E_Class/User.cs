namespace E_Class
{
	// Base class of all users with the necessary properties
	public abstract class User
	{
		public abstract RegNum registrationNumber
		{
			get;
			set;
		}
		public abstract string password
		{
			get;
			set;
		}
		public abstract string name
		{
			get;
			set;
		}
		public abstract string surname
		{
			get;
			set;
		}
		public abstract Email email
		{
			get;
			set;
		}
	}
}
