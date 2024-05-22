using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class ViewAdmin
    {
        private CourseService _courseService;
        private BookService _bookService;
        private EnrolmentService _enrolmentService;
        private StudentService _studentService;
        private Admin admin;

        public ViewAdmin()
        {
            admin = new Admin(1, "Mihnea", "Ioan", "mihnea@yahoo.com");
            _studentService = new StudentService();
            _courseService = new CourseService();
            _bookService = new BookService();
            _enrolmentService = new EnrolmentService();
        }

        public void MeniuAdmin()
        {
            Console.WriteLine("");
            Console.WriteLine("SHOW");
            Console.WriteLine("Apasati tasta 1 pentru a afisa stundentii inscrisi la un anumit curs"); //
            Console.WriteLine("Apasati tasta 2 pentru a afisa toti studentii care au fost inscrisi intr-un anumit an");//
            Console.WriteLine("Apasati tasta 3 pentru a afisa toate cartile unui student ales dupa id");//
            Console.WriteLine("EDIT");
            Console.WriteLine("Apasati tasta 4 pentru a edita numele unui curs dupa id"); //
            Console.WriteLine("Apasati tasta 5 pentru a edita student id ul dintr o carte");//
            Console.WriteLine("ADD");
            Console.WriteLine("Apasati tasta 6 pentrua a adauga un departament");//
            Console.WriteLine("Remove");
            Console.WriteLine("Apasati tasta 7 pentru a da remove la un departament");//
            Console.WriteLine("Apasati tastsa 8 pentru a sterge cartea unui student");//
            Console.WriteLine("");
        }

        public void play()
        {
            bool running = true;
            while(running)
            {
                MeniuAdmin();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        ShowStudentsFromACourseByCourseName();
                        break;

                    case "2":
                        ShowStudentsEnrolledFromACertainYear();
                        break;

                    case "3":
                        ShowAllBooksToAStudents();
                        break;

                    case "4":
                        EditNameCourseById();
                        break;

                    case "5":
                        EditIdStudentFromBookByIdBook(); //modifica tot fisierul
                        break;

                    case "6":
                        AddDepartament();
                        break;

                    case "7":
                        RemoveDepartment();
                        break;

                    case "8":
                        RemoveBookFromStudent();
                        break;
                }
            }
        }

        public void AddDepartament()
        {
            int idGenerat = _courseService.GenerateId();

            Console.WriteLine("Ce nume are cursul?");
            string courseNew = Console.ReadLine();

            Console.WriteLine("In ce departament se incadreaza cursul");
            string departamentNew = Console.ReadLine();

            Course course = new Course(idGenerat, courseNew, departamentNew);

            _courseService.AddCourse(course);

            _courseService.SaveData();


            Console.WriteLine("Cursul a fost adauga!");
        }

        public void EditNameCourseById()
        {
            Console.WriteLine("Introduce-ti id-ul cursului pe care doriti sa il modificati");
            int idCurs = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Noul nume pentru acest curs?");
            string newCoruseName = Console.ReadLine();

            if( _courseService.EditCourseName(idCurs, newCoruseName))
            {
                Console.WriteLine("Numele a fost schimbat");
            }
            else
            {
                Console.WriteLine("Numele nu a fost schimbat");
            }

            _courseService.SaveData();
        }

        public void EditIdStudentFromBookByIdBook()
        {
            Console.WriteLine("Id-ul cartii pe care vrei sa o modifici");
            int idBook = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce id doriti sa puneti la schimb in inchiriere?");
            int NewIdToAdd = Int32.Parse(Console.ReadLine());

            if (_bookService.EditBookIdById(idBook, NewIdToAdd))
            {
                Console.WriteLine("Id ul a fost modificat!");
            }
            else
            {
                Console.WriteLine("Id ul nu a fost modificat!");
            }

            _bookService.SaveData();
        }  

        public void ShowStudentsFromACourseByCourseName()
        {
            Console.WriteLine("Ce curs cauti?");
            string wantedCourse = Console.ReadLine();

            int courseId = _courseService.FindIdCourseByName(wantedCourse);

            if(courseId != -1)
            {
                List<int> students = _enrolmentService.FindAllStundetsByACourse(courseId);
                _studentService.ShowWantedStundets(students);
            }
            else
            {
                Console.WriteLine("Cursul nu a fost gasit.");
            }
        }

        public void ShowStudentsEnrolledFromACertainYear()
        {
            Console.WriteLine("Din ce data vrei sa vezi toti studentii?");
            int wantedData = Int32.Parse(Console.ReadLine());

            bool EightDigits = wantedData >= 10000000 && wantedData <= 99999999;

            if(EightDigits)
            {
                List<int> studentsByData = _enrolmentService.FindAllStudentsByAYear(wantedData);
                _studentService.ShowWantedYearStudents(studentsByData);
            }
            else
            {
                Console.WriteLine("numarul intorus nu are 8 cifre");
            }

        }

        public void ShowAllBooksToAStudents()
        {
            Console.WriteLine("Ce id are studentul?");
            int wantedId = Int32.Parse(Console.ReadLine());

            if(wantedId != 0)
            {
                List<string> BooksOfStudent = _bookService.FindAllBooksOfAStudentByHisId(wantedId);
                _bookService.ShowALlBooksOfAStudents(BooksOfStudent);
            }
            else
            {
                Console.WriteLine("Id ul nu exista");
            }
        }

        public void RemoveDepartment()
        {
            Console.WriteLine("Ce id are departamentul?");
            int wantedId = Int32.Parse(Console.ReadLine());

            int courseId = _courseService.FindCourseById(wantedId);
            if (courseId != -1)
            {
                _courseService.RemoveCourse(courseId);
                Console.WriteLine("Cursul a fost șters");
            }
            else
            {
                Console.WriteLine("Cursul nu a putut fi găsit");
            }
        }

        public void RemoveBookFromStudent()
        {
            Console.WriteLine("Ce id are studentul?");
            int wantedStudent = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce id are cartea?");
            int idBookWanted = Int32.Parse(Console.ReadLine());

            int bookFound = _bookService.FindBookIdByStId(wantedStudent, idBookWanted);

            if (bookFound != -1)
            {
                _bookService.RemoveBook(bookFound);
                Console.WriteLine("Cartea a fost stearsa");
            }
            else
            {
                Console.WriteLine("Cartea cu acest id nu a fost gasita");
            }
        }
    }
}
