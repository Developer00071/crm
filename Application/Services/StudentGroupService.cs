using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentGroupService(StudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private readonly StudentGroupRepository _repository = studentGroupRepository;

    public async Task AddStudentGroupAsync(StudentGroup studentGroup)
    {
        var result = await _repository.AddStudentGroupAsync(studentGroup);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteStudentGroupAsync(int studentGroupId)
    {
        var result = await _repository.DeleteStudentGroupAsync(studentGroupId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllStudentGroupsAsync()
    {
        var studentGroups = await _repository.GetStudentGroupsAsync();
        foreach (var studentGroup in studentGroups)
        {
            Console.WriteLine($"{studentGroup.StudentGroupId} {studentGroup.StudentId} {studentGroup.GroupId} {studentGroup.Status}");
        }
    }

    public async Task GetStudentGroupAsync(int studentGroupId)
    {
        var studentGroup = await _repository.GetStudentGroupAsync(studentGroupId);
        Console.WriteLine($"{studentGroup.StudentGroupId} {studentGroup.StudentId} {studentGroup.GroupId} {studentGroup.Status}");
    }

    public async Task UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        var result = await _repository.UpdateStudentGroupAsync(studentGroup);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
