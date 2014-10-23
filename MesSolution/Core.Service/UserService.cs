using Component.Tools;
using Core.Db.Repositories;
using Core.Models;
using Core.Service.Impl;
using Component.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public abstract class UserService : CoreServiceBase, IUserService
    {
        [Import]
        protected IUserRepository UserRepository { get; set; }
        [Import]
        protected DbContext MesContext { get; set; }
        public IQueryable<User> Users()
        {
            return UserRepository.Entities;
        }
        public virtual OperationResult AddEntity(Models.User user)
        {
            return UserRepository.Insert(user, true);
        }


        public virtual OperationResult DeleteEntity(string key)
        {
            return UserRepository.Delete(key, true);
        }

        public virtual OperationResult FindEntity(string key)
        {
            PublicHelper.CheckArgument(key, "user");

            Models.User testUser = UserRepository.GetByKey(key);

            if (testUser != null)
            {
                UserRepository.Entity(testUser).Reload();
                return new OperationResult(OperationResultType.Success, "查询成功。", testUser);
            }
            else
                return new OperationResult(OperationResultType.QueryNull, "指定参数的数据不存在。", key);
        }

        public virtual OperationResult UpdateEntity(User user)
        {
            return UserRepository.Update(user, true);           

        }
        public void test()
        {

        }
    }

}
