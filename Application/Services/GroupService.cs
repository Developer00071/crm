using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class GroupService(GroupRepository groupRepository) : IGroupService
{
    private readonly GroupRepository _repository = groupRepository;

    public void AddGroup(Group group)
    {
        var result = _repository.AddGroup(group);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void DeleteGroup(int groupId)
    {
        var result = _repository.DeleteGroup(groupId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public void GetAllGroups()
    {
        var groups = _repository.GetGroups();
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.GroupId} {group.GroupName} {group.CourseId} {group.MentorId} {group.StartDate} {group.EndDate}");
        }
    }

    public void GetGroup(int groupId)
    {
        var group = _repository.GetGroup(groupId);
        Console.WriteLine($"{group.GroupId} {group.GroupName} {group.CourseId} {group.MentorId} {group.StartDate} {group.EndDate}");
    }

    public void UpdateGroup(Group group)
    {
        var result = _repository.UpdateGroup(group);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
