
using System.Windows.Forms;

namespace E_Class
{
	// An abstract for all form factories
	abstract class AbstractFormFactory
	{
		// TODO Make createForm abstract in class diagram
		public abstract Form createForm(string type, string reg_num, FormLogin login);
	}
}
