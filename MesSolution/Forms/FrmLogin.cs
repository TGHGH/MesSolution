using System.Globalization;
using System.Threading;
using Component.Tools;
using Core.Models;
using Frm.Models;
using Frm.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    [Export]
    public partial class FrmLogin : Form
    {
      
        public FrmLogin()
        {
            InitializeComponent();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CompositionContainer container = new CompositionContainer(Program.programCatalog))
            {
                LoginModel loginModel = new LoginModel();   
                loginModel.Account = textBox1.Text;
                loginModel.Password = textBox2.Text;
                loginModel.ResCode = textBox3.Text;                
                OperationResult operationResult = container.GetExportedValue<IUserFormService>().Login(loginModel);
                FrmMain frmMain = Program.programContainer.GetExportedValue<FrmMain>();
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    frmMain.Mdls = (List<Mdl>)operationResult.AppendData;
                    frmMain.MdlInitialize();
                    frmMain.richTextBox1.AppendText(StringMessage.String_FrmLogin_LoginSuccess + "\n");
                    Program.usercode = loginModel.Account;
                    Program.rescode  = loginModel.ResCode;
                }
                else
                {
                    frmMain.richTextBox1.AppendText(operationResult.Message);
                }                  
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
             
        }

    }
}
