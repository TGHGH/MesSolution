using System;
using Component.Tools;
using System.Linq;
using Core.Models;
namespace Core.Service
{
    public interface IUserGroupService
    {
        OperationResult AddEntity(UserGroup userGroup);
        OperationResult DeleteEntity(string key);
        OperationResult FindEntity(string key);
        OperationResult UpdateEntity(UserGroup userGroup);
        IQueryable<UserGroup> UserGroups();
    }
}
