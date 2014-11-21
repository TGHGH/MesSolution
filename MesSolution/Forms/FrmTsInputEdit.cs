using Component.Tools;
using Core.Models;
using FormApplication.Models;
using FormApplication.Service;
using Forms.Helper;
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

namespace Forms
{
    [Export]
    public partial class FrmTsInputEdit : Form
    {      
        public TsErrorCause tec { get; set; }
        public Ts ts { get; set; }
        public CompositionContainer tsCompositionContainer { get; set; }     
       

        public FrmTsInputEdit()
        {
            InitializeComponent();

        }

        private void FrmTsInputEdit_Load(object sender, EventArgs e)
        {

        }

        private void TBoxSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ('\r'))
            {
                tsCompositionContainer = new CompositionContainer(Program.programCatalog);
                OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().ActionNGConfirm(TBoxSN.Text);
                Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    ts = (Ts)operationResult.AppendData;
                    TreeFresh(ts);
                }
                ClearText();
            }
        }

        public void TreeFresh(Ts tsTest)
        {
            treeView1.Nodes.Clear();           
            TreeNode tn1 = new TreeNode();
            tn1.Tag = tsTest;
            tn1.Text = "TSID：" + tsTest.TSID;
            foreach (var tserrorcode in tsTest.tsErrorCodes)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Tag = tserrorcode;
                tn2.Text = tserrorcode.errorCode.ecdesc;
                foreach (var tserrorcause in tserrorcode.tsErrorCauses)
                {
                    TreeNode tn3 = new TreeNode();
                    tn3.Tag = tserrorcause;
                    tn3.Text = tserrorcause.errorCodeSeason.ecsdesc;
                    tn2.Nodes.Add(tn3);
                }
                tn1.Nodes.Add(tn2);
            }
            treeView1.Nodes.Add(tn1);
            treeView1.ExpandAll();
        }
        public void TreeFresh()
        {
            TreeFresh(ts);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Ts)
            {
                FrmTsInputEdit_TsErrorCode frm = Program.programContainer.GetExportedValue<FrmTsInputEdit_TsErrorCode>();
                OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().TsErrorCauseEdit(((Ts)treeView1.Nodes[0].Tag).rcard);
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    TsErrorCauseSelectCollection tsErrorCauseSelectCollection = (TsErrorCauseSelectCollection)operationResult.AppendData;
                    frm.listBox1.DataSource = tsErrorCauseSelectCollection.errorCodeGroups;
                  
                    frm.listBox1.SelectedItem = null;
                    // frm.listBox2.SelectedItem = null;
                 
                    frm.ShowDialog();
                }

            }
            if (treeView1.SelectedNode.Tag is TsErrorCode)
            {
                FrmTsInputEdit_TsErrorCause frm = Program.programContainer.GetExportedValue<FrmTsInputEdit_TsErrorCause>();
                OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().TsErrorCauseEdit(((Ts)treeView1.Nodes[0].Tag).rcard);
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    TsErrorCauseSelectCollection tsErrorCauseSelectCollection = (TsErrorCauseSelectCollection)operationResult.AppendData;
                    frm.listBox1.DataSource = tsErrorCauseSelectCollection.errorComs;
                    frm.listBox2.DataSource = tsErrorCauseSelectCollection.errorCodeSeasonGroups;
                    frm.listBox4.DataSource = tsErrorCauseSelectCollection.Duties;
                    frm.listBox5.DataSource = tsErrorCauseSelectCollection.solutions;
                    frm.listBox1.SelectedItem = null;
                    frm.listBox2.SelectedItem = null;
                    frm.listBox4.SelectedItem = null;
                    frm.listBox5.SelectedItem = null;
                    frm.tsErrorCode = (TsErrorCode)treeView1.SelectedNode.Tag;
                    frm.formStatus = Forms.FrmTsInputEdit_TsErrorCause.Status.ADD;
                    frm.ShowDialog();
                }
               
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Ts)
            {
                BtnAddInfo.Enabled = true;
                Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(e.Node.Text + "\r");
            }
            if (e.Node.Tag is TsErrorCode)
            {
                TsErrorCode te = (TsErrorCode)e.Node.Tag;
                ClearText();
                TBoxErrorCodeGroupDesc.Text = te.errorCode.ecg.ecgdesc;
                TBoxErrorCodeDesc.Text = te.errorCode.ecdesc;
              //  BtnAddInfo.Enabled = true;
            }
            if (e.Node.Tag is TsErrorCause)
            {
                tec = (TsErrorCause)e.Node.Tag;
                BindFresh();
              //  BtnAddInfo.Enabled = false;
            }
        }
        public void BindFresh()
        {
            TBoxErrorCodeGroupDesc.DataBindings.Clear();
            TBoxErrorCodeDesc.DataBindings.Clear();
            CBoxDuty.DataBindings.Clear();
            CBoxSolution.DataBindings.Clear();
            CBoxErrorCause.DataBindings.Clear();
            CBoxErrorCauseGroup.DataBindings.Clear();
            TBoxErrorComponent.DataBindings.Clear();
            RBoxPremunition.DataBindings.Clear();
            TBoxErrorCodeGroupDesc.DataBindings.Add("Text", tec.tsErrorCode.errorCode.ecg, "ecgdesc");
            TBoxErrorCodeDesc.DataBindings.Add("Text", tec.tsErrorCode.errorCode, "ecdesc");
            CBoxDuty.DataBindings.Add("Text", tec.duty, "dutydesc");
            CBoxSolution.DataBindings.Add("Text", tec.solution, "soldesc");
            CBoxErrorCause.DataBindings.Add("Text", tec.errorCodeSeason, "ecsdesc");
            CBoxErrorCauseGroup.DataBindings.Add("Text", tec.errorCodeSeason.ecsg, "ecsgdesc");
            TBoxErrorComponent.DataBindings.Add("Text", tec.errorCom, "errorComponent");
            RBoxPremunition.DataBindings.Add("Text", tec, "solmemo");
        }
        private void ClearText()
        {
            TBoxErrorCodeGroupDesc.Text = "";
            TBoxErrorCodeDesc.Text = "";
            CBoxDuty.Text = "";
            CBoxSolution.Text = "";
            CBoxErrorCause.Text = "";
            CBoxErrorCauseGroup.Text = "";
            TBoxErrorComponent.Text = "";
            RBoxPremunition.Text = "";
        }
        private void BtnAddInfo_Click(object sender, EventArgs e)
        {
            FrmTsInputEdit_TsErrorCause frm = Program.programContainer.GetExportedValue<FrmTsInputEdit_TsErrorCause>();
            OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().TsErrorCauseEdit(((Ts)treeView1.Nodes[0].Tag).rcard);
            if (operationResult.ResultType == OperationResultType.Success)
            {
                TsErrorCauseSelectCollection tsErrorCauseSelectCollection = (TsErrorCauseSelectCollection)operationResult.AppendData;
                frm.listBox1.DataSource = tsErrorCauseSelectCollection.errorComs;
                frm.listBox2.DataSource = tsErrorCauseSelectCollection.errorCodeSeasonGroups;
                frm.listBox4.DataSource = tsErrorCauseSelectCollection.Duties;
                frm.listBox5.DataSource = tsErrorCauseSelectCollection.solutions;
                frm.textBox1.Text = TBoxErrorCodeGroupDesc.Text;
                frm.textBox2.Text = TBoxErrorCodeDesc.Text;
                frm.richTextBox1.Text = RBoxPremunition.Text;
                int index_listBoxe1 = frm.listBox1.FindString(tec.errorCom.errorComponent);
                if (index_listBoxe1 == -1)
                    MessageBox.Show("Item is not available in ListBox1");
                else
                    frm.listBox1.SetSelected(index_listBoxe1, true);

                int index_listBoxe2 = frm.listBox2.FindString(tec.errorCodeSeason.ecsg.ecsgdesc);
                if (index_listBoxe2 == -1)
                    MessageBox.Show("Item is not available in ListBox2");
                else
                    frm.listBox2.SetSelected(index_listBoxe2, true);

                int index_listBoxe4 = frm.listBox4.FindString(tec.duty.dutydesc);
                if (index_listBoxe4 == -1)
                    MessageBox.Show("Item is not available in ListBox4");
                else
                    frm.listBox4.SetSelected(index_listBoxe4, true);

                int index_listBoxe5 = frm.listBox5.FindString(tec.solution.soldesc);
                if (index_listBoxe5 == -1)
                    MessageBox.Show("Item is not available in ListBox5");
                else
                    frm.listBox5.SetSelected(index_listBoxe5, true);
                frm.formStatus = Forms.FrmTsInputEdit_TsErrorCause.Status.UPDATE;
                frm.ShowDialog();
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().SaveTs(ts);
            Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");
            tsCompositionContainer = null;
            ClearText();
            treeView1.Nodes.Clear();
            TBoxSN.Clear();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            tsCompositionContainer = null;
            ClearText();
            treeView1.Nodes.Clear();
            TBoxSN.Clear();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            BtnAddInfo_Click(this, null);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is TsErrorCause)
            {
                TsErrorCause tec = (TsErrorCause)treeView1.SelectedNode.Tag;
                tec.tsErrorCode.tsErrorCauses.Remove(tec);
                TreeFresh();
            }
            if (treeView1.SelectedNode.Tag is TsErrorCode)
            {
                TsErrorCode tc = (TsErrorCode)treeView1.SelectedNode.Tag;
                tc.ts.tsErrorCodes.Remove(tc);
                TreeFresh();
            }
        }
    }
}
