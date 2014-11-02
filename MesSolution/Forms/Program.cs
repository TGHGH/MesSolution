using Forms.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new ThreadExceptionEventHandler(Program.otherException);
                Application.Run(new FrmMain());
            }
            catch (Exception e)
            {
                string logStr = string.Concat(new string[]
				{
					DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
					"\t",
					e.Message,
					"\t",
					e.Source
				});
                FileLog.FileLogOut("Client.log", logStr);
            }
           
        }
        private static void otherException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception.Source.Trim() != "Infragistics.Win.UltraWinGrid.v3.2" && e.Exception.Source.Trim() != "Infragistics.Win.UltraWinExplorerBar.v3.2")
            {
                //    Application.GetInfoForm().Add("$CS_System_Error:" + e.Exception.Message);

                string logStr = string.Concat(new string[]
				{
					DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"),
					"\t",
					e.Exception.Message,
					"\t",
					e.Exception.Source
				});
                FileLog.FileLogOut("Client.log", logStr);
                //    ((SQLDomainDataProvider)ApplicationService.Current().DataProvider).PersistBroker.CloseConnection();
            }
        }
    }
}
