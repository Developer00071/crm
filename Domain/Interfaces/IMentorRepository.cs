using Domain.Models;

namespace Domain.Interfaces;

public interface IMentorRepository
{
    bool AddMentor(Mentor mentor);
    bool UpdateMentor(Mentor mentor);
    bool DeleteMentor(int mentorId);
    Mentor GetMentor(int mentorId);
    List<Mentor> GetMentors();
}
