using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Book
    {
        private int _id;
        private int _student_id;
        private string _book_name;
        private int _created_at; //data ex 01052024

        public Book(string proprietati)
        {
            String[] token = proprietati.Split(',');

            this._id = int.Parse(token[0]);
            this._student_id = int.Parse(token[1]);
            this._book_name = token[2];
            this._created_at = int.Parse(token[3]);
        }

        public Book(int id, int student_id, string book_name, int create_at)
        {
            _id = id;
            _student_id = student_id;
            _book_name = book_name;
            _created_at = create_at;
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

        public string Book_name
        {
            get { return _book_name; }
            set { _book_name = value; }
        }

        public int Create_at
        {
            get { return _created_at; }
            set { _created_at = value; }
        }

        public string BookInfo()
        {
            string text = " ";
            text += "Id " + _id + "\n";
            text += "Student Id" + _student_id + "\n";
            text += "Book name " + _book_name + "\n";
            text += "Create at " + _created_at + "\n";
            return text;
        }

        public string ToSave()
        {
            return this._id + ',' + this._student_id + ", " + this._book_name + ',' + this._created_at;
        }
    }

}
