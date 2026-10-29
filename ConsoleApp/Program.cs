using Application.Services;
using Domain.Enums;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

var appDbContext = new AppDbContext();

var studentService = new StudentService(new StudentRepository(appDbContext));
var courseService = new CourseService(new CourseRepository(appDbContext));
var groupService = new GroupService(new GroupRepository(appDbContext));
var mentorService = new MentorService(new MentorRepository(appDbContext));
var studentGroupService = new StudentGroupService(new StudentGroupRepository(appDbContext));

while (true)
{
    Console.WriteLine("==================================");
    Console.WriteLine("1 - Students");
    Console.WriteLine("2 - Courses");
    Console.WriteLine("3 - Groups");
    Console.WriteLine("4 - Mentors");
    Console.WriteLine("5 - Student groups");
    Console.WriteLine("0 - Exit");
    Console.WriteLine("==================================");
    Console.Write("Choose option: ");
    var option = Console.ReadLine();
    Console.WriteLine("==================================");

    switch (option)
    {
        case "1":
            ManageStudents(studentService);
            break;
        case "2":
            ManageCourses(courseService);
            break;
        case "3":
            ManageGroups(groupService);
            break;
        case "4":
            ManageMentors(mentorService);
            break;
        case "5":
            ManageStudentGroups(studentGroupService);
            break;
        case "0":
            Console.WriteLine("Exiting ...");
            return;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

static void ManageStudents(StudentService studentService)
{
    Console.WriteLine("1 - Show all students");
    Console.WriteLine("2 - Show student");
    Console.WriteLine("3 - Add student");
    Console.WriteLine("4 - Update student");
    Console.WriteLine("5 - Delete student");
    Console.Write("Choose option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            studentService.GetAllStudents();
            break;
        case "2":
            Console.Write("Enter id: ");
            var studentId = Convert.ToInt32(Console.ReadLine());
            studentService.GetStudent(studentId);
            break;
        case "3":
            studentService.AddStudent(new Student
            {
                Fullname = ReadString("Enter fullname: "),
                Email = ReadString("Enter email: "),
                Phone = ReadString("Enter phone: "),
                EnrollmentDate = ReadDateOnly("Enter enrollment date (yyyy-MM-dd): ")
            });
            break;
        case "4":
            studentService.UpdateStudent(new Student
            {
                StudentId = ReadInt("Enter id: "),
                Fullname = ReadString("Enter fullname: "),
                Email = ReadString("Enter email: "),
                Phone = ReadString("Enter phone: "),
                EnrollmentDate = ReadDateOnly("Enter enrollment date (yyyy-MM-dd): ")
            });
            break;
        case "5":
            studentService.DeleteStudent(ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void ManageCourses(CourseService courseService)
{
    Console.WriteLine("1 - Show all courses");
    Console.WriteLine("2 - Show course");
    Console.WriteLine("3 - Add course");
    Console.WriteLine("4 - Update course");
    Console.WriteLine("5 - Delete course");
    Console.Write("Choose option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            courseService.GetAllCourses();
            break;
        case "2":
            courseService.GetCourse(ReadInt("Enter id: "));
            break;
        case "3":
            courseService.AddCourse(new Course
            {
                Title = ReadString("Enter title: "),
                Description = ReadString("Enter description: "),
                DurationWeeks = ReadInt("Enter duration in weeks: ")
            });
            break;
        case "4":
            courseService.UpdateCourse(new Course
            {
                CourseId = ReadInt("Enter id: "),
                Title = ReadString("Enter title: "),
                Description = ReadString("Enter description: "),
                DurationWeeks = ReadInt("Enter duration in weeks: ")
            });
            break;
        case "5":
            courseService.DeleteCourse(ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void ManageGroups(GroupService groupService)
{
    Console.WriteLine("1 - Show all groups");
    Console.WriteLine("2 - Show group");
    Console.WriteLine("3 - Add group");
    Console.WriteLine("4 - Update group");
    Console.WriteLine("5 - Delete group");
    Console.Write("Choose option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            groupService.GetAllGroups();
            break;
        case "2":
            groupService.GetGroup(ReadInt("Enter id: "));
            break;
        case "3":
            groupService.AddGroup(new Group
            {
                GroupName = ReadString("Enter group name: "),
                CourseId = ReadInt("Enter course id: "),
                MentorId = ReadInt("Enter mentor id: "),
                StartDate = ReadDateOnly("Enter start date (yyyy-MM-dd): "),
                EndDate = ReadDateOnly("Enter end date (yyyy-MM-dd): ")
            });
            break;
        case "4":
            groupService.UpdateGroup(new Group
            {
                GroupId = ReadInt("Enter id: "),
                GroupName = ReadString("Enter group name: "),
                CourseId = ReadInt("Enter course id: "),
                MentorId = ReadInt("Enter mentor id: "),
                StartDate = ReadDateOnly("Enter start date (yyyy-MM-dd): "),
                EndDate = ReadDateOnly("Enter end date (yyyy-MM-dd): ")
            });
            break;
        case "5":
            groupService.DeleteGroup(ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void ManageMentors(MentorService mentorService)
{
    Console.WriteLine("1 - Show all mentors");
    Console.WriteLine("2 - Show mentor");
    Console.WriteLine("3 - Add mentor");
    Console.WriteLine("4 - Update mentor");
    Console.WriteLine("5 - Delete mentor");
    Console.Write("Choose option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            mentorService.GetAllMentors();
            break;
        case "2":
            mentorService.GetMentor(ReadInt("Enter id: "));
            break;
        case "3":
            mentorService.AddMentor(new Mentor
            {
                Fullname = ReadString("Enter fullname: "),
                Email = ReadString("Enter email: "),
                Phone = ReadString("Enter phone: "),
                Specialization = ReadString("Enter specialization: ")
            });
            break;
        case "4":
            mentorService.UpdateMentor(new Mentor
            {
                MentorId = ReadInt("Enter id: "),
                Fullname = ReadString("Enter fullname: "),
                Email = ReadString("Enter email: "),
                Phone = ReadString("Enter phone: "),
                Specialization = ReadString("Enter specialization: ")
            });
            break;
        case "5":
            mentorService.DeleteMentor(ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static void ManageStudentGroups(StudentGroupService studentGroupService)
{
    Console.WriteLine("1 - Show all relations");
    Console.WriteLine("2 - Show relation");
    Console.WriteLine("3 - Add relation");
    Console.WriteLine("4 - Update relation");
    Console.WriteLine("5 - Delete relation");
    Console.Write("Choose option: ");
    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            studentGroupService.GetAllStudentGroups();
            break;
        case "2":
            studentGroupService.GetStudentGroup(ReadInt("Enter id: "));
            break;
        case "3":
            studentGroupService.AddStudentGroup(new StudentGroup
            {
                StudentId = ReadInt("Enter student id: "),
                GroupId = ReadInt("Enter group id: "),
                Status = (StudentGroupStatus)Enum.Parse(typeof(StudentGroupStatus), ReadString("Enter status (Active/Left/Finished): "))
            });
            break;
        case "4":
            studentGroupService.UpdateStudentGroup(new StudentGroup
            {
                StudentGroupId = ReadInt("Enter id: "),
                StudentId = ReadInt("Enter student id: "),
                GroupId = ReadInt("Enter group id: "),
                Status = (StudentGroupStatus)Enum.Parse(typeof(StudentGroupStatus), ReadString("Enter status (Active/Left/Finished): "))
            });
            break;
        case "5":
            studentGroupService.DeleteStudentGroup(ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static string ReadString(string message)
{
    Console.Write(message);
    return Console.ReadLine() ?? string.Empty;
}

static int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

static DateOnly ReadDateOnly(string message)
{
    Console.Write(message);
    return DateOnly.Parse(Console.ReadLine() ?? DateTime.Today.ToString("yyyy-MM-dd"));
}
