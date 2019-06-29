using System.Windows.Forms;
using Types;

namespace E_Class
{
	// Form factory used to produce user specific forms
	class UserFormFactory : AbstractFormFactory
	{
		public override Form createForm(string userType, string reg_num)
		{
			switch (userType)
			{
				case UserTypes.STUDENT:
					return new FormStudent(reg_num);
				case UserTypes.PROFESSOR:
					return new FormProfessor(reg_num);
				case UserTypes.ADMIN:
					return new FormAdmin(reg_num);
				default:
					// TODO Display error message
					return null;
			}
		}
	}
}
