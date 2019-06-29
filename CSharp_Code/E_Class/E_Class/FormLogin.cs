﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Types;

namespace E_Class
{
    public partial class FormLogin : Form
    {
    

		private AbstractFormFactory formFactory;

		public FormLogin()
        {
            InitializeComponent();
			formFactory = new UserFormFactory();
        }

        private void login(string username, string password)
        {
            string user = Database.ValidateCredentials(username, password);
            if (user != null)
            {
                this.Hide();
                formFactory.createForm(user, username).Show();
            }
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
            login(UsernameBox.Text, PasswordBox.Text);
        }


        

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
			Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.GetTeamsProjectFiles("T3");
        }
    }
}
