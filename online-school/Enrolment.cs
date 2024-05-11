using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Enrolment
    {
        private int _student_id;
        private int _course_id;
        private int _created_at;

        public Enrolment(string proprietati)
        {
            String[] token = proprietati.Split(',');

            _student_id = int.Parse(token[0]);
            _course_id= int.Parse(token[1]);
            _created_at = int.Parse(token[2]);
        }

        public Enrolment(int student_id,int course_id,int created_at)
        {
            _student_id= student_id;
            _course_id = course_id;
            _created_at = created_at;
        }

        public int Student_id
        {
            get { return _student_id; }
            set { _student_id = value; }
        }

        public int Course_id
        {
            get { return _course_id; }
            set { _course_id = value; }
        }

        public int Created_at
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        public string EnrolmentInfo()
        {
            string text = " ";
            text += "Student id " + _student_id + "\n";
            text += "Course id " + _course_id + "\n";
            text += "Created at " + _created_at + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._student_id + "," + this._course_id + ',' + this._created_at;
        }
    }
}
