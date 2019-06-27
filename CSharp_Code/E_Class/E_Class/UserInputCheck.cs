using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace E_Class
{
    class UserInputCheck
    {
        public UserInputCheck() {}



        public bool Check(Control RegNum, Control Name, Control Surname, Control Pass, Control Email, Control Capacity,
            Control RegNumMsg, Control NameMsg, Control SurnameMsg, Control EmailMsg, Control PassMsg, Control CapacityMsg,
            Control RegNumOutLine, Control NameOutLine, Control SurnameOutLine, Control EmailOutLine, Control PassOutLine,
            Control CapacityOutLine)
        {
            int clear = 0;
            if (string.IsNullOrEmpty(Name.Text))
            {
                NameMsg.Show();
                NameOutLine.Show();
                NameMsg.ForeColor = Color.Red;
                NameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                NameMsg.Text = "This field cannot be empty";
                NameOutLine.Show();
                clear = 0;
            }
            else if (Name.Text.Any(char.IsDigit))
            {
                NameOutLine.Show();
                NameMsg.Show();
                NameMsg.ForeColor = Color.Red;
                NameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                NameMsg.Text = "Name cannot contain numbers";
                clear = 0;
            }
            else
            {
                NameMsg.Hide();
                NameOutLine.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Surname.Text))
            {
                SurnameMsg.Show();
                SurnameOutLine.Show();
                SurnameMsg.ForeColor = Color.Red;
                SurnameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                SurnameMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else if (Surname.Text.Any(char.IsDigit))
            {
                SurnameOutLine.Show();
                SurnameMsg.Show();
                SurnameMsg.ForeColor = Color.Red;
                SurnameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                SurnameMsg.Text = "Surname cannot contain numbers";
                clear = 0;
            }
            else
            {
                SurnameOutLine.Hide();
                SurnameMsg.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Pass.Text))
            {
                PassMsg.Show();
                PassOutLine.Show();
                PassMsg.ForeColor = Color.Red;
                PassMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                PassMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else if (Pass.Text.Length < 8)
            {
                PassMsg.Show();
                PassOutLine.Show();
                PassMsg.ForeColor = Color.Red;
                PassMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                PassMsg.Text = "Password is too small";
                clear = 0;
            }
            else
            {
                PassMsg.Hide();
                PassOutLine.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Email.Text))
            {
                EmailOutLine.Show();
                EmailMsg.Show();
                EmailMsg.ForeColor = Color.Red;
                EmailMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                EmailMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else if (!Email.Text.Contains("@"))
            {
                EmailMsg.Show();
                EmailOutLine.Show();
                EmailMsg.ForeColor = Color.Red;
                EmailMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                EmailMsg.Text = "This is not a valid email address";
                clear = 0;
            }
            else
            {
                EmailOutLine.Hide();
                EmailMsg.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(RegNum.Text))
            {
                RegNumOutLine.Show();
                RegNumMsg.Show();
                RegNumMsg.ForeColor = Color.Red;
                RegNumMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                RegNumMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else
            {
                RegNumOutLine.Hide();
                RegNumMsg.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Capacity.Text))
            {
                CapacityOutLine.Show();
                CapacityMsg.Show();
                CapacityMsg.ForeColor = Color.Red;
                CapacityMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                CapacityMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else
            {
                CapacityOutLine.Hide();
                CapacityMsg.Hide();
                clear++;
            }

            return clear == 6;






        }


        public bool CheckNoPass(Control RegNum, Control Name, Control Surname, Control Email, Control Capacity,
            Control RegNumMsg, Control NameMsg, Control SurnameMsg, Control EmailMsg, Control CapacityMsg,
            Control RegNumOutLine, Control NameOutLine, Control SurnameOutLine, Control EmailOutLine,
            Control CapacityOutLine)
        {
            int clear = 0;
            if (string.IsNullOrEmpty(Name.Text))
            {
                NameMsg.Show();
                NameOutLine.Show();
                NameMsg.ForeColor = Color.Red;
                NameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                NameMsg.Text = "This field cannot be empty";
                NameOutLine.Show();
                clear = 0;
            }
            else if (Name.Text.Any(char.IsDigit))
            {
                NameOutLine.Show();
                NameMsg.Show();
                NameMsg.ForeColor = Color.Red;
                NameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                NameMsg.Text = "Name cannot contain numbers";
                clear = 0;
            }
            else
            {
                NameMsg.Hide();
                NameOutLine.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Surname.Text))
            {
                SurnameMsg.Show();
                SurnameOutLine.Show();
                SurnameMsg.ForeColor = Color.Red;
                SurnameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                SurnameMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else if (Surname.Text.Any(char.IsDigit))
            {
                SurnameOutLine.Show();
                SurnameMsg.Show();
                SurnameMsg.ForeColor = Color.Red;
                SurnameMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                SurnameMsg.Text = "Surname cannot contain numbers";
                clear = 0;
            }
            else
            {
                SurnameOutLine.Hide();
                SurnameMsg.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Email.Text))
            {
                EmailOutLine.Show();
                EmailMsg.Show();
                EmailMsg.ForeColor = Color.Red;
                EmailMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                EmailMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else if (!Email.Text.Contains("@"))
            {
                EmailMsg.Show();
                EmailOutLine.Show();
                EmailMsg.ForeColor = Color.Red;
                EmailMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                EmailMsg.Text = "This is not a valid email address";
                clear = 0;
            }
            else
            {
                EmailOutLine.Hide();
                EmailMsg.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(RegNum.Text))
            {
                RegNumOutLine.Show();
                RegNumMsg.Show();
                RegNumMsg.ForeColor = Color.Red;
                RegNumMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                RegNumMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else
            {
                RegNumOutLine.Hide();
                RegNumMsg.Hide();
                clear++;
            }

            if (string.IsNullOrEmpty(Capacity.Text))
            {
                CapacityOutLine.Show();
                CapacityMsg.Show();
                CapacityMsg.ForeColor = Color.Red;
                CapacityMsg.Font = new Font("Calibri", 6.5f, FontStyle.Regular);
                CapacityMsg.Text = "This field cannot be empty";
                clear = 0;
            }
            else
            {
                CapacityOutLine.Hide();
                CapacityMsg.Hide();
                clear++;
            }

            return clear == 5;







        }




    }
}
