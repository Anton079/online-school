using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class EnrolmentService
    {
        private List<Enrolment> _enrolments;

        public EnrolmentService()
        {
            _enrolments = new List<Enrolment>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.GetFilePath()))
                {
                    string line = " ";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Enrolment enrolment = new Enrolment(line);
                        this._enrolments.Add(enrolment);
                    }
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

            string file = Path.Combine(folder, "enrolment");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _enrolments.Count-1; i++)
            {
                save += _enrolments[i].ToSave() + "\n";
            }

            save += _enrolments[_enrolments.Count - 1].ToSave();

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
        public void AfisareEnrolment()
        {
            foreach(Enrolment x in _enrolments)
            {
                Console.WriteLine(x.EnrolmentInfo());
            }
        }

        public int FindEnrolmentByStudentId(int studentIdDorit)
        {
            for(int i = 0; i < _enrolments.Count;i++)
            {
                if (_enrolments[i].Student_id == studentIdDorit)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddEnrolment(Enrolment enrolment)
        {
            if (FindEnrolmentByStudentId(enrolment.Student_id) == -1)
            {
                this._enrolments.Add(enrolment);
                return true;
            }
            return false;
        }

        public bool EditCourseIdByStId(int idStudent,int courseId)
        {
            for(int i = 0; i < _enrolments.Count; i++)
            {
                if (_enrolments[i].Student_id == idStudent)
                {
                    courseId = _enrolments[i].Course_id;
                    return true;
                }
            }
            return false;
        }

        public void RemoveEnrolment(int idEnrolment)
        {
            int wantedEnrolment = FindEnrolmentByStudentId(idEnrolment);
            if (wantedEnrolment != -1)
            {
                this._enrolments.RemoveAt(wantedEnrolment);
            }
            else
            {
                Console.WriteLine("Enrolmentul nu a fost gasit!");
            }
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindEnrolmentByStudentId(id) != -1)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }

        public List<int> FindAllStundetsByACourse(int courseId)
        {
            List <int> wantedStudents = new List<int>();

            for(int i = 0; i < _enrolments.Count; i++)
            {
                if (_enrolments[i].Course_id==courseId)
                {
                    wantedStudents.Add(_enrolments[i].Student_id);
                }
            }
            return wantedStudents;
        }

        public List<int> FindAllStudentsByAYear(int data)
        {
            List <int> ListStudents= new List<int> ();

            for(int i = 0; i < _enrolments.Count;i++)
            {
                if (_enrolments[i].Created_at == data)
                {
                    ListStudents.Add(_enrolments[i].Student_id);
                }
            }
            return ListStudents;
        }

        
    }
}
