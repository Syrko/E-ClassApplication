using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Types;
namespace E_Class
{
    public partial class FormProfessor : UserForm
    {

        //TODO Clear lists on every menu click
        //Refresh List, Max grade limit, selection NOT null



		// Inherited properties
		protected override User currentUser { get; set; }
        // Inherited methods

        private ContextMenuStrip TeamRightClickMenu = new ContextMenuStrip();
        private ContextMenuStrip ProjectRightClickMenu = new ContextMenuStrip();
        private string selectedCourse;
        Professor user;
        Course selCourse = null;


        public FormProfessor(string reg_num)
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

            currentUser = Database.GetUser(UserTypes.PROFESSOR, reg_num);


            user = (Professor)currentUser;
            //Courses List: A list that displays professor's courses
            CoursesList.Bounds = new Rectangle(new Point(450, 50), new Size(275, 400));
            CoursesList.View = View.Details;
            CoursesList.FullRowSelect = true;
            CoursesList.GridLines = true;
            CoursesList.Sorting = SortOrder.Ascending;
            CoursesList.Columns.Add("Cource name", -2, HorizontalAlignment.Center);
            CoursesList.Columns.Add("ID", -2, HorizontalAlignment.Center);



            foreach (Course course in user.getCourseList())
            {
                var listViewItem = new ListViewItem(course.getCourseName());
                listViewItem.SubItems.Add(course.getCourseID());
                CoursesList.Items.Add(listViewItem);
            }


            
            SelectedCourseLabel.Location = new Point(475, 20);
            SelectCourseBtn.Location = new Point(551, 458);
            //==============================================================================


            //Project List:A list that displays the professor's projects
            ProjectList.Bounds = new Rectangle(new Point(150, 12), new Size(250, 500));
            ProjectList.View = View.Details;
            ProjectList.FullRowSelect = true;
            ProjectList.GridLines = true;
            ProjectList.Sorting = SortOrder.Ascending;
            ProjectList.Columns.Add("ID", -2, HorizontalAlignment.Left);
            ProjectList.Columns.Add("Project Name", -2, HorizontalAlignment.Left);
            ProjectList.Columns.Add("Max Grade", -2, HorizontalAlignment.Left);
            //==========================================================================


            //Students List: A list that displays each teams infos
            TeamList.Bounds = new Rectangle(new Point(150, 12), new Size(375, 500));
            TeamList.View = View.Details;
            TeamList.FullRowSelect = true;
            TeamList.GridLines = true;
            TeamList.Sorting = SortOrder.Ascending;
            TeamList.Columns.Add("Team", -2, HorizontalAlignment.Left);
            TeamList.Columns.Add("Student 1", -2, HorizontalAlignment.Left);
            TeamList.Columns.Add("Student 2", -2, HorizontalAlignment.Left);
            TeamList.Columns.Add("Student 3", -2, HorizontalAlignment.Left);
            TeamList.Columns.Add("Student 4", -2, HorizontalAlignment.Left);
            TeamList.Columns.Add("Student 5", -2, HorizontalAlignment.Left);
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





            //Teams Right Click menu creation
            ToolStripMenuItem TeamRightClickMenuEdit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem TeamRightClickMenuDelete = new ToolStripMenuItem("Delete");
            TeamRightClickMenuDelete.Click += new EventHandler(TeamDelete_RightClick);
            TeamRightClickMenuEdit.Click += new EventHandler(TeamEdit_RightClick);
            TeamRightClickMenu.Items.AddRange(new ToolStripItem[] { TeamRightClickMenuEdit, TeamRightClickMenuDelete });
            //===================================================================================

            //Projects Right Click menu creation
            ToolStripMenuItem ProjectRightClickMenuEdit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem ProjectRightClickMenuDelete = new ToolStripMenuItem("Delete");
            ProjectRightClickMenuDelete.Click += new EventHandler(ProjectDelete_RightClick);
            ProjectRightClickMenuEdit.Click += new EventHandler(ProjectEdit_RightClick);
            ProjectRightClickMenu.Items.AddRange(new ToolStripItem[] { ProjectRightClickMenuEdit, ProjectRightClickMenuDelete });
            //===================================================================================
















            TeamGroupBox.Text = "";
            ProjectGroupBox.Text = "";
            GradeGroupBox.Text = "";

            TeamGroupBox.Bounds = new Rectangle(new Point(550, 12), new Size(380, 355)); 

            CoursesList.Show();
            SelectCourseBtn.Show();
            ChooseCourseMnBtn.BackColor = Color.Black;

            TeamGroupBox.Hide();
            TeamList.Hide();
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
            TeamList.Hide();
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


            TeamList.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top);
            TeamGroupBox.Show();
            TeamList.Show();
            TeamGroupBox.Location = new Point(550, 12);
            TeamList.Location = new Point(150, 12);


