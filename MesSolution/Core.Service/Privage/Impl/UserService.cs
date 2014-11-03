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
        public IQueryable<User> Users()
        {
            return UserRepository.Entities;
        }
        public virtual OperationResult AddEntity(Models.User user, bool isSave = true)
        {

            return UserRepository.Insert(user, isSave);   
           
        }


        public virtual OperationResult DeleteEntity(string key, bool isSave = true)
        {
            return UserRepository.Delete(key, isSave);
        }

        public virtual OperationResult FindEntity(string key)
        {
           PublicHelper.CheckArgument(key, "user");

           return UserRepository.GetByKey(key);
            
        }

        public virtual OperationResult UpdateEntity(User user, bool isSave = true)
        {
            return UserRepository.Update(user, isSave);           

        }




        public OperationResult Login(LoginInfo2 loginInfo)
        {
            PublicHelper.CheckArgument(loginInfo, "loginInfo");
            User user = UserRepository.Entities.SingleOrDefault(m=>m.usercode==loginInfo.Access);
            if (user == null)
            {
                return new OperationResult(OperationResultType.QueryNull, "指定账号的用户不存在。");
            }
            if (user.userpwd != loginInfo.Password)
            {
                return new OperationResult(OperationResultType.Warning, "登录密码不正确。");
            }
            //登录LOG
            //LoginLog loginLog = new LoginLog { IpAddress = loginInfo.IpAddress, Member = member };
            //LoginLogRepository.Insert(loginLog);
            return new OperationResult(OperationResultType.Success, "登录成功。", user);
        }
    }

}
