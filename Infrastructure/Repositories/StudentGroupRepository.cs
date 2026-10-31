using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class StudentGroupRepository(AppDbContext appDbContext) : IStudentGroupRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddStudentGroupAsync(StudentGroup studentGroup)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "insert into studentgroups(studentid, groupid, status) values(@studentid, @groupid, @status)";
        var result = await connection.ExecuteAsync(query, studentGroup);
        return result > 0;
    }

    public async Task<bool> DeleteStudentGroupAsync(int studentGroupId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "delete from studentgroups where studentgroupid=@studentgroupid";
        var result = await connection.ExecuteAsync(query, new { studentGroupId });
        return result > 0;
    }

    public async Task<StudentGroup> GetStudentGroupAsync(int studentGroupId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from studentgroups where studentgroupid=@studentgroupid";
        return await connection.QuerySingleAsync<StudentGroup>(query, new { studentGroupId });
    }

    public async Task<List<StudentGroup>> GetStudentGroupsAsync()
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from studentgroups";
        var res = await connection.QueryAsync<StudentGroup>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "update studentgroups set studentid=@studentid, groupid=@groupid, status=@status where studentgroupid=@studentgroupid";
        var result = await connection.ExecuteAsync(query, studentGroup);
        return result > 0;
    }
}
