using Component.Tools;
using Core.Models;
using Core.Service;
using FormApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication.Service
{
    [Export(typeof(IUserFormContract))]
    public class UserSiteContract:UserService,IUserFormContract
    {
        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="model">登录模型信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Login(LoginModel model)
        {
            PublicHelper.CheckArgument(model, "model");
            LoginInfo2 loginInfo = new LoginInfo2
            {
                Access = model.Account,
                Password = model.Password,               
            };
            OperationResult result = base.Login(loginInfo);
            if (result.ResultType == OperationResultType.Success)
            {
                
                User user = (User)result.AppendData;
                List<UserGroup> usergroups=(List<UserGroup>) user.UserGroups;
                List<Res> reses=new List<Res>();                
                foreach (var a in usergroups)
                {
                    reses.AddRange((List<Res>)a.Ress);
                }
                if (reses.SingleOrDefault(r=>r.RESCODE==model.ResCode)==null)
                {
                    result.ResultType = OperationResultType.Error;
                    result.Message = "用户没有该资源的权限";
                }
            }
            return result;
        }
    
    }
}
