using System;
using Component.Tools;
using System.Linq;
using Core.Models;
namespace Core.Service
{
    public interface IUserService
    {
        OperationResult AddEntity(User user, bool isSave = true);
        OperationResult DeleteEntity(string key, bool isSave = true);
        OperationResult FindEntity(string key);
        OperationResult UpdateEntity(User user, bool isSave = true);
        IQueryable<User> Users();

        OperationResult Login(LoginInfo2 loginInfo);
    }
}
