using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddGroupAsync(Group group)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "insert into groups(groupname, courseid, mentorid, startdate, enddate) values(@groupname, @courseid, @mentorid, @startdate, @enddate)";
        var result = await connection.ExecuteAsync(query, group);
        return result > 0;
    }


    public async Task<bool> DeleteGroupAsync(int groupId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "delete from groups where groupid=@groupid";
        var result = await connection.ExecuteAsync(query, new { groupId });
        return result > 0;
    }


    public async Task<Group> GetGroupAsync(int groupId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query =  "select * from groups where groupid=@groupid";
        return await connection.QuerySingleAsync<Group>(query, new { groupId });
    }


    public async Task<List<Group>> GetGroupsAsync()
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from groups";
        var res = await connection.QueryAsync<Group>(query);
        return res.ToList();
    }


    public async Task<bool> UpdateGroupAsync(Group group)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "update groups set groupname=@groupname, courseid=@courseid, mentorid=@mentorid, startdate=@startdate, enddate=@enddate where groupid=@groupid";
        var result = await connection.ExecuteAsync(query, group);
        return result > 0;
    }
}
