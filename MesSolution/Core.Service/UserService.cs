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
    public class UserService:IUserService,CoreServiceBase
    {
        [Import]
        protected IUserRepository UserRepository { get; set; }
        public Component.Tools.OperationResult AddUser(Models.User user)
        {
            PublicHelper.CheckArgument(user, "user");
            UserRepository.Insert(user, true);
            return new OperationResult(OperationResultType.Success, "添加成功。", user);
        }
              
    }
}
