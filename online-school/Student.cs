using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Student
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _age;

        public Student(string proprietati)
        {
            String[] token = proprietati.Split(',');

            this._id = int.Parse(token[0]);
            this._firstName = token[1];
            this._lastName = token[2];
            this._email = token[3];
            this._age = int.Parse(token[4]);
        }

        public Student(int id, string firstName, string lastName, string email,int age)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _age = age;
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

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string StudentInfo()
        {
            string text = " ";
            text += "Id " + _id + "\n";
            text += "First Name " + _firstName + "\n";
            text += "Last Name " + _lastName + "\n";
            text += "Email " + _email + "\n";
            text += "Age" + _age + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._id + "," + this._firstName + "," + this._lastName + "," + this._email + "," + this._age;
        }
    }
}
