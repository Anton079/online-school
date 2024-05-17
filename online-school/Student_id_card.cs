using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Student_id_card
    {
        private int _id; //id ul cardului
        private int _student_id; //big int
        private string _card_number; //text not null    1234 5678 9012 3456

        public Student_id_card(string proprietati)
        {
            String[] token = proprietati.Split(',');

            this._id = int.Parse(token[0]);
            this._student_id = int.Parse(token[1]);
            this._card_number = token[2];
        }

        public Student_id_card(int id, int student_id, string card_number)
        {
            _id = id;
            _student_id = student_id;
            _card_number = card_number;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Student_id
        {
            get { return _student_id; }
            set { _student_id = value; }
        }

        public string Card_number
        {
            get { return _card_number; }
            set { _card_number = value; }
        }

        public string StudentIdCardInfo()
        {
            string text = " ";
            text += "Id" + _id + "\n";
            text += "Student id" + _student_id + "\n";
            text += "Card number " + _card_number + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._id + "," + this._student_id + ", " + this._card_number;
        }
    }
}
