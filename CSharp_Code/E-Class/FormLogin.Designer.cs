namespace E_Class
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.Container = new System.Windows.Forms.Label();
            this.LogInBtn = new System.Windows.Forms.Button();
            this.LoginAdmin = new System.Windows.Forms.Button();
            this.LoginProf = new System.Windows.Forms.Button();
            this.LoginStudent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(225, 91);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(170, 20);
            this.UsernameBox.TabIndex = 0;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(225, 149);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(170, 20);
            this.PasswordBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(193)))), ((int)(((byte)(220)))));
            this.NameLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(280, 72);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(66, 17);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Username";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(193)))), ((int)(((byte)(220)))));
            this.PassLabel.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassLabel.Location = new System.Drawing.Point(280, 129);
            this.PassLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(61, 17);
            this.PassLabel.TabIndex = 3;
            this.PassLabel.Text = "Password";
            // 
            // Container
            // 
            this.Container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(193)))), ((int)(((byte)(220)))));
            this.Container.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Container.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Container.Location = new System.Drawing.Point(179, 45);
            this.Container.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(256, 233);
            this.Container.TabIndex = 5;
            // 
            // LogInBtn
            // 
            this.LogInBtn.BackColor = System.Drawing.Color.Transparent;
            this.LogInBtn.FlatAppearance.BorderSize = 0;
            this.LogInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInBtn.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInBtn.Location = new System.Drawing.Point(225, 224);
            this.LogInBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LogInBtn.Name = "LogInBtn";
            this.LogInBtn.Size = new System.Drawing.Size(169, 29);
            this.LogInBtn.TabIndex = 6;
            this.LogInBtn.Text = "Log In";
            this.LogInBtn.UseVisualStyleBackColor = false;
            this.LogInBtn.Click += new System.EventHandler(this.LogInBtn_Click);
            this.LogInBtn.MouseEnter += new System.EventHandler(this.LogInBtn_Enter);
            this.LogInBtn.MouseLeave += new System.EventHandler(this.LogInBtn_Leave);
            // 
            // LoginAdmin
            // 
            this.LoginAdmin.BackColor = System.Drawing.Color.LightSalmon;
            this.LoginAdmin.FlatAppearance.BorderSize = 0;
            this.LoginAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginAdmin.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginAdmin.Location = new System.Drawing.Point(56, 291);
            this.LoginAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.LoginAdmin.Name = "LoginAdmin";
            this.LoginAdmin.Size = new System.Drawing.Size(115, 45);
            this.LoginAdmin.TabIndex = 9;
            this.LoginAdmin.Text = "Admin";
            this.LoginAdmin.UseVisualStyleBackColor = false;
            this.LoginAdmin.Click += new System.EventHandler(this.LoginAdmin_Click);
            // 
            // LoginProf
            // 
            this.LoginProf.BackColor = System.Drawing.Color.LightSalmon;
            this.LoginProf.FlatAppearance.BorderSize = 0;
            this.LoginProf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginProf.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginProf.Location = new System.Drawing.Point(249, 291);
            this.LoginProf.Margin = new System.Windows.Forms.Padding(2);
            this.LoginProf.Name = "LoginProf";
            this.LoginProf.Size = new System.Drawing.Size(115, 45);
            this.LoginProf.TabIndex = 10;
            this.LoginProf.Text = "Professor";
            this.LoginProf.UseVisualStyleBackColor = false;
            this.LoginProf.Click += new System.EventHandler(this.LoginProf_Click);
            // 
            // LoginStudent
            // 
            this.LoginStudent.BackColor = System.Drawing.Color.LightSalmon;
            this.LoginStudent.FlatAppearance.BorderSize = 0;
            this.LoginStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginStudent.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginStudent.Location = new System.Drawing.Point(445, 291);
            this.LoginStudent.Margin = new System.Windows.Forms.Padding(2);
            this.LoginStudent.Name = "LoginStudent";
            this.LoginStudent.Size = new System.Drawing.Size(115, 45);
            this.LoginStudent.TabIndex = 11;
            this.LoginStudent.Text = "Student";
            this.LoginStudent.UseVisualStyleBackColor = false;
            this.LoginStudent.Click += new System.EventHandler(this.LoginStudent_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(616, 382);
            this.Controls.Add(this.LoginStudent);
            this.Controls.Add(this.LogInBtn);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.LoginAdmin);
            this.Controls.Add(this.LoginProf);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(632, 420);
            this.MinimumSize = new System.Drawing.Size(632, 420);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label Container;
        private System.Windows.Forms.Button LogInBtn;
        private System.Windows.Forms.Button LoginAdmin;
        private System.Windows.Forms.Button LoginProf;
        private System.Windows.Forms.Button LoginStudent;
    }
}

