using System.Net.Mail;

namespace E_Class
{
	public class Email
	{
		private string emailAddress;

		// Constructor
		public Email(string mail)
		{
			this.setEmailAddress(mail);
		}

		// Validating Email Address
		private bool isValid()
		{
			try
			{
				MailAddress email = new MailAddress(this.getEmailAddress());
				return email.Address == this.getEmailAddress();
			}
			catch
			{
				return false;
			}
		}

		public string getEmailAddress() { return emailAddress; }
		public void setEmailAddress(string email) { this.emailAddress = email; }
	}
}
