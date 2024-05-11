using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Course
    {
        private int _id;
        private string _name;
        private string _department;

        public Course(string proprietati)
        {
            String[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _name = token[1];
            _department = token[2];
        }

        public Course(int id, string name, string department)
        {
            _id = id;
            _name = name;
            _department = department;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string CourseInfo()
        {
            string text = " ";
            text += "Id" + _id + "\n";
            text += "Name" + _name + "\n";
            text += "Department " + _department + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._id + "," + this._name + "," + this._department;
        }
    }
}
