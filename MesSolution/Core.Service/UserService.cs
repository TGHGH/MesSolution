using Component.Tools;
using Core.Db.Repositories;
using Core.Models;
using Core.Service.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public abstract class UserService : CoreServiceBase,IUserService
    {
        [Import]
        protected IUserRepository UserRepository { get; set; }
        public IQueryable<User> Users()
        {
            return UserRepository.Entities;
        } 
        public virtual OperationResult AddUser(Models.User user)
        {
            PublicHelper.CheckArgument(user, "user");
            
            User testUser = UserRepository.Entities.SingleOrDefault(u => u.usercode == user.usercode);                   
                       
            if (testUser == null)
            {
                UserRepository.Insert(user, true);
                return new OperationResult(OperationResultType.Success, "添加成功。", user);

            }
            else
            {
                return new OperationResult(OperationResultType.IllegalOperation, "已存在。", user);
            }
            
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
           
            Models.User testUser= UserRepository.GetByKey("65128044");
            UserRepository.Entity(testUser).Reload();
            if (testUser != null)
            {
                return new OperationResult(OperationResultType.Success, "查询成功。", testUser);
            }
            else
                return new OperationResult(OperationResultType.QueryNull, "指定参数的数据不存在。", key);
        }

        public virtual OperationResult UpdateUser(string usercode,string pwd)
        {
           // PublicHelper.CheckArgument(user, "user");
            Models.User testUser = UserRepository.GetByKey("65128044");           
            if (testUser == null)
            {
                 return new OperationResult(OperationResultType.Success, "更改失败。", null);
            }
            else{            
                try
                {
                    testUser.userpwd = pwd;
                    this.UnitOfWork.Commit();
                    this.UnitOfWork.Rollback();
                }
                catch (DataAccessException e)
                {
                    if (e.Message.Equals("数据访问层异常：提交数据更新时发生同步异常："))
                    {
                        UserRepository.Entity(testUser).Reload();
                        testUser.userpwd = pwd;
                        this.UnitOfWork.Commit();
                        this.UnitOfWork.Rollback();
                    }                   
                }
                
                return new OperationResult(OperationResultType.Success, "更改成功。", testUser);
            }                    
                        
        }

        public virtual OperationResult UpdateUser2(string usercode, string pwd)
        {
            Models.User testUser = UserRepository.GetByKey(usercode);            
            if (testUser != null)
            {
                testUser.userpwd = pwd;
                this.UnitOfWork.Commit();
                return new OperationResult(OperationResultType.Success, "更改成功。", testUser);
            }
            else
                return new OperationResult(OperationResultType.Error, "没有此帐号。", testUser);
            
        }
        
    }
}
