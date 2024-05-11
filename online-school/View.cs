using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class View
    {
        private StudentService _studentService;
        private Student_id_cardService _student_Id_CardService;
        private CourseService _courseService;
        private BookService _bookService;
        private EnrolmentService _enrolmentService;

        public View()
        {
            _studentService = new StudentService();
            _student_Id_CardService = new Student_id_cardService();
            _courseService = new CourseService();
            _bookService = new BookService();
            _enrolmentService = new EnrolmentService();
        }

        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a va inregistra la un curs"); 
            Console.WriteLine("Read");
            Console.WriteLine("Apasati tasta 2 pentru a vedea ce cursuri avem!");
            Console.WriteLine("Apasati tasta 3 pentru a vedea toate cartile"); 
            Console.WriteLine("Apasati tasta 4 pentru a vedea toate inregistrarile");
            Console.WriteLine("Add");
            Console.WriteLine("Apasati tasta 5 pentru a adauga un curs");
            Console.WriteLine("Apasati tasta 6 pentru a adauga o carte");
            Console.WriteLine("Edit");
            Console.WriteLine("Apasati tasta 7 pentru a edita un curs dupa id");
            Console.WriteLine("Apasati tasta 8 pentru a edita id ul studentului care este inregistrat in inchiriere");
            Console.WriteLine("Apasati tasta 9 pentru a edita id ul unui student de la inregistrare");
            Console.WriteLine("Remove");
            Console.WriteLine("Apasati tasta 10 pentru a sterge o carte inchiriata");
            Console.WriteLine("Apasati tasta 11 pentru a sterge o inregistrare la un curs");
        }

        public void play()
        {
            bool running = true;
            while (running)
            {
                Meniu();
                string alegere = Console.ReadLine();

                switch(alegere)
                {
                    case "1":
                        AddEnrolmentInSchool();
                        break;

                    case "2":
                        _courseService.AfisareCourse();
                        break;

                    case "3":
                        _bookService.AfisareBook();
                        break;

                    case "4":
                        _enrolmentService.AfisareEnrolment();
                        break;

                    case "5":
                        AddCourse();
                        break;

                    case "6":
                        AddBook();
                        break;

                    case "7":
                        EditIdStudentFromBook();
                        break;

                    case "8":
                        //edit id inchiriere book student

                    case "9":
                        EditIdStudentFromEnrolment();
                        break;

                    case "11":
                        RemoveEnrolment();
                        break;//eroare



                }
            }
        }


        public void AddEnrolmentInSchool()
        {
            Console.WriteLine("Ce id are studentul care vrea sa intre?");
            int idStudent = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce id are cursul?");
            int idCourse = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Cand s-a inregistart?");
            int idCreateAt = Int32.Parse(Console.ReadLine());

            Enrolment Enrolment = new Enrolment(idStudent, idCourse, idCreateAt);

            _enrolmentService.AddEnrolment(Enrolment);

            Console.WriteLine("Inregistrarea a fost reusita!");
        }

        public void AddCourse()
        {
            int idGenerat = _courseService.GenerateId();

            Console.WriteLine("Ce nume are cursul?");
            string courseNew = Console.ReadLine();

            Console.WriteLine("In ce departament se incadreaza cursul");
            string departamentNew = Console.ReadLine();

            Course course = new Course(idGenerat, courseNew, departamentNew);

            _courseService.AddCourse(course);
        }

        public void AddBook()
        {
            int idGenerat = _bookService.GenerateId();

            Console.WriteLine("ce id are studentul care a inchiriat cartea");
            int idStudent = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce nume are cartea?");
            string bookNewName = Console.ReadLine();

            Console.WriteLine("Cand a fost creata cartea");
            int bookNewTime = Int32.Parse(Console.ReadLine());

            Book book = new Book(idGenerat, idStudent, bookNewName, bookNewTime);

            _bookService.AddBook(book);
        }

        //public void EditNameCoruseById()
        //{
        //    Console.WriteLine("Introduce ti id ul cursului pe care doriti sa il modificati");
        //    int idCurs = Int32.Parse(Console.ReadLine());

        //    Course nameCourse = _courseService.FindCourseById(idCurs);
        //    if()
        //}

        public void EditIdStudentFromBook()
        {
            Console.WriteLine("Ce id are cartea pe care doriti sa o modificati");
            int idBook = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce id doriti sa puneti?");
            int idStudent = Int32.Parse(Console.ReadLine());

            if(_bookService.EditRentedBook(idStudent, idBook))
            {
                Console.WriteLine("Id ul a fost modificat!");
            }
            else
            {
                Console.WriteLine("Id ul nu a fost modificat!");
            }
        }

        public void EditIdStudentFromEnrolment()
        {
            Console.WriteLine("Id ul carui student vrei sa ii modifici inregistrare");
            int idStudent = Int32.Parse(Console.ReadLine());

            if (_enrolmentService.EditEnrolmentId(idStudent))
            {
                Console.WriteLine("Id ul a fost modificat");
            }
            else
            {
                Console.WriteLine("Id ul nu a fost modificat");
            }
        }

        //public void RemoveBookFromRent()
        //{
        //    Console.WriteLine("Ce id are cartea pe care vrei sa o stergi");
        //    int wantedBook = Int32.Parse(Console.ReadLine());

        //    Book bookRem = _bookService.FindBookById(wantedBook);
        //}

        public void RemoveEnrolment()
        {
            Console.WriteLine("Ce id are studentul pe care vrei sa il stergi de la un curs");
            int wantedId = Int32.Parse(Console.ReadLine());

            //Student student = _studentService.FindStudentById(wantedId);
        }

    }
}
