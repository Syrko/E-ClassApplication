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
    public partial class FormProfessor : Form
    {

        public FormProfessor()
        {
            InitializeComponent();
            ChooseCourseMnBtn.BackColor = Color.FromArgb(100, 10, 10, 10);
            ModifyProjectMnBtn.BackColor = Color.FromArgb(100, 10, 10, 10);
            ModifyTeamMnBtn.BackColor = Color.FromArgb(100, 10, 10, 10);
            AssignProjectMnBtn.BackColor = Color.FromArgb(100, 10, 10, 10);
            GradeProjectsMnBtn.BackColor = Color.FromArgb(100, 10, 10, 10);
            label1.BackColor = Color.FromArgb(100, 10, 10, 10);
            LogoutBtn.BackColor = Color.FromArgb(100, 10, 10, 10);
            
            TeamGroupBox.Paint += Paint;
            ProjectGroupBox.Paint += Paint;
            GradeGroupBox.Paint += Paint;


            List<String> Courses = new List<string>();
            Courses.Add("Test Course 1");
            Courses.Add("Test Course 2");
            Courses.Add("Test Course 3");
            Courses.Add("Test Course 4");
            Courses.Add("Test Course 5");
            
            //Courses List: A list that displays professor's courses
            CoursesList.Bounds = new Rectangle(new Point(450, 50), new Size(275, 400));
            CoursesList.View = View.Details;
            CoursesList.FullRowSelect = true;
            CoursesList.GridLines = true;
            CoursesList.Sorting = SortOrder.Ascending;
            CoursesList.Columns.Add("Select a course to continue", -2, HorizontalAlignment.Center);

            var listViewItem = new ListViewItem(Courses[0]);
            CoursesList.Items.Add(listViewItem);
            listViewItem = new ListViewItem(Courses[1]);
            CoursesList.Items.Add(listViewItem);
            listViewItem = new ListViewItem(Courses[2]);
            CoursesList.Items.Add(listViewItem);
            listViewItem = new ListViewItem(Courses[3]);
            CoursesList.Items.Add(listViewItem);
            listViewItem = new ListViewItem(Courses[4]);
            CoursesList.Items.Add(listViewItem);

            SelectedCourseLabel.Location = new Point(475, 20);
            SelectCourseBtn.Location = new Point(551, 458);
            //==============================================================================


            //Project List:A list that displays the professor's projects
            ProjectList.Bounds = new Rectangle(new Point(150, 12), new Size(250, 500));
            ProjectList.View = View.Details;
            ProjectList.FullRowSelect = true;
            ProjectList.GridLines = true;
            ProjectList.Sorting = SortOrder.Ascending;
            ProjectList.Columns.Add("Project Name", -2, HorizontalAlignment.Left);
            ProjectList.Columns.Add("Max Grade", -2, HorizontalAlignment.Left);
            //==========================================================================


            //Students List: A list that displays each teams infos
            StudentsList.Bounds = new Rectangle(new Point(150, 12), new Size(375, 500));
            StudentsList.View = View.Details;
            StudentsList.FullRowSelect = true;
            StudentsList.GridLines = true;
            StudentsList.Sorting = SortOrder.Ascending;
            StudentsList.Columns.Add("Team", -2, HorizontalAlignment.Left);
            StudentsList.Columns.Add("Registration Number", -2, HorizontalAlignment.Left);
            StudentsList.Columns.Add("Email", -2, HorizontalAlignment.Left);
            //=============================================================================


            //Grade List: A list that displays the team with its project an the grade
            GradeList.Bounds = new Rectangle(new Point(150, 12), new Size(275, 500));
            GradeList.View = View.Details;
            GradeList.FullRowSelect = true;
            GradeList.GridLines = true;
            GradeList.Sorting = SortOrder.Ascending;
            GradeList.Columns.Add("Team", -2, HorizontalAlignment.Left);
            GradeList.Columns.Add("Project", -2, HorizontalAlignment.Left);
            GradeList.Columns.Add("Grade", -2, HorizontalAlignment.Left);
            //==============================================================================



            TeamGroupBox.Text = "";
            ProjectGroupBox.Text = "";
            GradeGroupBox.Text = "";

            TeamGroupBox.Bounds = new Rectangle(new Point(550, 12), new Size(320, 320));

            CoursesList.Show();
            SelectCourseBtn.Show();
            ChooseCourseMnBtn.BackColor = Color.Black;

            TeamGroupBox.Hide();
            StudentsList.Hide();
            GradeList.Hide();
            GradeGroupBox.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();
            ProjectGroupBox.Hide();
            ProjectList.Hide();

            
            ModifyProjectMnBtn.Enabled = false;
            ModifyTeamMnBtn.Enabled = false;
            AssignProjectMnBtn.Enabled = false;
            GradeProjectsMnBtn.Enabled = false;
            
        }

        private void YouAreHere(Button pressedBtn)
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (pressedBtn.Text == btn.Text)
                {
                    pressedBtn.BackColor = Color.Black;
                }
                else
                {
                    if (btn.Name.Contains("MnBtn"))
                    {
                        btn.BackColor = Color.FromArgb(100, 10, 10, 10);
                    }
                        
                }
            }
            ;
        }



        private void Paint(object sender, PaintEventArgs p)
        {
            Brush backCol = new SolidBrush(Color.FromArgb(200, 255,255,255));
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



        private void ChooseCourseMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(ChooseCourseMnBtn);
            ProjectGroupBox.Hide();
            ProjectList.Hide();
            GradeList.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();
            GradeGroupBox.Hide();
            TeamGroupBox.Hide();
            StudentsList.Hide();
            SelectedCourseLabel.Show();

            CoursesList.Show();
            SelectCourseBtn.Show();

        }


        private void ModifyTeamMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(ModifyTeamMnBtn);

            SelectedCourseLabel.Hide();
            CoursesList.Hide();
            SelectCourseBtn.Hide();
            ProjectGroupBox.Hide();
            ProjectList.Hide();
            GradeList.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();
            GradeGroupBox.Hide();


            StudentsList.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
            TeamGroupBox.Show();
            StudentsList.Show();
            TeamGroupBox.Location = new Point(550, 12);
            StudentsList.Location = new Point(150, 12);
        }


        private void ModifyProjectMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(ModifyProjectMnBtn);

            SelectedCourseLabel.Hide();
            CoursesList.Hide();
            SelectCourseBtn.Hide();
            StudentsList.Hide();
            TeamGroupBox.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();
            GradeList.Hide();
            GradeGroupBox.Hide();

            ProjectList.Show();
            ProjectGroupBox.Show();
            ProjectGroupBox.Location = new Point(450, 12);
        }


        private void AssignProjectMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(AssignProjectMnBtn);

            SelectedCourseLabel.Hide();
            CoursesList.Hide();
            SelectCourseBtn.Hide();
            ProjectGroupBox.Hide();
            TeamGroupBox.Hide();
            GradeList.Hide();
            GradeGroupBox.Hide();

            StudentsList.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top);
            AssignToWhomLabel.Show();
            AssignProjectBtn.Show();
            ProjectList.Show();
            StudentsList.Show();
            StudentsList.Location = new Point(635, 12);
            AssignProjectBtn.Location = new Point(467, 100);
            AssignToWhomLabel.Location = new Point(407, 50);
        }


        private void GradeProjectsMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(GradeProjectsMnBtn);

            SelectedCourseLabel.Hide();
            CoursesList.Hide();
            SelectCourseBtn.Hide();
            ProjectList.Hide();
            ProjectGroupBox.Hide();
            TeamGroupBox.Hide();
            StudentsList.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();

            GradeGroupBox.Show();
            GradeList.Show();
            GradeGroupBox.Location = new Point(450, 12);
        }


        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void SelectCourseBtn_Click(object sender, EventArgs e)
        {
            if (CoursesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a course to continue.", "No selection", MessageBoxButtons.OK);
            }
            else
            {
                SelectedCourseLabel.Text = CoursesList.SelectedItems[0].Text;
                ModifyProjectMnBtn.Enabled = true;
                ModifyTeamMnBtn.Enabled = true;
                AssignProjectMnBtn.Enabled = true;
                GradeProjectsMnBtn.Enabled = true;
                ModifyTeamMnBtn.PerformClick();
            }
        }
    }
}
