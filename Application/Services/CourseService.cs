using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class CourseService(CourseRepository courseRepository) : ICourseService
{
    private readonly CourseRepository _repository = courseRepository;

    public void AddCourse(Course course)
    {
        var result = _repository.AddCourse(course);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void DeleteCourse(int courseId)
    {
        var result = _repository.DeleteCourse(courseId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void GetAllCourses()
    {
        var courses = _repository.GetCourses();
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.CourseId} {course.Title} {course.Description} {course.DurationWeeks}");
        }
    }

    public void GetCourse(int courseId)
    {
        var course = _repository.GetCourse(courseId);
        Console.WriteLine($"{course.CourseId} {course.Title} {course.Description} {course.DurationWeeks}");
    }

    public void UpdateCourse(Course course)
    {
        var result = _repository.UpdateCourse(course);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
