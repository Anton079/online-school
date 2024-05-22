using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Admin
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;

        public Admin(string proprietati)
        {
            String[] token = proprietati.Split(',');

            this._id = int.Parse(token[0]);
            this._firstName = token[1];
            this._lastName = token[2];
            this._email = token[3];
        }

        public Admin(int id, string firstName, string lastName, string email)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string AdminInfo()
        {
            string text = " ";
            text += "Id " + _id + "\n";
            text += "First Name " + _firstName + "\n";
            text += "Last Name " + _lastName + "\n";
            text += "Email " + _email + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._id + "," + this._firstName + "," + this._lastName + "," + this._email;
        }
    }
}
