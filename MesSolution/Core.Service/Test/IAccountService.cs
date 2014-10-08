
using System.Linq;

using Component.Tools;
using Core.Db.Repositories;
using Core.Models;


namespace Core.Service
{
    /// <summary>
    ///     �˻�ģ�����ҵ����Լ
    /// </summary>
    public interface IAccountService
    {
        #region ����

        #endregion

        #region ��������

        /// <summary>
        ///     �û���¼
        /// </summary>
        /// <param name="loginInfo">��¼��Ϣ</param>
        /// <returns>ҵ��������</returns>
        OperationResult Login(LoginInfo loginInfo);

        #endregion
    }
}