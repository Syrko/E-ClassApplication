using System;
using System.Drawing;
using System.Windows.Forms;
using Types;

namespace E_Class
{
    public partial class FormLogin : Form
    {
		private static int gammaA = 255;

		private AbstractFormFactory formFactory;

		public FormLogin()
        {
            InitializeComponent();
			formFactory = new UserFormFactory();
        }

        private void LogInBtn_Enter(object sender, EventArgs e)
        {
            LogInBtn.Font = new Font("Calibri", 11, FontStyle.Regular);
        }

        private void LogInBtn_Leave(object sender, EventArgs e)
        {
            LogInBtn.Font = new Font("Calibri", 10, FontStyle.Regular);
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdminForm form = new AdminForm();
            //form.ShowDialog();
        }


        private void LoginAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdmin form = new FormAdmin();
            form.ShowDialog();
        }

        private void LoginProf_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfessor form = new FormProfessor();
            form.ShowDialog();
        }

        private void LoginStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStudent form = new FormStudent();
            form.Show();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
			Application.Exit();
        }
    }
}
