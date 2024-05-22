using online_school;

internal class Program
{
    private static void Main(string[] args)
    {
        //todo: testam studentul

        StudentService studentService = new StudentService();


        //testare load fisier 

        //studentService.AfisareStudent();



        //testate salvare fisier
        //Student student3 = new Student(3, "Marius", "Alex", "MariusAlex@gmail.com", 16);

        //studentService.AddStudent(student3);

        //studentService.SaveData();




        //testare load fisier book
        //BookService bookService = new BookService();

        ////bookService.AfisareBook();



        //testate salavare fisier
        //Book bookTest = new Book(6,3, "Liniste", 09092004);
        //bookService.AddBook(bookTest);
        //bookService.SaveData();




        //Student_id_cardService student_id_cardService = new Student_id_cardService();


        ////afisare studeti id card
        ////student_id_cardService.AfisareStudentIdCard();

        //Student_id_card student_Id_CardTest = new Student_id_card(4, "5125 5151 6161 6161");

        //student_id_cardService.AddStudentIdCard(student_Id_CardTest);
        //student_id_cardService.SaveData();


        //testare cursuri

        //CourseService courseService = new CourseService();

        ////courseService.AfisareCourse();

        //Course courseTest = new Course(10, "Initiere", "Informatica");
        //courseService.AddCourse(courseTest);
        //courseService.SaveData();


        //EnrolmentService enrolmentService = new EnrolmentService();

        //enrolmentService.AfisareEnrolment();

        //Enrolment enrolmentTest = new Enrolment(1, 3, 01012411);
        //enrolmentService.AddEnrolment(enrolmentTest);
        //enrolmentService.SaveData();

        //View view = new View();

        //view.play();

        ViewAdmin admin = new ViewAdmin();

        admin.play();

    }
}