using System;
using System.Collections.Generic;
using System.Text;

namespace E_Class
{
    class Admin : User
    {
        // User-inherited properties
        private RegNum _registrationNumber;
        private string _password;
        private string _name;
        private string _surname;
        private Email _email;

        // User-inherited properties
        public override RegNum registrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                _registrationNumber = value;
            }
        }
        public override string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public override string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public override string surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }
        public override Email email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }


        // Constructors
        public Admin(RegNum registrationNumber, string password, string name, string surname, Email email)
		{
			this._registrationNumber = registrationNumber;
			this._password = password;
			this._name = name;
			this._surname = surname;
			this._email = email;
		}

		// Methods
		public bool createUser(User newUser) { throw new NotImplementedException(); }
		public bool editUser(User user) { throw new NotImplementedException(); }
		public bool deleteUser(User user) { throw new NotImplementedException(); }
		public bool createCourse(Course newCourse) { throw new NotImplementedException(); }
		public bool editCourse(Course course) { throw new NotImplementedException(); }
		public bool deleteCourse(Course course) { throw new NotImplementedException(); }

	}
}
