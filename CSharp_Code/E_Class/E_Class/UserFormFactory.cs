using System.Windows.Forms;
using Types;

namespace E_Class
{
	// Form factory used to produce user specific forms
	class UserFormFactory : AbstractFormFactory
	{
		public override Form createForm(string userType, string reg_num, FormLogin login)
		{
			switch (userType)
			{
				case UserTypes.STUDENT:
					return new FormStudent(reg_num, login);
				case UserTypes.PROFESSOR:
					return new FormProfessor(reg_num, login);
				case UserTypes.ADMIN:
					return new FormAdmin(reg_num, login);
				default:
					// TODO Display error message
					return null;
			}
		}
	}
}
