using Domain.Models;

namespace Application.Interfaces;

public interface IGroupService
{
    void AddGroup(Group group);
    void UpdateGroup(Group group);
    void DeleteGroup(int groupId);
    void GetGroup(int groupId);
    void GetAllGroups();
}
