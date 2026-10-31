using Domain.Models;

namespace Application.Interfaces;

public interface IStudentGroupService
{
    Task AddStudentGroupAsync(StudentGroup studentGroup);
    Task UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task DeleteStudentGroupAsync(int studentGroupId);
    Task GetStudentGroupAsync(int studentGroupId);
    Task GetAllStudentGroupsAsync();
}
