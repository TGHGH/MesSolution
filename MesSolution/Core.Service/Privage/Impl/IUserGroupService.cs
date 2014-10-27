using System;
namespace Core.Service
{
    public interface IUserGroupService
    {
        Component.Tools.OperationResult AddEntity(Core.Models.UserGroup userGroup);
        Component.Tools.OperationResult DeleteEntity(string key);
        Component.Tools.OperationResult FindEntity(string key);
        Component.Tools.OperationResult UpdateEntity(Core.Models.UserGroup userGroup);
        System.Linq.IQueryable<Core.Models.UserGroup> UserGroups();
    }
}
