using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school
{
    public class View
    {
        private CourseService _courseService;
        private BookService _bookService;
        private EnrolmentService _enrolmentService;
        private Student student;



        public View()
        {
            student = new Student(6,"Laur","Alex","Laur@gmail.com",17);
            _courseService = new CourseService();
            _bookService = new BookService();
            _enrolmentService = new EnrolmentService();
        }

        public void Meniu()
        {
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        M E N U                              ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════║");
            Console.WriteLine("║                       Enrolment                             ║");
            Console.WriteLine("║-------------------------------------------------------------║");
            Console.WriteLine("║ 1. Apăsați tasta 1 pentru a vă înregistra la un curs        ║");
            Console.WriteLine("║ 2. Apăsați tasta 2 pentru a închiria o carte                ║");
            Console.WriteLine("║-------------------------------------------------------------║");
            Console.WriteLine("║                          Read                               ║");
            Console.WriteLine("║-------------------------------------------------------------║");
            Console.WriteLine("║ 3. Apăsați tasta 3 pentru a vedea toate cursurile           ║");
            Console.WriteLine("║ 4. Apăsați tasta 4 pentru a afișa lista completă a cărților ║");
            Console.WriteLine("║ 5. Apăsați tasta 5 pentru a iesi de la un curs anume!       ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
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
                        AddBook();
                        break;

                    case "3":
                        _courseService.AfisareCourse();
                        break;

                    case "4":
                        _bookService.AfisareBook();
                        break;

                    case "5":
                        LeftACourse();
                        break;
                }
            }
        }

        public void AddEnrolmentInSchool()
        {
            Console.WriteLine("Id ul a fost luat automat");
            int idStudent = student.Id;

            Console.WriteLine("Ce id are cursul la care vrei sa te inscrii?");
            int idCourse = Int32.Parse(Console.ReadLine());

            Console.WriteLine("In ce data te inregistrezi?");
            int idCreateAt = Int32.Parse(Console.ReadLine());

            Enrolment Enrolment = new Enrolment(idStudent, idCourse, idCreateAt);

            _enrolmentService.AddEnrolment(Enrolment);

            _enrolmentService.SaveData();

            Console.WriteLine("Inregistrarea a fost reusita!");
        }

        public void AddBook()
        {
            int idGenerat = _bookService.GenerateId();

            Console.WriteLine("Id ul tau a fost preluat automat");
            int idStudent = student.Id;

            Console.WriteLine("Ce nume are cartea?");
            string bookNewName = Console.ReadLine();

            Console.WriteLine("Cand a fost inchiriata cartea");
            int bookNewTime = Int32.Parse(Console.ReadLine());

            Book book = new Book(idGenerat, idStudent, bookNewName, bookNewTime);

            _bookService.AddBook(book);

            _bookService.SaveData();

            Console.WriteLine("Cartea a fost adauga !");
        }

        public void LeftACourse()
        {
            Console.WriteLine("Ce id are cursul de la care vrei sa iesi?");
            int idCourse = Int32.Parse(Console.ReadLine());

            if(_courseService.FindCourseById(idCourse) != -1)
            {
                _enrolmentService.RemoveEnrolment(idCourse);
                Console.WriteLine("Ati fost scos de la curs");
            }
            else
            {
                Console.WriteLine("Nu a fost gasit curusl dorit");
            }
        }


    }
}
