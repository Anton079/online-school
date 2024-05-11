using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class StudentService
    {
        private List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>();
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
                        Student student = new Student(line);
                        this._students.Add(student);
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

            string file = Path.Combine(folder, "student");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";
            
            for(int i = 0; i < _students.Count; i++)
            {
                save += _students[i].ToSave() + "\n";
            }

            save += _students[_students.Count - 1].ToSave();

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
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //CRUD
        public void AfisareStudent()
        {
            foreach(Student x in _students)
            {
                Console.WriteLine(x.StudentInfo());
            }
        }

        public int FindStudentById(int StudentId)
        {
            for(int i = 0; i < _students.Count; i++)
            {
                if (_students[i].Id == StudentId)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddStudent(Student student)
        {
            if(FindStudentById(student.Id)== -1)
            {
                this._students.Add(student);
                return true;
            }
            return false;
        }

        public bool RemoveStudentById(int StudentId)
        {
            int StudentCautat = FindStudentById(StudentId);
            if(StudentCautat != -1)
            {
                this._students.RemoveAt(StudentCautat);
                return true;
            }
            return false;
        }

        public bool EditStudentId(string studentFirstName, string studentLastName, int studentId)
        {
            foreach(Student x in _students)
            {
                if(x.FirstName == studentFirstName && x.LastName == studentLastName)
                {
                    x.Id = studentId;
                    return true;
                }
            }
            return false;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindStudentById(id) != null)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }
    }
}
