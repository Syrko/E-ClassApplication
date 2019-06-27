using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Class
{
	public partial class UserForm : Form
	{
		public UserForm()
		{
			InitializeComponent();
		}
		protected virtual User currentUser
		{
				get;
				set;
		}

		public virtual void logout()
		{

		}
	}
}
