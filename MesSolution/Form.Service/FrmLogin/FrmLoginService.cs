using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Component.Tools;
using Core.Models;
using Frm.Models.FrmLogin;

namespace Frm.Service.FrmLogin
{
    public interface IFrmLoginService
    {
        OperationResult Login(LoginModel model);
    }

    [Export(typeof(IFrmLoginService))]
    public class FrmLoginService : IFrmLoginService
    {
        [Import]
        public IUserFormService UserFormService { get; set; }
        public OperationResult Login(LoginModel model)
        {
            var operationResult = new OperationResult(OperationResultType.Error);
            Validator.ValidateObject(model, new ValidationContext(model));
            User user = UserFormService.Users().SingleOrDefault(m => m.usercode == model.Account);
            if (user == null)
            {
                operationResult.Message = Properties.Resources.FrmLogin_Login_UserNotExist;
                return operationResult;
            }
            if (user.userpwd != model.Password)
            {
                operationResult.Message = Properties.Resources.FrmLogin_Login_PasswordError;
                return operationResult;
            }

            var usergroups = user.UserGroups.ToList();
            var reses = new List<Res>();
            var mdls = new List<Mdl>();
            foreach (var a in usergroups)
            {
                reses.AddRange(a.Ress);
                mdls.AddRange(a.Mdls);
            }
            if (reses.SingleOrDefault(r => r.RESCODE == model.ResCode) == null)
            {
                operationResult.Message = Properties.Resources.FrmLogin_Login_UserNotRes;
                return operationResult;
            }
            operationResult.ResultType=OperationResultType.Success;
            operationResult.AppendData = mdls;
            operationResult.Message = Properties.Resources.FrmLogin_Login_LoginSuccess;
            return operationResult;
        }
    }
}
