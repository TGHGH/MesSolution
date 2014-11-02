using Component.Tools;
using Core.Models;
using FormApplication.Models;
using FormApplication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    [Export]
    public partial class FormLogin : Form
    {
        public AggregateCatalog catalog;
        public FormLogin()
        {
            InitializeComponent();
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CompositionContainer _container = new CompositionContainer(catalog))
            {
                LoginModel loginModel = new LoginModel();
                loginModel.Account = textBox1.Text;
                loginModel.Password = textBox2.Text;
                loginModel.ResCode = textBox3.Text;
                OperationResult operationResult = _container.GetExportedValue<IUserFormService>().Login(loginModel);
                FrmMain frmMain = ((FrmMain)this.FindForm().Parent.FindForm());
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    frmMain.mdls = (List<Mdl>)operationResult.AppendData;
                    frmMain.MdlInitialize();
                    //FrmMain frmMain = new FrmMain();
                    //frmMain.mdls =(List<Mdl>) operationResult.AppendData;
                    //frmMain.Show();
                    //this.Hide();
                    frmMain.richTextBox1.AppendText("登录成功！");
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
