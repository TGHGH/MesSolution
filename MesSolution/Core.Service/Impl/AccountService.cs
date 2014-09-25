
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Component.Tools;
using Core.Db.Repositories;
using Core.Models;



namespace Core.Service.Impl
{
    /// <summary>
    ///     �˻�ģ�����ҵ��ʵ��
    /// </summary>
    public abstract class AccountService : CoreServiceBase, IAccountService
    {
        #region ����

        #region �ܱ���������

        /// <summary>
        /// ��ȡ������ �û���Ϣ���ݷ��ʶ���
        /// </summary>
        [Import]
        protected IMemberRepository MemberRepository { get; set; }

        /// <summary>
        /// ��ȡ������ ��¼��¼��Ϣ���ݷ��ʶ���
        /// </summary>
        [Import]
        protected ILoginLogRepository LoginLogRepository { get; set; }

        #endregion

        #endregion

        /// <summary>
        /// �û���¼
        /// </summary>
        /// <param name="loginInfo">��¼��Ϣ</param>
        /// <returns>ҵ��������</returns>
        public virtual OperationResult Login(LoginInfo loginInfo)
        {
            PublicHelper.CheckArgument(loginInfo, "loginInfo");
            Member member = MemberRepository.Entities.SingleOrDefault(m => m.UserName == loginInfo.Access || m.Email == loginInfo.Access);
            if (member == null)
            {
                return new OperationResult(OperationResultType.QueryNull, "ָ���˺ŵ��û������ڡ�");
            }
            if (member.Password != loginInfo.Password)
            {
                return new OperationResult(OperationResultType.Warning, "��¼���벻��ȷ��");
            }
            LoginLog loginLog = new LoginLog { IpAddress = loginInfo.IpAddress, Member = member };
            LoginLogRepository.Insert(loginLog);
            return new OperationResult(OperationResultType.Success, "��¼�ɹ���", member);
        }
    }
}