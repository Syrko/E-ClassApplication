using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using System.Text;
using System.Security.Permissions;


namespace E_Class
{
    public partial class FormStudent : UserForm
    {

        private byte[] FileInBytes;
        FormLogin login;

        // Inherited properties
        protected override User currentUser { get; set; }
		// Inherited methods
		public override void logout()
		{
			this.Close();
		}

        string SelectedCourse;
        Student user;

        public FormStudent(string reg_num, FormLogin login)
        {
            InitializeComponent();

            this.login = login;
            //Courses List: A list that displays professor's courses
            CoursesList.Bounds = new Rectangle(new Point(450, 50), new Size(275, 400));
            CoursesList.View = View.Details;
            CoursesList.FullRowSelect = true;
            CoursesList.GridLines = true;
            CoursesList.Sorting = SortOrder.Ascending;
            CoursesList.Columns.Add("Select a course to continue", -2, HorizontalAlignment.Center);
            CoursesList.Columns.Add("Course ID", -2, HorizontalAlignment.Center);

            currentUser = Database.GetUser("student", reg_num);
            user = (Student)currentUser;

            Dictionary<string, string> Courses = Database.getAllCourses();
            foreach (KeyValuePair<string, string> course in Courses)
            {
                var row = new String[]
                {
                    course.Value
                    , course.Key
                };
                var listViewItem = new ListViewItem(row);
                CoursesList.Items.Add(listViewItem);
            }



            SelectedCourseLabel.Location = new Point(475, 20);
            SelectCourseBtn.Location = new Point(551, 458);
            //==============================================================================


            //========================================================================
            ProjectsList.Bounds = new Rectangle(new Point(150, 12), new Size(275, 500));
            ProjectsList.View = View.Details;
            ProjectsList.FullRowSelect = true;
            ProjectsList.GridLines = true;
            ProjectsList.Sorting = SortOrder.Ascending;
            ProjectsList.Columns.Add("Project", -2, HorizontalAlignment.Left);
            ProjectsList.Columns.Add("Sent", -2, HorizontalAlignment.Left);
            ProjectsList.Columns.Add("Grade", -2, HorizontalAlignment.Left);


            


            //==============================================================

            ProjectsList.Hide();
            UploadGroupBox.Hide();

            CoursesList.Show();
            SelectCourseBtn.Show();
            SelectCourseMnBtn.BackColor = Color.FromArgb(66, 131, 178);

            UploadGroupBox.Location = new Point(450, 12);

            ProjectsMnBtn.Enabled = false;

            UploadGroupBox.Paint += Paint;

        }

        private void Paint(object sender, PaintEventArgs p)
        {
            Brush backCol = new SolidBrush(Color.FromArgb(200, 255, 255, 255));
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(SystemColors.Control);//Clear system colors
            p.Graphics.FillRectangle(backCol, this.ClientRectangle);//Paint white background
            DrawGroupBox(box, p.Graphics, Color.Black, Color.Black);//Draw Borders
        }


        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);
                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);
                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void YouAreHere(Button pressedBtn)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (pressedBtn.Text == btn.Text)
                {
                    pressedBtn.BackColor = Color.FromArgb(66, 131, 178);
                }
                else
                {
                    if (btn.Name.Contains("MnBtn"))
                    {
                        btn.BackColor = Color.FromArgb(66, 103, 178);
                    }

                }
            }
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileNameLabel.Text = openFileDialog.FileName;
                FileInBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
            }
        }



        private void SelectCourseMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(SelectCourseMnBtn);

            CoursesList.Show();
            SelectCourseBtn.Show();
            SelectedCourseLabel.Show();

            ProjectsList.Hide();
            UploadGroupBox.Hide();


        }

        private void ProjectsMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(ProjectsMnBtn);

            CoursesList.Hide();
            SelectCourseBtn.Hide();
            SelectedCourseLabel.Hide();

            label11.Text = CoursesList.SelectedItems[0].Text;

            UpdateProjectList();

            ProjectsList.Show();
            UploadGroupBox.Show();
        }

        public void UpdateProjectList()
        {

            List<Project> res = Database.GetProjectsForCourse(SelectedCourse);
            foreach (Project proj in res)
            {
                Team team = Database.GetTeamOfStudent(user, SelectedCourse);
                MessageBox.Show(team.getTeamID());
                string sent = "-";
                string grade = "-";
                

                if(team != null)
                {
                    if (Database.GetFileDetails(team.getTeamID(), proj.getProjectID()) != null)
                    {
                        MessageBox.Show(Database.GetFileDetails(team.getTeamID(), proj.getProjectID()).getName());
                        sent = "Yes";
                    }
                    grade = Database.GetGrade(team.getTeamID(), proj.getProjectID()).ToString();
                    if (int.Parse(grade) == -1)
                    {
                        grade = "-";
                    }
                }
                

                var row = new String[]
                {
                proj.getname()
                , sent
                , grade
                };
                var ProjectlistViewItem = new ListViewItem(row);
                ProjectsList.Items.Add(ProjectlistViewItem);
            }

            /*Project proj = Database.GetProject("P1");
            label6.Text = proj.getDueDate().ToString();
            DescriptionArea.Text = proj.getdescription();*/

        }

        private void SelectCourseBtn_Click(object sender, EventArgs e)
        {
            if (CoursesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a course to continue.", "No selection", MessageBoxButtons.OK);
            }
            else
            {
                SelectedCourse = CoursesList.SelectedItems[0].SubItems[1].Text;
                SelectedCourseLabel.Text = CoursesList.SelectedItems[0].Text + " is selected";
                ProjectsMnBtn.Enabled = true;
                ProjectsMnBtn.PerformClick();
            }
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {

        }



        

        private void FormStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
			login.Show();
		}

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
			logout();
        }
           
    }
}
