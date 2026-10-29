using Domain.Models;

namespace Domain.Interfaces;

public interface IStudentGroupRepository
{
    bool AddStudentGroup(StudentGroup studentGroup);
    bool UpdateStudentGroup(StudentGroup studentGroup);
    bool DeleteStudentGroup(int studentGroupId);
    StudentGroup GetStudentGroup(int studentGroupId);
    List<StudentGroup> GetStudentGroups();
}
