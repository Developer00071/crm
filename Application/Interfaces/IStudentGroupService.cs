using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    void AddStudentGroup(StudentGroup studentGroup);
    void UpdateStudentGroup(StudentGroup studentGroup);
    void DeleteStudentGroup(int studentGroupId);
    void GetStudentGroup(int studentGroupId);
    void GetAllStudentGroups();
}
