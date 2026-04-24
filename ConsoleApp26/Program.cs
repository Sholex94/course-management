using ConsoleApp26;

public class Program
{
    static List<Student> students = new List<Student>();
    static List<Teacher> teachers = new List<Teacher>();
    static List<Course> courses = new List<Course>();

    static void Main(string[] args)
    {
        SeedData();

        Console.WriteLine("===== Course Management System =====");
        Console.WriteLine("1. View Courses");
        Console.WriteLine("2. View Students");
        Console.WriteLine("3. View Teachers");
        Console.WriteLine("4. Assign Teacher");
        Console.WriteLine("5. Remove Teacher");
        Console.WriteLine("6. Enroll Student");
        Console.WriteLine("7. UnEnroll Student");
        Console.WriteLine("8. View Course");
        Console.WriteLine("0. Exit");

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("===== Courses =====");
                    Console.WriteLine("ID   |     Name        |     Description");
                    foreach (var course in courses)
                    {
                        Console.WriteLine($"{course.Id}      {course.Name}      {course.Description}");
                    }
                    break;
                case "2":
                    Console.WriteLine("===== Students =====");
                    Console.WriteLine("ID   |     Name");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Id}      {student.Name}");
                    }
                    break;
                case "3":
                    Console.WriteLine("===== Teachers =====");
                    Console.WriteLine("ID   |       Name");
                    foreach(var teacher in teachers)
                    {
                        Console.WriteLine($"{teacher.Id}        {teacher.Name}");
                    }
                    break;

                case "4":
                    AssignTeacherToCourse();
                    break;
                case "5":
                    RemoveTeacherFromCourse();
                    break;
                case "6":
                    EnrollStudentInCourse();
                    break;
                case "7":
                    UnEnrollStudentFromCourse();
                    break;
                case "8":
                    ViewCourse();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    public static void SeedData()
    {
        //create students
        Student fisayo = new Student(1, "Fisayo Ojo");
        Student daniel = new Student(2, "olushola Daniel");
        Student josiah = new Student(3, "Olatunbosun Josiah");
        students.Add(fisayo);
        students.Add(daniel);
        students.Add(josiah);

        //create teachers
        Teacher john = new Teacher(1, "John Ojo");
        Teacher felix = new Teacher(2, "Felix Doe");
        teachers.Add(john);
        teachers.Add(felix);

        //create courses
        Course programming = new Course(1, "Programming", "An intriduction to programming concepts");
        Course networking = new Course(2, "Networking", "An intruction to networking concepts");
        Course math = new Course(3, "Math", "An introduction to mathematical concepts");
        Course literature = new Course(4, "Literature", "An introduction to literature concepts");
        Course history = new Course(5, "History", "An introduction to history concepts");
        courses.Add(programming);
        courses.Add(networking);
        courses.Add(math);
        courses.Add(literature);
        courses.Add(history);
    }

    public static void AssignTeacherToCourse()
    {
        //know the teacher 
        Teacher teacher = GetTeacher();
        if (teacher == null)
        {
            Console.WriteLine("Teacher not found");
            return;
        }

        //know the course
        Course course = GetCourse();
        if (course == null)
        {
            Console.WriteLine("Course not found");
            return;
        }
        //assign teacher to the course
        course.AssignTeacher(teacher);
        Console.WriteLine($"Teacher {teacher.Name} assihned to course {course.Name}.");

    }
    public static void RemoveTeacherFromCourse()
    {
        //know the course
        Course course = GetCourse();
        if (course == null)
        {
            Console.WriteLine("Course not found");
            return;
        }
        //Remove Teacher from the course 
        course.RemoveTeacher();
        Console.WriteLine("Teacher removed from course" + course.Name);
    }
    public static void EnrollStudentInCourse()
    {
        //know the student 
        Student student = GetStudent();
        if (student == null)
        {
            Console.WriteLine("Student not found");
            return;
        }
        //know the course
        Course course = GetCourse();
        if (course == null)
        {
            Console.WriteLine("Course not found");
            return;
        }
        //Enroll the student in the course
        course.EnrollStudent(student);
        Console.WriteLine("Student" + student.Name + "enrolled in course" + course.Name);
    }
    public static void UnEnrollStudentFromCourse()
    {
        //know the student
        Student student = GetStudent();
        if (student == null)
        {
            Console.WriteLine("Student not found");
            return;
        }
        //know the course
        Course course = GetCourse();
        if (course == null)
        {
            Console.WriteLine("Course not found");
            return;
        }
        //Unenroll the student from the course
        course.UnEnrollStudent(student);
        Console.WriteLine("Student" + student.Name + "unenrolled from course" + course.Name);
    }
    public static void ViewCourse()
    {
        //know the course
        Course course = GetCourse();
        if (course == null)
        {
            Console.WriteLine("Course not found");
            return;
        }
        Console.WriteLine("Course Name:" + course.Name);
        Console.WriteLine("Course Description:" + course.Description);
        Console.WriteLine("Assigned Teacher:" + (course.AssignedTeacher != null ? course.AssignedTeacher.Name : ""));
        Console.WriteLine("Enrolled Students:");
        foreach (Student student in course.EnrolledStudents)
        {
            Console.WriteLine("-" + student.Name);
        }
    }
    public static Teacher GetTeacher()
    {
        Console.WriteLine("Enter Teacher ID:");
        int teacherId = int.Parse(Console.ReadLine());
        Teacher teacher = null;
        foreach (Teacher t in teachers)
        {
            if (t.Id == teacherId)
            {
                teacher = t;
                Console.WriteLine("Teacher found:" + teacher.Name);
                break;
            }
        }
        return teacher;
    }
    public static Course GetCourse()
    {
        Console.WriteLine("Enter the Course ID:");
        int courseId = int.Parse(Console.ReadLine());

        Course course = null;
        foreach (Course c in courses)
        {
            if (c.Id == courseId)
            {
                course = c;
                Console.WriteLine("Course found:" + course.Name);
                break;
            }
        }
        return course;
    }
    public static Student GetStudent()
    {
        Console.WriteLine("Enter the Student ID");
        int studentId = int.Parse(Console.ReadLine());
        Student student = null;
        foreach (Student s in students)
        {
            if (s.Id == studentId)
            {
                student = s;
                Console.WriteLine("Student found:" + student.Name);
                break;
            }
        }
        return student;
    }
}
