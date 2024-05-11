using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class Student_id_cardService
    {
        private List<Student_id_card> _student_id_card;

        public Student_id_cardService()
        {
            _student_id_card = new List<Student_id_card>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                StreamReader sr = new StreamReader(this.GetFilePath());

                string line = " ";
                while ((line = sr.ReadLine()) != null)
                {
                    Student_id_card student_Id_Card = new Student_id_card(line);
                    this._student_id_card.Add(student_Id_Card);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "student_id_card");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _student_id_card.Count; i++)
            {
                save += _student_id_card[i].ToSave() + "\n";
            }

            save += _student_id_card[_student_id_card.Count - 1].ToSave();

            return save;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.GetFilePath()))
                {
                    sw.Write(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //CRUD

        public void AfisareStudentIdCard()
        {
            foreach(Student_id_card x in _student_id_card)
            {
                Console.WriteLine(x.StudentIdCardInfo());
            }
        }

        public int FindStudentIdCardByNumberCard(int numberCard)
        {
            for(int i = 0; i < _student_id_card.Count;i++)
            {
                if (_student_id_card[i].Card_number == numberCard)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindStudentIdCardByNumberId(int StudentIdCard)
        {
            for (int i = 0; i < _student_id_card.Count; i++)
            {
                if (_student_id_card[i].Student_id == StudentIdCard)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddStudentIdCard(Student_id_card student_Id_Card)
        {
            if(FindStudentIdCardByNumberCard(student_Id_Card.Card_number) == -1)
            {
                this._student_id_card.Add(student_Id_Card);
                return true;
            }
            return false;
        }

        public bool RemoveStudentIdCardById(Student_id_card StudentIdCard)
        {
            int wantedStudentIdCard = FindStudentIdCardByNumberId(StudentIdCard.Student_id);
            if (wantedStudentIdCard != -1)
            {
                this._student_id_card.RemoveAt(wantedStudentIdCard);
                return true;
            }
            return false;
        }


    }
}
