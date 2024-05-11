using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class CourseService
    {
        private List<Course> _courses;

        public CourseService()
        {
            _courses = new List<Course>();
            this.LoadData();
        } 

        public void LoadData()
        {
            try
            {
                StreamReader sr = new StreamReader(this.GetFilePath());
                
                string line = " ";
                while((line = sr.ReadLine()) != null)
                {
                    Course course = new Course(line);
                    this._courses.Add(course);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "course");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _courses.Count; i++)
            {
                save += _courses[i].ToSave() + "\n";
            }

            save += _courses[_courses.Count - 1].ToSave();

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
        public void AfisareCourse()
        {
            foreach(Course x in _courses)
            {
                Console.WriteLine(x.CourseInfo());
            }
        }

        public int FindCourseById(int idCourse)
        {
            for(int i = 0; i < _courses.Count; i++)
            {
                if (_courses[i].Id == idCourse)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddCourse(Course course)
        {
            if(FindCourseById(course.Id) == -1)
            {
                this._courses.Add(course);
                return true;
            }
            return false;
        }

        public bool RemoveCourse(Course idCourse)
        {
            int wantedCourse = FindCourseById(idCourse.Id);
            if(wantedCourse != -1)
            {
                this._courses.RemoveAt(wantedCourse);
                return true;
            }
            return false;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindCourseById(id) != null)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }
    }
}
