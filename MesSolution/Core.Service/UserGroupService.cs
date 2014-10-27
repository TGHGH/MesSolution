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
    public abstract class UserGroupService : CoreServiceBase, IUserGroupService
    {
        [Import]
        protected IUserGroupRepository userGroupRepository { get; set; }      
        public IQueryable<UserGroup> UserGroups()
        {
            return userGroupRepository.Entities;
        }
        public virtual OperationResult AddEntity(Models.UserGroup userGroup)
        {
           
            return userGroupRepository.Insert(userGroup, true);        
           
        }


        public virtual OperationResult DeleteEntity(string key)
        {
            return userGroupRepository.Delete(key, true);
        }

        public virtual OperationResult FindEntity(string key)
        {
           PublicHelper.CheckArgument(key, "userGroup");

           return userGroupRepository.GetByKey(key);
            
        }

        public virtual OperationResult UpdateEntity(UserGroup userGroup)
        {
            return userGroupRepository.Update(userGroup, true);           

        }
        public void test()
        {

        }
    }

}
