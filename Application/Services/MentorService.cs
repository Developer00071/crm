using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository) : IMentorService
{
    private readonly MentorRepository _repository = mentorRepository;

    public async Task AddMentorAsync(Mentor mentor)
    {
        var result = await _repository.AddMentorAsync(mentor);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteMentorAsync(int mentorId)
    {
        var result = await _repository.DeleteMentorAsync(mentorId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllMentorsAsync()
    {
        var mentors = await _repository.GetMentorsAsync();
        foreach (var mentor in mentors)
        {
            Console.WriteLine($"{mentor.MentorId} {mentor.Fullname} {mentor.Email} {mentor.Phone} {mentor.Specialization}");
        }
    }

    public async Task GetMentorAsync(int mentorId)
    {
        var mentor = await _repository.GetMentorAsync(mentorId);
        Console.WriteLine($"{mentor.MentorId} {mentor.Fullname} {mentor.Email} {mentor.Phone} {mentor.Specialization}");
    }

    public async Task UpdateMentorAsync(Mentor mentor)
    {
        var result = await _repository.UpdateMentorAsync(mentor);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
