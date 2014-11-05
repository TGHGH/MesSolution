using Component.Tools;
using Core.Models;
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
    public partial class FrmGoodNG : Form
    {
        public AggregateCatalog catalog;
        public FrmGoodNG()
        {
            InitializeComponent();
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMo.Checked)
                tetMo.Enabled = true;
        }

        private void txtMo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                using (CompositionContainer container = new CompositionContainer(catalog))
                {                   
                    OperationResult operationResult = container.GetExportedValue<IFrmGoodNGService>().FindSnCheck(tetMo.Text);
                    if (operationResult.ResultType == OperationResultType.Success)
                    {
                        if (operationResult.AppendData != null)
                        {                            
                            txtLength.Text = ((Item2SnCheck)operationResult.AppendData).SNLENGTH == null ? null : ((Item2SnCheck)operationResult.AppendData).SNLENGTH.ToString();
                            txtPrefix.Text = ((Item2SnCheck)operationResult.AppendData).SNPREFIX;
                            if (txtLength.Text.Length==0)
                                txtLength.Enabled = true;
                            if (txtPrefix.Text.Length==0)
                                txtPrefix.Enabled = true;
                        }

                    }
                    else
                        richTextBox1.AppendText("\n" + operationResult.Message);                    
                }  
            }
            

        }

        private void txtRuningCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tetMo.Text.Length != 0)
                {
                    using (CompositionContainer _container = new CompositionContainer(catalog))
                    {
                        OperationResult operationResult = _container.GetExportedValue<IFrmGoodNGService>().CardGoMo(tetMo.Text, txtLength.Text, txtPrefix.Text,txtRuningCard.Text , Program.rescode, Program.usercode);
                        richTextBox1.AppendText("\n" + operationResult.Message);
                    }
                }
            } 
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
