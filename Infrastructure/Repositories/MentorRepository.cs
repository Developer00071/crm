using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class MentorRepository(AppDbContext appDbContext) : IMentorRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddMentorAsync(Mentor mentor)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "insert into mentors(fullname, email, phone, specialization) values(@fullname, @email, @phone, @specialization)";
        var result = await connection.ExecuteAsync(query, mentor);
        return result > 0;
    }

    public async Task<bool> DeleteMentorAsync(int mentorId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "delete from mentors where mentorid=@mentorid";
        var result = await connection.ExecuteAsync(query, new { mentorId });
        return result > 0;
    }

    public async Task<Mentor> GetMentorAsync(int mentorId)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from mentors where mentorid=@mentorid";
        return await connection.QuerySingleAsync<Mentor>(query, new { mentorId });
    }

    public async Task<List<Mentor>> GetMentorsAsync()
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "select * from mentors";
        var res = await connection.QueryAsync<Mentor>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateMentorAsync(Mentor mentor)
    {
        await using var connection = _context.Connection();
        await connection.OpenAsync();
        var query = "update mentors set fullname=@fullname, email=@email, phone=@phone, specialization=@specialization where mentorid=@mentorid";
        var result = await connection.ExecuteAsync(query, mentor);
        return result > 0;
    }
}
