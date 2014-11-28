using Component.Tools;
using Core.Models;
using Frm.Models;
using Frm.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    [Export]
    public partial class FrmTsComplete : Form
    {
        public CompositionContainer tsCompositionContainer { get; set; }
        public TsCompleteModel tsCompleteModel { get; set; }
        public FrmTsComplete()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                tsCompositionContainer = new CompositionContainer(Program.programCatalog);
                OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().TsCompleteCheck(textBox1.Text);
                Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    tsCompleteModel= (TsCompleteModel)operationResult.AppendData;
                    textBox3.Text = tsCompleteModel.ts.mocode;
                    textBox4.Text = tsCompleteModel.ts.itemcode;
                    comboBox1.DataSource = tsCompleteModel.list;
                    int a = comboBox1.FindString(tsCompleteModel.ts.frmroutecode);
                    comboBox1.SelectedIndex = a;
                    int b = comboBox2.FindString(tsCompleteModel.ts.frmopcode);
                    comboBox2.SelectedIndex = b;
                    button1.Enabled = true;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem!=null)
            comboBox2.DataSource = ((Route)comboBox1.SelectedItem).Ops.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tsCompleteModel.moString = textBox3.Text;
            tsCompleteModel.itemString = textBox4.Text;
            tsCompleteModel.routeString = comboBox1.SelectedValue.ToString();
            tsCompleteModel.opString = comboBox2.SelectedValue.ToString();
            OperationResult operationResult= tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().TsCompleteConfirm(tsCompleteModel);
            Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");
            button1.Enabled = false;
        }
    }
}
