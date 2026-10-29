using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class MentorService(MentorRepository mentorRepository) : IMentorService
{
    private readonly MentorRepository _repository = mentorRepository;

    public void AddMentor(Mentor mentor)
    {
        var result = _repository.AddMentor(mentor);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void DeleteMentor(int mentorId)
    {
        var result = _repository.DeleteMentor(mentorId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void GetAllMentors()
    {
        var mentors = _repository.GetMentors();
        foreach (var mentor in mentors)
        {
            Console.WriteLine($"{mentor.MentorId} {mentor.Fullname} {mentor.Email} {mentor.Phone} {mentor.Specialization}");
        }
    }

    public void GetMentor(int mentorId)
    {
        var mentor = _repository.GetMentor(mentorId);
        Console.WriteLine($"{mentor.MentorId} {mentor.Fullname} {mentor.Email} {mentor.Phone} {mentor.Specialization}");
    }

    public void UpdateMentor(Mentor mentor)
    {
        var result = _repository.UpdateMentor(mentor);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
