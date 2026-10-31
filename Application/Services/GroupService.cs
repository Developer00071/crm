using Application.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class GroupService(GroupRepository groupRepository) : IGroupService
{
    private readonly GroupRepository _repository = groupRepository;

    public async Task AddGroupAsync(Group group)
    {
        var result = await _repository.AddGroupAsync(group);
        if (result) Console.WriteLine("Added successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task DeleteGroupAsync(int groupId)
    {
        var result = await _repository.DeleteGroupAsync(groupId);
        if (result) Console.WriteLine("Deleted successfully!");
        else Console.WriteLine("Something went wrong!");
    }

    public async Task GetAllGroupsAsync()
    {
        var groups = await _repository.GetGroupsAsync();
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.GroupId} {group.GroupName} {group.CourseId} {group.MentorId} {group.StartDate} {group.EndDate}");
        }
    }

    public async Task GetGroupAsync(int groupId)
    {
        var group = await _repository.GetGroupAsync(groupId);
        Console.WriteLine($"{group.GroupId} {group.GroupName} {group.CourseId} {group.MentorId} {group.StartDate} {group.EndDate}");
    }

    public async Task UpdateGroupAsync(Group group)
    {
        var result = await _repository.UpdateGroupAsync(group);
        if (result) Console.WriteLine("Updated successfully!");
        else Console.WriteLine("Something went wrong!");
    }
}
