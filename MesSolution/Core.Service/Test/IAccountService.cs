
using System.Linq;

using Component.Tools;
using Core.Db.Repositories;
using Core.Models;


namespace Core.Service
{
    /// <summary>
    ///     账户模块核心业务契约
    /// </summary>
    public interface IAccountService
    {
        #region 属性

        #endregion

        #region 公共方法

        /// <summary>
        ///     用户登录
        /// </summary>
        /// <param name="loginInfo">登录信息</param>
        /// <returns>业务操作结果</returns>
        OperationResult Login(LoginInfo loginInfo);

        #endregion
    }
}