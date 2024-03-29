﻿namespace E_Class
{
    partial class FormStudent
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
            this.label1 = new System.Windows.Forms.Label();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.ProjectsList = new System.Windows.Forms.ListView();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.UploadGroupBox = new System.Windows.Forms.GroupBox();
            this.MsgLabel = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DueDateLabel = new System.Windows.Forms.Label();
            this.ProjectNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectCourseMnBtn = new System.Windows.Forms.Button();
            this.ProjectsMnBtn = new System.Windows.Forms.Button();
            this.CoursesList = new System.Windows.Forms.ListView();
            this.SelectedCourseLabel = new System.Windows.Forms.Label();
            this.SelectCourseBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.UploadGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.label1.Location = new System.Drawing.Point(-4, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 543);
            this.label1.TabIndex = 15;
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.LogoutBtn.FlatAppearance.BorderSize = 0;
            this.LogoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBtn.ForeColor = System.Drawing.Color.White;
            this.LogoutBtn.Location = new System.Drawing.Point(-5, 477);
            this.LogoutBtn.Margin = new System.Windows.Forms.Padding(2);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(148, 64);
            this.LogoutBtn.TabIndex = 23;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = false;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // ProjectsList
            // 
            this.ProjectsList.Location = new System.Drawing.Point(210, 423);
            this.ProjectsList.Name = "ProjectsList";
            this.ProjectsList.Size = new System.Drawing.Size(121, 97);
            this.ProjectsList.TabIndex = 24;
            this.ProjectsList.UseCompatibleStateImageBehavior = false;
            this.ProjectsList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjectsList_MouseClick);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BrowseBtn.Location = new System.Drawing.Point(58, 220);
            this.BrowseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(106, 25);
            this.BrowseBtn.TabIndex = 12;
            this.BrowseBtn.Text = "Browse...";
            this.BrowseBtn.UseVisualStyleBackColor = false;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // UploadBtn
            // 
            this.UploadBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadBtn.Location = new System.Drawing.Point(58, 249);
            this.UploadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(106, 29);
            this.UploadBtn.TabIndex = 31;
            this.UploadBtn.Text = "Upload";
            this.UploadBtn.UseVisualStyleBackColor = false;
            this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // UploadGroupBox
            // 
            this.UploadGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UploadGroupBox.BackColor = System.Drawing.Color.White;
            this.UploadGroupBox.Controls.Add(this.MsgLabel);
            this.UploadGroupBox.Controls.Add(this.DescriptionBox);
            this.UploadGroupBox.Controls.Add(this.FileNameLabel);
            this.UploadGroupBox.Controls.Add(this.label8);
            this.UploadGroupBox.Controls.Add(this.DueDateLabel);
            this.UploadGroupBox.Controls.Add(this.ProjectNameLabel);
            this.UploadGroupBox.Controls.Add(this.label4);
            this.UploadGroupBox.Controls.Add(this.label3);
            this.UploadGroupBox.Controls.Add(this.label2);
            this.UploadGroupBox.Controls.Add(this.UploadBtn);
            this.UploadGroupBox.Controls.Add(this.BrowseBtn);
            this.UploadGroupBox.Controls.Add(this.label7);
            this.UploadGroupBox.Controls.Add(this.label10);
            this.UploadGroupBox.Location = new System.Drawing.Point(530, 25);
            this.UploadGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.UploadGroupBox.Name = "UploadGroupBox";
            this.UploadGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.UploadGroupBox.Size = new System.Drawing.Size(483, 310);
            this.UploadGroupBox.TabIndex = 33;
            this.UploadGroupBox.TabStop = false;
            // 
            // MsgLabel
            // 
            this.MsgLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MsgLabel.Location = new System.Drawing.Point(152, 15);
            this.MsgLabel.Name = "MsgLabel";
            this.MsgLabel.Size = new System.Drawing.Size(161, 24);
            this.MsgLabel.TabIndex = 44;
            this.MsgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(22, 84);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(424, 81);
            this.DescriptionBox.TabIndex = 43;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.FileNameLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(170, 226);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(87, 14);
            this.FileNameLabel.TabIndex = 40;
            this.FileNameLabel.Text = "No file selected.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(19, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "File:";
            // 
            // DueDateLabel
            // 
            this.DueDateLabel.AutoSize = true;
            this.DueDateLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DueDateLabel.Location = new System.Drawing.Point(79, 186);
            this.DueDateLabel.Name = "DueDateLabel";
            this.DueDateLabel.Size = new System.Drawing.Size(0, 13);
            this.DueDateLabel.TabIndex = 37;
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.AutoSize = true;
            this.ProjectNameLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ProjectNameLabel.Location = new System.Drawing.Point(92, 40);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(0, 13);
            this.ProjectNameLabel.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(19, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Due date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Descripition:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(19, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Project name:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(473, 201);
            this.label7.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(5, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(473, 95);
            this.label10.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(-5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 64);
            this.label11.TabIndex = 43;
            this.label11.Text = "No course selected";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // SelectCourseMnBtn
            // 
            this.SelectCourseMnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.SelectCourseMnBtn.FlatAppearance.BorderSize = 0;
            this.SelectCourseMnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectCourseMnBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectCourseMnBtn.ForeColor = System.Drawing.Color.White;
            this.SelectCourseMnBtn.Location = new System.Drawing.Point(-5, 66);
            this.SelectCourseMnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SelectCourseMnBtn.Name = "SelectCourseMnBtn";
            this.SelectCourseMnBtn.Size = new System.Drawing.Size(148, 64);
            this.SelectCourseMnBtn.TabIndex = 34;
            this.SelectCourseMnBtn.Text = "Courses";
            this.SelectCourseMnBtn.UseVisualStyleBackColor = false;
            this.SelectCourseMnBtn.Click += new System.EventHandler(this.SelectCourseMnBtn_Click);
            // 
            // ProjectsMnBtn
            // 
            this.ProjectsMnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.ProjectsMnBtn.FlatAppearance.BorderSize = 0;
            this.ProjectsMnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProjectsMnBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectsMnBtn.ForeColor = System.Drawing.Color.White;
            this.ProjectsMnBtn.Location = new System.Drawing.Point(-5, 126);
            this.ProjectsMnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectsMnBtn.Name = "ProjectsMnBtn";
            this.ProjectsMnBtn.Size = new System.Drawing.Size(148, 64);
            this.ProjectsMnBtn.TabIndex = 35;
            this.ProjectsMnBtn.Text = "Projects";
            this.ProjectsMnBtn.UseVisualStyleBackColor = false;
            this.ProjectsMnBtn.Click += new System.EventHandler(this.ProjectsMnBtn_Click);
            // 
            // CoursesList
            // 
            this.CoursesList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CoursesList.Location = new System.Drawing.Point(337, 423);
            this.CoursesList.Name = "CoursesList";
            this.CoursesList.Size = new System.Drawing.Size(121, 97);
            this.CoursesList.TabIndex = 36;
            this.CoursesList.UseCompatibleStateImageBehavior = false;
            // 
            // SelectedCourseLabel
            // 
            this.SelectedCourseLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SelectedCourseLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedCourseLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedCourseLabel.Location = new System.Drawing.Point(480, 496);
            this.SelectedCourseLabel.Name = "SelectedCourseLabel";
            this.SelectedCourseLabel.Size = new System.Drawing.Size(220, 20);
            this.SelectedCourseLabel.TabIndex = 43;
            this.SelectedCourseLabel.Text = "No selected course";
            this.SelectedCourseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectCourseBtn
            // 
            this.SelectCourseBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SelectCourseBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectCourseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectCourseBtn.Location = new System.Drawing.Point(538, 453);
            this.SelectCourseBtn.Name = "SelectCourseBtn";
            this.SelectCourseBtn.Size = new System.Drawing.Size(90, 40);
            this.SelectCourseBtn.TabIndex = 42;
            this.SelectCourseBtn.Text = "Select";
            this.SelectCourseBtn.UseVisualStyleBackColor = false;
            this.SelectCourseBtn.Click += new System.EventHandler(this.SelectCourseBtn_Click);
            // 
            // FormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1024, 532);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SelectedCourseLabel);
            this.Controls.Add(this.SelectCourseBtn);
            this.Controls.Add(this.CoursesList);
            this.Controls.Add(this.ProjectsMnBtn);
            this.Controls.Add(this.SelectCourseMnBtn);
            this.Controls.Add(this.UploadGroupBox);
            this.Controls.Add(this.ProjectsList);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1040, 570);
            this.Name = "FormStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormStudent_FormClosed);
            this.UploadGroupBox.ResumeLayout(false);
            this.UploadGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.ListView ProjectsList;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.GroupBox UploadGroupBox;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label DueDateLabel;
        private System.Windows.Forms.Label ProjectNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button SelectCourseMnBtn;
        private System.Windows.Forms.Button ProjectsMnBtn;
        private System.Windows.Forms.ListView CoursesList;
        private System.Windows.Forms.Label SelectedCourseLabel;
        private System.Windows.Forms.Button SelectCourseBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label MsgLabel;
    }
}