            //StudentsList.Clear();
            var listViewItem = new ListViewItem();
            foreach (Course course in user.getCourseList())
            {
                if (course.getCourseID() == selectedCourse)
                {
                    selCourse = course;
                    break;
                }
            }
            foreach(Team team in selCourse.getTeamList())
            {
                listViewItem = new ListViewItem();
                listViewItem.Text = team.getTeamID();
                foreach(Student stu in team.getStudentList())
                {
                    listViewItem.SubItems.Add(stu.registrationNumber.getRegNumString());
                }
                TeamList.Items.Add(listViewItem);
            }
        }


        private void ModifyProjectMnBtn_Click(object sender, EventArgs e)
        {
            YouAreHere(ModifyProjectMnBtn);

            SelectedCourseLabel.Hide();
            CoursesList.Hide();
            SelectCourseBtn.Hide();
            TeamList.Hide();
            TeamGroupBox.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();
            GradeList.Hide();
            GradeGroupBox.Hide();

            ProjectList.Show();
            ProjectGroupBox.Show();
            ProjectGroupBox.Location = new Point(450, 12);

            
            
            foreach (Project proj in selCourse.getProjectList())
            {
                var listViewItem = new ListViewItem();
                listViewItem.Text = proj.getProjectID();
                listViewItem.SubItems.Add(proj.getname());
                listViewItem.SubItems.Add(proj.getmaxGrade().ToString());
                ProjectList.Items.Add(listViewItem);
            }
               
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

            TeamList.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top);
            AssignToWhomLabel.Show();
            AssignProjectBtn.Show();
            ProjectList.Show();
            TeamList.Show();
            TeamList.Location = new Point(635, 12);
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
            TeamList.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();

            GradeGroupBox.Show();
            GradeList.Show();
            GradeGroupBox.Location = new Point(450, 12);
        }


        

        private void SelectCourseBtn_Click(object sender, EventArgs e)
        {
            if (CoursesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a course to continue.", "No selection", MessageBoxButtons.OK);
            }
            else
            {
                selectedCourse = CoursesList.SelectedItems[0].SubItems[1].Text;
                SelectedCourseLabel.Text = CoursesList.SelectedItems[0].Text + " is selected";
                ModifyProjectMnBtn.Enabled = true;
                ModifyTeamMnBtn.Enabled = true;
                AssignProjectMnBtn.Enabled = true;
                GradeProjectsMnBtn.Enabled = true;
                ModifyTeamMnBtn.PerformClick();
            }
        }




        private void TeamDelete_RightClick(object sender, System.EventArgs e)
        {
            Database.DeleteTeam(TeamList.SelectedItems[0].Text);
        }

        private void TeamEdit_RightClick(object sender, System.EventArgs e)
        {
            CreateEditTeamBtn.Text = "Submit";
            List<TextBox> list = new List<TextBox>();
            list.Add(Student1Box);
            list.Add(Student2Box);
            list.Add(Student3Box);
            list.Add(Student4Box);
            list.Add(Student5Box);

            foreach (Team team in selCourse.getTeamList())
            {
                if(team.getTeamID() == TeamList.SelectedItems[0].Text)
                {
                    for(int i = 0; i < team.getStudentList().Count; i++)
                    {
                        list[i].Text = team.getStudentList()[i].registrationNumber.getRegNumString();
                    }
                }
            }
        }


        private void ProjectDelete_RightClick(object sender, System.EventArgs e)
        {

        }

        
        private void ProjectEdit_RightClick(object sender, System.EventArgs e)
        {
            CreateEditTeamBtn.Text = "Submit";
            foreach (Project proj in selCourse.getProjectList())
            {
                if (proj.getProjectID() == ProjectList.SelectedItems[0].Text)
                {
                    ProjectNameBox.Text = proj.getname();
                    MaxGradeBox.Value = proj.getmaxGrade();
                    DescriptionBox.Text = proj.getdescription();
                }
            }

        }




        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            logout();
        }

        public override void logout()
        {
            this.Dispose();
        }


        private void FormProfessor_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void TeamList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (TeamList.FocusedItem.Bounds.Contains(e.Location))
                {
                    TeamRightClickMenu.Show(Cursor.Position);
                }
            }
        }

        private void CreateEditTeamBtn_Click(object sender, EventArgs e)
        {
            if(CreateEditTeamBtn.Text == "Submit")
            {
                CreateEditTeamBtn.Text = "Create";
            }
            else
            {
            }
        }

        private void ProjectList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ProjectList.FocusedItem.Bounds.Contains(e.Location))
                {
                    ProjectRightClickMenu.Show(Cursor.Position);
                }
            }
        }
    }
}
