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
	public abstract partial class UserForm : Form
	{
		public UserForm()
		{
			InitializeComponent();
		}
		protected abstract User currentUser
		{
				get;
				set;
		}

		public abstract void logout();
	}
}
