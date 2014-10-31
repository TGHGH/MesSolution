using Component.Tools;
using FormApplication.Models;
using FormApplication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                textBox4.Text = _container.GetExportedValue<IUserFormService>().Login(loginModel).Message;                
            }
                           
                
          
           
           
        }

    
    }
}
