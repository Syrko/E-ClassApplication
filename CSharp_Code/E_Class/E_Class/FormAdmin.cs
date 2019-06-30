using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace E_Class
{
    public partial class FormAdmin : UserForm
    {
		// Inherited properties
		protected override User currentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        // Inherited methods

        FormLogin login;
        public override void logout()
		{
			this.Close();
		}

		private ListViewItem itm;
        private ContextMenuStrip UsersRightClickMenu = new ContextMenuStrip();
        private ContextMenuStrip CoursesRightClickMenu = new ContextMenuStrip();
        private List<String> LocalUsersDatabase = new List<String>();
        private List<String> LocalCoursesDatabase = new List<String>();
        string[] assignments = new string[2];


        public FormAdmin(string reg_num, FormLogin login)
        {
            InitializeComponent();

            this.login = login;
            UserGroupBox.Controls.Add(NameBox);
            UserGroupBox.Controls.Add(RegNumBox);
            UserGroupBox.Controls.Add(SurnameBox);
            UserGroupBox.Controls.Add(PassBox);
            UserGroupBox.Controls.Add(EmailBox);
            UserGroupBox.Controls.Add(CapacityBox);
            UserGroupBox.Controls.Add(CreateEditUserBtn);
            UserGroupBox.Controls.Add(NameLabel);
            UserGroupBox.Controls.Add(RegNumLabel);
            UserGroupBox.Controls.Add(SurnameLabel);
            UserGroupBox.Controls.Add(PassLabel);
            UserGroupBox.Controls.Add(EmailLabel);
            UserGroupBox.Controls.Add(CapacityLabel);
            





            //Creating the UsersList
            UsersList.Bounds = new Rectangle(new Point(196, 12), new Size(375, 500));
            UsersList.View = View.Details;
            UsersList.FullRowSelect = true;
            UsersList.GridLines = true;
            UsersList.Sorting = SortOrder.Ascending;
            UsersList.Columns.Add("Registration Number", -2, HorizontalAlignment.Left);
            UsersList.Columns.Add("Name", -2, HorizontalAlignment.Left);
            UsersList.Columns.Add("Surname", -2, HorizontalAlignment.Left);
            UsersList.Columns.Add("Email", -2, HorizontalAlignment.Left);
            UsersList.Columns.Add("Capacity", -2, HorizontalAlignment.Left);

            //============================================================================



            LocalUsersDatabase.Add("kp0000");
            LocalUsersDatabase.Add("Mike");
            LocalUsersDatabase.Add("Kalliafas");
            LocalUsersDatabase.Add("mike@mike.gr");
            LocalUsersDatabase.Add("Professor");

            LocalUsersDatabase.Add("p50000");
            LocalUsersDatabase.Add("Alberto");
            LocalUsersDatabase.Add("Makavegias");
            LocalUsersDatabase.Add("almak@email.com");
            LocalUsersDatabase.Add("Student");

            LocalCoursesDatabase.Add("Algebra");
            LocalCoursesDatabase.Add("Professor 1");
            LocalCoursesDatabase.Add("Physics");
            LocalCoursesDatabase.Add("Professor 2");





            //Users Right Click menu creation
            ToolStripMenuItem UsersRightClickMenuEdit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem UsersRightClickMenuDelete = new ToolStripMenuItem("Delete");
            UsersRightClickMenuDelete.Click += new EventHandler(UserDelete_RightClick);
            UsersRightClickMenuEdit.Click += new EventHandler(UserEdit_RightClick);
            UsersRightClickMenu.Items.AddRange(new ToolStripItem[] { UsersRightClickMenuEdit, UsersRightClickMenuDelete });

            //===================================================================================


            //Courses Right Click menu creation
            ToolStripMenuItem CoursesRightClickMenuEdit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem CoursesRightClickMenuDelete = new ToolStripMenuItem("Delete");
            CoursesRightClickMenuDelete.Click += new EventHandler(CoursesDelete_RightClick);
            CoursesRightClickMenuEdit.Click += new EventHandler(CoursesEdit_RightClick);
            CoursesRightClickMenu.Items.AddRange(new ToolStripItem[] { CoursesRightClickMenuEdit, CoursesRightClickMenuDelete });
            //===================================================================================









            //Creating the CoursesList
            CoursesList.Bounds = new Rectangle(new Point(150, 12), new Size(250, 500));
            CoursesList.View = View.Details;
            CoursesList.FullRowSelect = true;
            CoursesList.GridLines = true;
            CoursesList.Sorting = SortOrder.Ascending;
            CoursesList.Columns.Add("Courses", -2, HorizontalAlignment.Left);
            CoursesList.Columns.Add("Professor", -2, HorizontalAlignment.Left);
            //=============================================================================




            ChangeMsgLabel("Create", "Users");
            
            CourseGroupBox.Text = "";
            UserGroupBox.Text = "";

            CoursesList.Hide();
            UsersList.Hide();
            CourseGroupBox.Hide();
            CourseTitleErrorLabel.Hide();
            AssignMsgLabel.Hide();
            AssignCourseBtn.Hide();
            RegMsgLabel.Hide();
            NameMsgLabel.Hide();
            SurnameMsgLabel.Hide();
            EmailMsgLabel.Hide();
            PassMsgLabel.Hide();
            CapacityMsgLabel.Hide();
            CancelCoursesBtn.Hide();
            RegNumErrorLabel.Hide();
            NameErrorLabel.Hide();
            SurnameErrorLabel.Hide();
            EmailErrorLabel.Hide();
            PassErrorLabel.Hide();
            CapacityErrorLabel.Hide();
            CancelUsersBtn.Hide();

            RegNumErrorLabel.SendToBack();
            NameErrorLabel.SendToBack();
            SurnameErrorLabel.SendToBack();
            EmailErrorLabel.SendToBack();
            PassErrorLabel.SendToBack();
            CapacityErrorLabel.SendToBack();




            UserGroupBox.Left = (this.ClientSize.Width - UserGroupBox.Width + 100) / 2;
            UserGroupBox.Top = (this.ClientSize.Height - UserGroupBox.Height - 100) / 2;

            UpdateList("Users");
            UpdateList("Courses");
        }

        //On click on every menu button, objects that are not needed are being hidden, text boxes are being cleared
        //and the lists are being enabled. The regnumbo on edit must be disable so that the admin cannot create or
        //replace(by accident or not) a user from there

        private void CreateCourseMenuBtn_Click(object sender, EventArgs e)
        {
            UserGroupBox.Hide();
            CoursesList.Hide();
            AssignMsgLabel.Hide();
            AssignCourseBtn.Hide();
            CancelUsersBtn.Hide();
            CancelCoursesBtn.Hide();
            ClearBoxes();
            UsersList.Enabled = true;
            CoursesList.Enabled = true;
            CreateEditCourseBtn.Text = "Create";
            ChangeMsgLabel("Create", "Courses");
            UsersList.Show();
            CourseGroupBox.Show();
            this.CourseGroupBox.Location = new Point(550, 12);
            this.UsersList.Location = new Point(150, 12);
        }

        private void CreateUserMenuBtn_Click(object sender, EventArgs e)
        {
            CourseGroupBox.Hide();
            UsersList.Hide();
            CoursesList.Hide();
            AssignMsgLabel.Hide();
            AssignCourseBtn.Hide();
            CancelUsersBtn.Hide();
            CancelCoursesBtn.Hide();
            HideAllErrors();
            ChangeMsgLabel("Create", "Users");
            ClearBoxes();

            UsersList.Enabled = true;
            CoursesList.Enabled = true;
            RegNumBox.Enabled = true;
            PassBox.Show();
            PassLabel.Show();
            UserGroupBox.Show();
            UserGroupBox.Left = (this.ClientSize.Width - UserGroupBox.Width + 100) / 2;
            UserGroupBox.Top = (this.ClientSize.Height - UserGroupBox.Height - 100) / 2;

            CreateEditUserBtn.Text = "Create";
        }



        private void AssignCoursesMenuBtn_Click(object sender, EventArgs e)
        {
            UsersList.Enabled = true;
            CoursesList.Enabled = true;
            UserGroupBox.Hide();
            CourseGroupBox.Hide();
            AssignMsgLabel.Show();
            AssignCourseBtn.Show();
            AssignMsgLabel.Text = "";
            CoursesList.Show();
            UsersList.Show();
            ClearBoxes();

            //clear the array from previous entries
            assignments[0] = "";
            assignments[1] = "";
            //=====================

            CancelUsersBtn.Hide();
            CancelCoursesBtn.Hide();
            UsersList.Location = new Point(635, 12);
            AssignMsgLabel.Location = new Point(407, 50);
            AssignCourseBtn.Location = new Point(467, 100);
        }

        private void EditDelUsersMnBtn_Click(object sender, EventArgs e)
        {
            CourseGroupBox.Hide();
            CoursesList.Hide();
            PassBox.Hide();
            PassLabel.Hide();
            AssignMsgLabel.Hide();
            AssignCourseBtn.Hide();
            HideAllErrors();
            CancelUsersBtn.Hide();
            CancelCoursesBtn.Hide();
            ClearBoxes();
            UsersList.Enabled = true;
            CoursesList.Enabled = true;
            RegNumBox.Enabled = false;
            UserGroupBox.Show();
            UsersList.Show();
            this.UserGroupBox.Location = new Point(550, 12);
            this.UsersList.Location = new Point(150, 12);
            ChangeMsgLabel("Edit", "Users");
            CreateEditUserBtn.Text = "Submit";
        }

        private void EditDelCoursesMnBtn_Click(object sender, EventArgs e)
        {
            UserGroupBox.Hide();
            AssignMsgLabel.Hide();
            AssignCourseBtn.Hide();
            CancelUsersBtn.Hide();
            CancelCoursesBtn.Hide();
            ClearBoxes();
            UsersList.Enabled = true;
            CoursesList.Enabled = true;
            CreateEditCourseBtn.Text = "Submit";
            UsersList.Show();
            CoursesList.Show();
            CourseGroupBox.Show();
            ChangeMsgLabel("Edit", "Courses");
            this.CourseGroupBox.Location = new Point(410, 12);
            this.UsersList.Location = new Point(635, 12); 
        }

        private void CreateEditUserBtn_Click(object sender, EventArgs e)
        {
            if (CreateEditUserBtn.Text == "Create")
            {
                UserInputCheck check = new UserInputCheck();
                if (check.Check(RegNumBox, NameBox, SurnameBox, PassBox, EmailBox, CapacityBox, RegMsgLabel,
                NameMsgLabel, SurnameMsgLabel, EmailMsgLabel, PassMsgLabel, CapacityMsgLabel, RegNumErrorLabel, NameErrorLabel,
                SurnameErrorLabel, EmailErrorLabel, PassErrorLabel, CapacityErrorLabel))
                {
                    LocalUsersDatabase.Add(RegNumBox.Text);
                    LocalUsersDatabase.Add(NameBox.Text);
                    LocalUsersDatabase.Add(SurnameBox.Text);
                    LocalUsersDatabase.Add(EmailBox.Text);
                    LocalUsersDatabase.Add(CapacityBox.Text);
                    ChangeMsgLabel("SuccessCreate", "Users");
                    UpdateList("Users");
                    ClearBoxes();
                }
            }
            else
            {
                try//if no element is selected from the list, an error will be thrown
                {
                    UserInputCheck check = new UserInputCheck();
                    if (check.CheckNoPass(RegNumBox, NameBox, SurnameBox, EmailBox, CapacityBox, RegMsgLabel,
                        NameMsgLabel, SurnameMsgLabel, EmailMsgLabel, CapacityMsgLabel, RegNumErrorLabel,
                        NameErrorLabel, SurnameErrorLabel, EmailErrorLabel, CapacityErrorLabel))
                    {
                        //Delete selected items from the list 
                        DeleteSelectedItems(UsersList.SelectedItems[0].SubItems[0].Text, "Users");

                        //Re-add the entry with the edited information
                        LocalUsersDatabase.Add(RegNumBox.Text);
                        LocalUsersDatabase.Add(NameBox.Text);
                        LocalUsersDatabase.Add(SurnameBox.Text);
                        LocalUsersDatabase.Add(EmailBox.Text);
                        LocalUsersDatabase.Add(CapacityBox.Text);
                        ChangeMsgLabel("SuccessEdit", "Users");
                        UsersList.Enabled = true;
                        CancelUsersBtn.Hide();
                        ClearBoxes();
                        UpdateList("Users");
                    }
                }
                catch
                {
                    MessageBox.Show("Please first select a user");
                }

            }
        }



        private void UsersList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (UsersList.FocusedItem.Bounds.Contains(e.Location))
                {
                    UsersRightClickMenu.Show(Cursor.Position);
                }
            }

            //This is for the assignment
            assignments[1] = UsersList.SelectedItems[0].SubItems[0].Text;
            AssignMsgLabel.Font = new Font("Calibri", 10, FontStyle.Regular);
            AssignMsgLabel.Text = "Assign " + assignments[0] + " to " + assignments[1];
            //=======================================================================

        }

        private void UserDelete_RightClick(object sender, System.EventArgs e)
        {
            DeleteSelectedItems(UsersList.SelectedItems[0].SubItems[0].Text, "Users");
            UpdateList("Users");
        }

        private void UserEdit_RightClick(object sender, System.EventArgs e)
        {
            //From the selected row, write all the information to the appropriate textBoxes
            RegNumBox.Text = UsersList.SelectedItems[0].SubItems[0].Text;
            NameBox.Text = UsersList.SelectedItems[0].SubItems[1].Text;
            SurnameBox.Text = UsersList.SelectedItems[0].SubItems[2].Text;
            EmailBox.Text = UsersList.SelectedItems[0].SubItems[3].Text;
            CapacityBox.Text = UsersList.SelectedItems[0].SubItems[4].Text;
            RegNumBox.Enabled = false;
            UsersList.Enabled = false;
            CancelUsersBtn.Show();
        }

        private void CoursesDelete_RightClick(object sender, System.EventArgs e)
        {
            DeleteSelectedItems(CoursesList.SelectedItems[0].SubItems[0].Text, "Courses");
            UpdateList("Courses");
        }

        private void CoursesEdit_RightClick(object sender, System.EventArgs e)
        {
            CancelCoursesBtn.Show();
            CourseTitleBox.Text = CoursesList.SelectedItems[0].SubItems[0].Text;
        }



        //Rewrites the Lists with the items from the LocalDatabase
        private void UpdateList(string list)
        {
            if (list.Equals("Users"))
            {
                UsersList.Items.Clear();
                int size = LocalUsersDatabase.Count();
                for (int i = 0; i <= size - 5; i += 5)//Register numbers exist every 5 cells
                {
                    itm = new ListViewItem(LocalUsersDatabase[i]);
                    itm.SubItems.Add(LocalUsersDatabase[i + 1]);
                    itm.SubItems.Add(LocalUsersDatabase[i + 2]);
                    itm.SubItems.Add(LocalUsersDatabase[i + 3]);
                    itm.SubItems.Add(LocalUsersDatabase[i + 4]);
                    UsersList.Items.AddRange(new ListViewItem[] { itm });
                }
            }
            else
            {
                CoursesList.Items.Clear();
                int size = LocalCoursesDatabase.Count();
                for (int i = 0; i <= size - 2; i += 2)
                {
                    itm = new ListViewItem(LocalCoursesDatabase[i]);
                    itm.SubItems.Add(LocalCoursesDatabase[i + 1]);
                    CoursesList.Items.AddRange(new ListViewItem[] { itm });
                }
            }

        }



        private void LogoutBtn_Click(object sender, EventArgs e)
        {
			logout();
        }

        private void CreateCourseBtn_Click(object sender, EventArgs e)
        {
            if (CreateEditCourseBtn.Text == "Create")
            {
                if (string.IsNullOrWhiteSpace(CourseTitleBox.Text))//if nothing is written in the title box
                {
                    CourseTitleErrorLabel.Show();//Highlight it
                }
                else
                {
                    CourseTitleErrorLabel.Hide();
                    if (UsersList.SelectedItems.Count == 0)
                    {
                        DialogResult question = MessageBox.Show("You didn't select a professor. Do you want to continue?", "No selection", MessageBoxButtons.YesNo);
                        if (question == DialogResult.Yes)
                        {
                            LocalCoursesDatabase.Add(CourseTitleBox.Text);
                            LocalCoursesDatabase.Add("");
                            ChangeMsgLabel("SuccessCreate", "Courses");
                            UpdateList("Courses");
                            ClearBoxes();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        LocalCoursesDatabase.Add(CourseTitleBox.Text);
                        LocalCoursesDatabase.Add(UsersList.SelectedItems[0].SubItems[0].Text);//Add professor to the course
                        ChangeMsgLabel("SuccessCreate", "Courses");
                        UpdateList("Courses");
                        ClearBoxes();
                    }
                }
            }
            else
            {

                try
                {
                    //The problem is: When the admin wants to change only the course's title, we have to write the same
                    //professor to the list, next to the course.
                    string tempProf = CoursesList.SelectedItems[0].SubItems[1].Text;
                    DeleteSelectedItems(CoursesList.SelectedItems[0].SubItems[0].Text, "Courses");
                    if (UsersList.SelectedItems.Count == 0)//If no new prof is selected then add the old one
                    {
                        LocalCoursesDatabase.Add(CourseTitleBox.Text);
                        LocalCoursesDatabase.Add(tempProf);
                        ChangeMsgLabel("SuccessEdit", "Courses");
                        ClearBoxes();
                        UpdateList("Courses");
                    }
                    else
                    {
                        LocalCoursesDatabase.Add(CourseTitleBox.Text);
                        LocalCoursesDatabase.Add(UsersList.SelectedItems[0].SubItems[0].Text);
                        ChangeMsgLabel("SuccessEdit", "Courses");
                        ClearBoxes();
                        UpdateList("Courses");
                    }
                    /*
                    try//if else with try catch
                    {//if the admin does now want to select a new professor an exception will happen by the following code
                        reverseList.Add(UsersList.SelectedItems[0].SubItems[1].Text);
                    }
                    catch(Exception msg)
                    {//The admin didn't select a new prof, so we added the previous one
                        reverseList.Add(tempProf);
                    }
                    finally
                    {
                        reverseList.Add(CourseTitleBox.Text);
                    }
                    LocalCoursesDatabase.Add(reverseList[1]);//First add the course title
                    LocalCoursesDatabase.Add(reverseList[0]);//then add the professor
                    */  
                }
                catch(Exception msg)
                {
                    MessageBox.Show("Please first select a course");
                }
            }
        }

        private void DeleteSelectedItems(string RegNum, string table)
        {
            if (table == "Users")
            {
                int size = LocalUsersDatabase.Count();
                for (int i = 0; i <= size - 5 ; i += 5)
                {
                    if (LocalUsersDatabase[i] == RegNum)
                    {
                        //GAMIMENI C# SOU GAMIETAI I MANA KAI H ADERFI. ANWMALES LISTES GAMW.... 2 wres ...
                        LocalUsersDatabase.RemoveAt(i + 4);
                        LocalUsersDatabase.RemoveAt(i + 3);
                        LocalUsersDatabase.RemoveAt(i + 2);
                        LocalUsersDatabase.RemoveAt(i + 1);
                        LocalUsersDatabase.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                int size = LocalCoursesDatabase.Count();
                for (int i = 0; i <= size - 2; i += 2)
                {
                    if (LocalCoursesDatabase[i].Equals(RegNum))
                    {
                        LocalCoursesDatabase.RemoveAt(i + 1);
                        LocalCoursesDatabase.RemoveAt(i);
                        break;
                    }
                }
            }

        }



        private void ClearBoxes()
        {
            RegNumBox.Clear();
            NameBox.Clear();
            SurnameBox.Clear();
            EmailBox.Clear();
            PassBox.Clear();
            CourseTitleBox.Clear();
        }


        private void CoursesList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (CoursesList.FocusedItem.Bounds.Contains(e.Location))
                {
                    CoursesRightClickMenu.Show(Cursor.Position);
                }
            }

            //This is for the assingment
            assignments[0] = CoursesList.SelectedItems[0].SubItems[0].Text;
            AssignMsgLabel.Font = new Font("Calibri", 10, FontStyle.Regular);
            AssignMsgLabel.Text = "Assign " + assignments[0] + " to " + assignments[1];
            //==========================================================================
        }

        private void AssignCourseBtn_Click(object sender, EventArgs e)
        {
            
            if (UsersList.SelectedItems.Count == 0 || CoursesList.SelectedItems.Count == 0)//If a cource nor a prof is selected
            {
                MessageBox.Show("Please select a course and a professor to assign it to");
            }
            else
            {
                DialogResult msg = MessageBox.Show("Are you sure?", "Assign", MessageBoxButtons.YesNo);
                if (msg == DialogResult.Yes)
                {
                    DeleteSelectedItems(CoursesList.SelectedItems[0].SubItems[0].Text, "Courses");
                    LocalCoursesDatabase.Add(CoursesList.SelectedItems[0].SubItems[0].Text);
                    LocalCoursesDatabase.Add(UsersList.SelectedItems[0].SubItems[0].Text);
                    ChangeMsgLabel("SuccesAssign", "Assign");
                    ClearBoxes();
                    UpdateList("Courses");
                }
                
            }
        }




        private void HideAllErrors()
        {
            RegMsgLabel.Hide();
            NameMsgLabel.Hide();
            SurnameMsgLabel.Hide();
            EmailMsgLabel.Hide();
            PassMsgLabel.Hide();
            CapacityMsgLabel.Hide();
            RegNumErrorLabel.Hide();
            NameErrorLabel.Hide();
            SurnameErrorLabel.Hide();
            EmailErrorLabel.Hide();
            PassErrorLabel.Hide();
            CapacityErrorLabel.Hide();
        }

        private void CancelUsersBtn_Click(object sender, EventArgs e)
        {
            UsersList.Enabled = true;
            ClearBoxes();
        }

        private void CancelCoursesBtn_Click(object sender, EventArgs e)
        {
            CoursesList.Enabled = true;
            ClearBoxes();
        }


        private void ChangeMsgLabel(string state, string list)
        {
            if(list == "Users")
            {
                if (state == "SuccessCreate")
                {
                    CreateEditUserLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditUserLabel.ForeColor = Color.Green;
                    CreateEditUserLabel.Text = "User successfully created";

                }
                else if (state == "SuccessEdit")
                {
                    CreateEditUserLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditUserLabel.ForeColor = Color.Green;
                    CreateEditUserLabel.Text = "User successfully edited";
                }
                else if (state == "Create")
                {
                    CreateEditUserLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditUserLabel.ForeColor = Color.Black;
                    CreateEditUserLabel.Text = "Create a new user";
                }
                else if (state == "Edit")
                {
                    CreateEditUserLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditUserLabel.ForeColor = Color.Black;
                    CreateEditUserLabel.Text = "Select a user to edit";
                }
            }
            else if(list == "Courses")
            {
                if (state == "SuccessCreate")
                {
                    CreateEditCourseLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditCourseLabel.ForeColor = Color.Green;
                    CreateEditCourseLabel.Text = "Course successfully created";

                }
                else if (state == "SuccessEdit")
                {
                    CreateEditCourseLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditCourseLabel.ForeColor = Color.Green;
                    CreateEditCourseLabel.Text = "Course successfully edited";
                }
                else if (state == "Create")
                {
                    CreateEditCourseLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditCourseLabel.ForeColor = Color.Black;
                    CreateEditCourseLabel.Text = "Create a new course";
                }
                else if (state == "Edit")
                {
                    CreateEditCourseLabel.Font = new Font("Calibri", 9, FontStyle.Bold);
                    CreateEditCourseLabel.ForeColor = Color.Black;
                    CreateEditCourseLabel.Text = "Select a course to edit";
                }
            }
            else
            {
                AssignMsgLabel.Font = new Font("Calibri", 10, FontStyle.Bold);
                AssignMsgLabel.ForeColor = Color.Green;
                AssignMsgLabel.Text = "Course successfully assigned";
            }
            
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
        }
    }
}
