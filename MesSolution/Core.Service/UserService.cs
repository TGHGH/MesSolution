using Component.Tools;
using Core.Db.Repositories;
using Core.Service.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public abstract class UserService : CoreServiceBase,IUserService
    {
        [Import]
        protected IUserRepository UserRepository { get; set; }
        public virtual OperationResult AddUser(Models.User user)
        {
            PublicHelper.CheckArgument(user, "user");
            UserRepository.Insert(user, true);            
            return new OperationResult(OperationResultType.Success, "添加成功。", user);
        }



        public virtual OperationResult DeleteUser(Models.User user)
        {
            PublicHelper.CheckArgument(user, "user");
            int a=UserRepository.Delete(user, true);
            if (a >0)
            {
                return new OperationResult(OperationResultType.Success, "删除成功。", a);
            }
            else
                return new OperationResult(OperationResultType.Success, "删除失败。", a);
        }

        public virtual OperationResult QueryUser(string key)
        {
            PublicHelper.CheckArgument(key, "user");
            Models.User testUser= UserRepository.Entities.Single(u => u.usercode == key);
            if (testUser != null)
            {
                return new OperationResult(OperationResultType.Success, "查询成功。", testUser);
            }
            else
                return new OperationResult(OperationResultType.QueryNull, "指定参数的数据不存在。", key);
        }

        public virtual OperationResult UpdateUser(Models.User user)
        {
            PublicHelper.CheckArgument(user, "user");
            int a = UserRepository.Update(user, true);
            if (a > 0)
            {
                return new OperationResult(OperationResultType.Success, "更改成功。", a);
            }
            else
                return new OperationResult(OperationResultType.Success, "更改失败。", a);
        }
    }
}
