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
    var option = await Console.In.ReadLineAsync();
    Console.WriteLine("==================================");

    switch (option)
    {
        case "1":
            await ManageStudents(studentService);
            break;
        case "2":
            await ManageCourses(courseService);
            break;
        case "3":
            await ManageGroups(groupService);
            break;
        case "4":
            await ManageMentors(mentorService);
            break;
        case "5":
            await ManageStudentGroups(studentGroupService);
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

static async Task ManageStudents(StudentService studentService)
{
    Console.WriteLine("1 - Show all students");
    Console.WriteLine("2 - Show student");
    Console.WriteLine("3 - Add student");
    Console.WriteLine("4 - Update student");
    Console.WriteLine("5 - Delete student");
    Console.Write("Choose option: ");
    var option = await Console.In.ReadLineAsync();

    switch (option)
    {
        case "1":
            await studentService.GetAllStudentsAsync();
            break;
        case "2":
            Console.Write("Enter id: ");
            var studentId = Convert.ToInt32(await Console.In.ReadLineAsync());
            await studentService.GetStudentAsync(studentId);
            break;
        case "3":
            await studentService.AddStudentAsync(new Student
            {
                Fullname = await ReadString("Enter fullname: "),
                Email = await ReadString("Enter email: "),
                Phone = await ReadString("Enter phone: "),
                EnrollmentDate = await ReadDateOnly("Enter enrollment date (yyyy-MM-dd): ")
            });
            break;
        case "4":
            await studentService.UpdateStudentAsync(new Student
            {
                StudentId = await ReadInt("Enter id: "),
                Fullname = await ReadString("Enter fullname: "),
                Email = await ReadString("Enter email: "),
                Phone = await ReadString("Enter phone: "),
                EnrollmentDate = await ReadDateOnly("Enter enrollment date (yyyy-MM-dd): ")
            });
            break;
        case "5":
            await studentService.DeleteStudentAsync(await ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static async Task ManageCourses(CourseService courseService)
{
    Console.WriteLine("1 - Show all courses");
    Console.WriteLine("2 - Show course");
    Console.WriteLine("3 - Add course");
    Console.WriteLine("4 - Update course");
    Console.WriteLine("5 - Delete course");
    Console.Write("Choose option: ");
    var option = await Console.In.ReadLineAsync();

    switch (option)
    {
        case "1":
            await courseService.GetAllCoursesAsync();
            break;
        case "2":
            await courseService.GetCourseAsync(await ReadInt("Enter id: "));
            break;
        case "3":
            await courseService.AddCourseAsync(new Course
            {
                Title = await ReadString("Enter title: "),
                Description = await ReadString("Enter description: "),
                DurationWeeks = await ReadInt("Enter duration in weeks: ")
            });
            break;
        case "4":
            await courseService.UpdateCourseAsync(new Course
            {
                CourseId = await ReadInt("Enter id: "),
                Title = await ReadString("Enter title: "),
                Description = await ReadString("Enter description: "),
                DurationWeeks = await ReadInt("Enter duration in weeks: ")
            });
            break;
        case "5":
            await courseService.DeleteCourseAsync(await ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static async Task ManageGroups(GroupService groupService)
{
    Console.WriteLine("1 - Show all groups");
    Console.WriteLine("2 - Show group");
    Console.WriteLine("3 - Add group");
    Console.WriteLine("4 - Update group");
    Console.WriteLine("5 - Delete group");
    Console.Write("Choose option: ");
    var option = await Console.In.ReadLineAsync();

    switch (option)
    {
        case "1":
            await groupService.GetAllGroupsAsync();
            break;
        case "2":
            await groupService.GetGroupAsync(await ReadInt("Enter id: "));
            break;
        case "3":
            await groupService.AddGroupAsync(new Group
            {
                GroupName = await ReadString("Enter group name: "),
                CourseId = await ReadInt("Enter course id: "),
                MentorId = await ReadInt("Enter mentor id: "),
                StartDate = await ReadDateOnly("Enter start date (yyyy-MM-dd): "),
                EndDate = await ReadDateOnly("Enter end date (yyyy-MM-dd): ")
            });
            break;
        case "4":
            await groupService.UpdateGroupAsync(new Group
            {
                GroupId = await ReadInt("Enter id: "),
                GroupName = await ReadString("Enter group name: "),
                CourseId = await ReadInt("Enter course id: "),
                MentorId = await ReadInt("Enter mentor id: "),
                StartDate = await ReadDateOnly("Enter start date (yyyy-MM-dd): "),
                EndDate = await ReadDateOnly("Enter end date (yyyy-MM-dd): ")
            });
            break;
        case "5":
            await groupService.DeleteGroupAsync(await ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static async Task ManageMentors(MentorService mentorService)
{
    Console.WriteLine("1 - Show all mentors");
    Console.WriteLine("2 - Show mentor");
    Console.WriteLine("3 - Add mentor");
    Console.WriteLine("4 - Update mentor");
    Console.WriteLine("5 - Delete mentor");
    Console.Write("Choose option: ");
    var option = await Console.In.ReadLineAsync();

    switch (option)
    {
        case "1":
            await mentorService.GetAllMentorsAsync();
            break;
        case "2":
            await mentorService.GetMentorAsync(await ReadInt("Enter id: "));
            break;
        case "3":
            await mentorService.AddMentorAsync(new Mentor
            {
                Fullname = await ReadString("Enter fullname: "),
                Email = await ReadString("Enter email: "),
                Phone = await ReadString("Enter phone: "),
                Specialization = await ReadString("Enter specialization: ")
            });
            break;
        case "4":
            await mentorService.UpdateMentorAsync(new Mentor
            {
                MentorId = await ReadInt("Enter id: "),
                Fullname = await ReadString("Enter fullname: "),
                Email = await ReadString("Enter email: "),
                Phone = await ReadString("Enter phone: "),
                Specialization = await ReadString("Enter specialization: ")
            });
            break;
        case "5":
            await mentorService.DeleteMentorAsync(await ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static async Task ManageStudentGroups(StudentGroupService studentGroupService)
{
    Console.WriteLine("1 - Show all relations");
    Console.WriteLine("2 - Show relation");
    Console.WriteLine("3 - Add relation");
    Console.WriteLine("4 - Update relation");
    Console.WriteLine("5 - Delete relation");
    Console.Write("Choose option: ");
    var option = await Console.In.ReadLineAsync();

    switch (option)
    {
        case "1":
            await studentGroupService.GetAllStudentGroupsAsync();
            break;
        case "2":
            await studentGroupService.GetStudentGroupAsync(await ReadInt("Enter id: "));
            break;
        case "3":
            await studentGroupService.AddStudentGroupAsync(new StudentGroup
            {
                StudentId = await ReadInt("Enter student id: "),
                GroupId = await ReadInt("Enter group id: "),
                Status = (StudentGroupStatus)Enum.Parse(typeof(StudentGroupStatus), await ReadString("Enter status (Active/Left/Finished): "))
            });
            break;
        case "4":
            await studentGroupService.UpdateStudentGroupAsync(new StudentGroup
            {
                StudentGroupId = await ReadInt("Enter id: "),
                StudentId = await ReadInt("Enter student id: "),
                GroupId = await ReadInt("Enter group id: "),
                Status = (StudentGroupStatus)Enum.Parse(typeof(StudentGroupStatus), await ReadString("Enter status (Active/Left/Finished): "))
            });
            break;
        case "5":
            await studentGroupService.DeleteStudentGroupAsync(await ReadInt("Enter id: "));
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

static async Task<string> ReadString(string message)
{
    Console.Write(message);
    return await Console.In.ReadLineAsync() ?? string.Empty;
}

static async Task<int> ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(await Console.In.ReadLineAsync());
}

static async Task<DateOnly> ReadDateOnly(string message)
{
    Console.Write(message);
    return DateOnly.Parse(await Console.In.ReadLineAsync() ?? DateTime.Today.ToString("yyyy-MM-dd"));
}
