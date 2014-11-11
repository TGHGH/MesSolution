using Component.Tools;
using Core.Models;
using Core.Service;
using FormApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication.Service
{
    [Export(typeof(IUserFormService))]
    public class UserFormService:UserService,IUserFormService
    {
        [Import]
        public IMoFormService iMoFormService { get; set; }
        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="model">登录模型信息</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Login(LoginModel model)
        {
            PublicHelper.CheckArgument(model, "model");
            Validator.ValidateObject(model, new ValidationContext(model));
            LoginInfo2 loginInfo = new LoginInfo2
            {
                Access = model.Account,
                Password = model.Password,  
            };
            OperationResult result = base.Login(loginInfo);
            if (result.ResultType == OperationResultType.Success)
            {
                
                User user = (User)result.AppendData;
                List<UserGroup> usergroups =user.UserGroups.ToList();
                List<Res> reses = new List<Res>();
                List<Mdl> mdls = new List<Mdl>();
                foreach (var a in usergroups)
                {
                    reses.AddRange(a.Ress);
                    mdls.AddRange(a.Mdls);
                }
                if (reses.SingleOrDefault(r=>r.RESCODE==model.ResCode)==null)
                {
                    result.ResultType = OperationResultType.Error;
                    result.Message = "用户没有该资源的权限";
                }
                result.AppendData = mdls;                    
            }
            return result;
        }
    
    }
}
