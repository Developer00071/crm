using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class StudentGroupService(StudentGroupRepository studentGroupRepository) : IStudentGroupService
{
    private readonly StudentGroupRepository _repository = studentGroupRepository;

    public void AddStudentGroup(StudentGroup studentGroup)
    {
        var result = _repository.AddStudentGroup(studentGroup);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void DeleteStudentGroup(int studentGroupId)
    {
        var result = _repository.DeleteStudentGroup(studentGroupId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void GetAllStudentGroups()
    {
        var studentGroups = _repository.GetStudentGroups();
        foreach (var studentGroup in studentGroups)
        {
            Console.WriteLine($"{studentGroup.StudentGroupId} {studentGroup.StudentId} {studentGroup.GroupId} {studentGroup.Status}");
        }
    }

    public void GetStudentGroup(int studentGroupId)
    {
        var studentGroup = _repository.GetStudentGroup(studentGroupId);
        Console.WriteLine($"{studentGroup.StudentGroupId} {studentGroup.StudentId} {studentGroup.GroupId} {studentGroup.Status}");
    }

    public void UpdateStudentGroup(StudentGroup studentGroup)
    {
        var result = _repository.UpdateStudentGroup(studentGroup);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
