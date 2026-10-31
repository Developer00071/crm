using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CourseRepository(AppDbContext appDbContext) : ICourseRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddCourseAsync(Course course)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "insert into courses(title, description, durationweeks) values(@title, @description, @durationweeks)";
        var result = await connection.ExecuteAsync(query, course);
        return result > 0;
    }

    public async Task<bool> DeleteCourseAsync(int courseId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "delete from courses where courseid=@courseid";
        var result = await connection.ExecuteAsync(query, new { courseId });
        return result > 0;
    }

    public async Task<Course> GetCourseAsync(int courseId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from courses where courseid=@courseid";
        return await connection.QuerySingleAsync<Course>(query, new { courseId });
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from courses";
        var courses = await connection.QueryAsync<Course>(query);
        return courses.ToList();
    }

    public async Task<bool> UpdateCourseAsync(Course course)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "update courses set title=@title, description=@description, durationweeks=@durationweeks where courseid=@courseid";
        var result = await connection.ExecuteAsync(query, course);
        return result > 0;
    }
}
