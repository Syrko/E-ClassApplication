using Types;

namespace E_Class
{
	// Singleton User Factory Class for producing users of various types
	class UserFactory
	{
		private static UserFactory instance;

		public static UserFactory getInstance()
		{
			if(instance == null)
			{
				instance = new UserFactory();
			}
			return instance;
		}

		// Make default constructor private
		private UserFactory() { }

		// TODO remove static from createUser in class diagram
		public User createUser(string userType, RegNum reg_num, string password, string name, string surname, Email email)
		{
			
			switch (userType)
			{
				case UserTypes.STUDENT:
					return new Student(reg_num, password, name, surname, email);
				case UserTypes.PROFESSOR:
					//return new Professor(reg_num, password, name, surname, email, ); TODO
				case UserTypes.ADMIN:
					return new Admin(reg_num, password, name, surname, email);
				default:
					// TODO display error message
					return null;
			}
		}
	}
}
