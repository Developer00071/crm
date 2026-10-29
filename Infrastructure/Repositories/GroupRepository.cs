using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
{
    private readonly AppDbContext _context = appDbContext;

    public bool AddGroup(Group group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into groups(groupname, courseid, mentorid, startdate, enddate) values(@groupname, @courseid, @mentorid, @startdate, @enddate)";
        var result = connection.Execute(query, group);
        return result > 0;
    }

    public bool DeleteGroup(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from groups where groupid=@groupid";
        var result = connection.Execute(query, new { groupId });
        return result > 0;
    }

    public Group GetGroup(int groupId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups where groupid=@groupid";
        return connection.QuerySingle<Group>(query, new { groupId });
    }

    public List<Group> GetGroups()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from groups";
        return connection.Query<Group>(query).ToList();
    }

    public bool UpdateGroup(Group group)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update groups set groupname=@groupname, courseid=@courseid, mentorid=@mentorid, startdate=@startdate, enddate=@enddate where groupid=@groupid";
        var result = connection.Execute(query, group);
        return result > 0;
    }
}
