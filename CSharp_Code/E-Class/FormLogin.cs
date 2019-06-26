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
    public partial class FormLogin : Form
    {
        private static int gammaA = 255;
        public FormLogin()
        {
            InitializeComponent();
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
            //AdminForm form = new AdminForm();
            //form.ShowDialog();
        }


        private void LoginAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.ShowDialog();
        }

        private void LoginProf_Click(object sender, EventArgs e)
        {
            FormProfessor form = new FormProfessor();
            form.ShowDialog();
        }

        private void LoginStudent_Click(object sender, EventArgs e)
        {
            FormStudent form = new FormStudent();
            form.ShowDialog();
        }
    }
}
