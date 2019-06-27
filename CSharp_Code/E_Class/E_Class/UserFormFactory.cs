using System.Windows.Forms;
using Types;

namespace E_Class
{
	// Form factory used to produce user specific forms
	class UserFormFactory : AbstractFormFactory
	{
		public override Form createForm(string userType)
		{
			switch (userType)
			{
				case UserTypes.STUDENT:
					return new FormStudent();
				case UserTypes.PROFESSOR:
					return new FormProfessor();
				case UserTypes.ADMIN:
					return new FormAdmin();
				default:
					// TODO Display error message
					return null;
			}
		}
	}
}
