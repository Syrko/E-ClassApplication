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
		public User createUser(string userType)
		{
			switch (userType)
			{
				case UserTypes.STUDENT:
					return new Student();
				case UserTypes.PROFESSOR:
					return new Professor();
				case UserTypes.ADMIN:
					return new Admin();
				default:
					// TODO display error message
					return null;
			}
		}
	}
}
