using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext appDbContext) : IMentorRepository
{
    private readonly AppDbContext _context = appDbContext;

    public bool AddMentor(Mentor mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "insert into mentors(fullname, email, phone, specialization) values(@fullname, @email, @phone, @specialization)";
        var result = connection.Execute(query, mentor);
        return result > 0;
    }

    public bool DeleteMentor(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "delete from mentors where mentorid=@mentorid";
        var result = connection.Execute(query, new { mentorId });
        return result > 0;
    }

    public Mentor GetMentor(int mentorId)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors where mentorid=@mentorid";
        return connection.QuerySingle<Mentor>(query, new { mentorId });
    }

    public List<Mentor> GetMentors()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from mentors";
        return connection.Query<Mentor>(query).ToList();
    }

    public bool UpdateMentor(Mentor mentor)
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "update mentors set fullname=@fullname, email=@email, phone=@phone, specialization=@specialization where mentorid=@mentorid";
        var result = connection.Execute(query, mentor);
        return result > 0;
    }
}
