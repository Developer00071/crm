using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class CourseService(CourseRepository courseRepository) : ICourseService
{
    private readonly CourseRepository _repository = courseRepository;

    public async Task AddCourseAsync(Course course)
    {
        var result = await _repository.AddCourseAsync(course);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteCourseAsync(int courseId)
    {
        var result = await _repository.DeleteCourseAsync(courseId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllCoursesAsync()
    {
        var courses = await _repository.GetCoursesAsync();
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.CourseId} {course.Title} {course.Description} {course.DurationWeeks}");
        }
    }

    public async Task GetCourseAsync(int courseId)
    {
        var course = await _repository.GetCourseAsync(courseId);
        Console.WriteLine($"{course.CourseId} {course.Title} {course.Description} {course.DurationWeeks}");
    }

    public async Task UpdateCourseAsync(Course course)
    {
        var result = await _repository.UpdateCourseAsync(course);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
