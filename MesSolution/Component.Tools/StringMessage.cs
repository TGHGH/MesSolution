using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Tools
{
    public static class StringMessage
    {
        #region Frms
            #region FrmLogin
        //FrmLogin
        public static string String_FrmLogin_LoginSuccess = "登录成功";
            #endregion
        #endregion

        #region Frm.Service
            #region FrmGoodNGService
        //FrmLogin
        public static string String_FrmGoodNGService_MoCanNotNull = "工单号不能为空";
        public static string String_FrmGoodNGService_MoNotExit = "工单不存在";
        public static string String_FrmGoodNGService_MoStatusError = "工单状态错误";
        public static string String_FrmGoodNGService_MoDontHaveRoute = "工单没有途程";
        public static string String_FrmGoodNGService_SnHadInMo = "已属于该工单";
        public static string String_FrmGoodNGService_SnHadNotInMo = "没有归属工单";
        public static string String_FrmGoodNGService_SnHadFinish = "产品已完工";
        public static string String_FrmGoodNGService_ResNotFirst = "该资源不属于该工单的第一道工序";
        public static string String_FrmGoodNGService_SnIsRunning = "此为在制品，不能归属工单";
        public static string String_FrmGoodNGService_LotNotOp = "该产品没有维护产生送检批工序";
        public static string String_FrmGoodNGService_MoEnough = "工单已满";
        public static string String_FrmGoodNGService_CheckSuccess = "检测成功";
        public static string String_FrmGoodNGService_CollectSuccess = "采集成功";
        public static string String_FrmGoodNGService_ResNotOp = "该资源岗位没有归属工序";
        public static string String_FrmGoodNGService_NowOp = "当前工序为";
        public static string String_FrmGoodNGService_NextOp = " 产品下道工序为";
            #endregion
        #endregion

    }
}
