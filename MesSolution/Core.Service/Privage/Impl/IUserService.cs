using System;
namespace Core.Service
{
    public interface IUserService
    {
        Component.Tools.OperationResult AddEntity(Core.Models.User user);
        Component.Tools.OperationResult DeleteEntity(string key);
        Component.Tools.OperationResult FindEntity(string key);
        void test();
        Component.Tools.OperationResult UpdateEntity(Core.Models.User user);
        System.Linq.IQueryable<Core.Models.User> Users();
    }
}
