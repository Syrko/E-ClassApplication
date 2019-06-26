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

            TeamGroupBox.Show();
            StudentsList.Show();

            GradeList.Hide();
            GradeGroupBox.Hide();
            AssignToWhomLabel.Hide();
            AssignProjectBtn.Hide();
            ProjectGroupBox.Hide();
            ProjectList.Hide();
        }

        private void ModifyTeamMnBtn_Click(object sender, EventArgs e)
        {
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
        }
    }
}
