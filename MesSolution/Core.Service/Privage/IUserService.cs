using System;
using Component.Tools;
using System.Linq;
using Core.Models;
namespace Core.Service
{
    public interface IUserService
    {
        OperationResult AddEntity(User user);
        OperationResult DeleteEntity(string key);
        OperationResult FindEntity(string key);      
        OperationResult UpdateEntity(User user);
        IQueryable<User> Users();

        OperationResult Login(LoginInfo2 loginInfo);
    }
}
