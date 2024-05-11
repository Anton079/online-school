using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Student_id_card
    {
        private int _student_id; //big int
        private int _card_number; //text not null    1234 5678 9012 3456

        public Student_id_card(string proprietati)
        {
            String[] token = proprietati.Split(',');

            this._student_id = int.Parse(token[0]);
            this._card_number = int.Parse(token[1]);
        }

        public Student_id_card(int student_id, int card_number)
        {
            _student_id = student_id;
            _card_number = card_number;
        }

        public int Student_id
        {
            get { return _student_id; }
            set { _student_id = value; }
        }

        public int Card_number
        {
            get { return _card_number; }
            set { _card_number = value; }
        }

        public string StudentIdCardInfo()
        {
            string text = " ";
            text += "Student id" + _student_id + "\n";
            text += "Card number " + _card_number + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._student_id + ", " + this._card_number;
        }
    }
}
