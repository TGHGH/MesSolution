using Component.Tools;
using Core.Models;
using Frm.Models;
using Frm.Service;
using Frm.Service.FrmTsInputEdit;
using Frms.Helper;
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
    public partial class FrmTsInputEdit : Form
    {      
        public TsErrorCause currentTsErrorCause { get; set; }
        public Ts currentTs { get; set; }
        public TsErrorCode currentTsErrorCode { get;set;}
        
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
                OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().ActionNgConfirm(TBoxSN.Text);
                Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    currentTs = (Ts)operationResult.AppendData;
                    TreeFresh(currentTs);
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
                if (tserrorcode.tsErrorCauses != null)
                {
                    foreach (var tserrorcause in tserrorcode.tsErrorCauses)
                    {
                        TreeNode tn3 = new TreeNode();
                        tn3.Tag = tserrorcause;
                        tn3.Text = tserrorcause.errorCodeSeason.ecsdesc;
                        tn2.Nodes.Add(tn3);
                    }
                }
                
                tn1.Nodes.Add(tn2);
            }
            treeView1.Nodes.Add(tn1);
            treeView1.ExpandAll();
        }
        public void TreeFresh()
        {
            TreeFresh(currentTs);
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
                    frm.formStatus = Frms.FrmTsInputEdit_TsErrorCode.Status.ADD;
                    frm.ShowDialog();
                    return;
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
                    frm.formStatus = Frms.FrmTsInputEdit_TsErrorCause.Status.ADD;
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
                currentTsErrorCode = (TsErrorCode)e.Node.Tag;
                ClearText();
                TBoxErrorCodeGroupDesc.Text = currentTsErrorCode.errorCode.ecg.ecgdesc;
                TBoxErrorCodeDesc.Text = currentTsErrorCode.errorCode.ecdesc;
              //  BtnAddInfo.Enabled = true;
            }
            if (e.Node.Tag is TsErrorCause)
            {
                currentTsErrorCause = (TsErrorCause)e.Node.Tag;
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
            TBoxErrorCodeGroupDesc.DataBindings.Add("Text", currentTsErrorCause.tsErrorCode.errorCode.ecg, "ecgdesc");
            TBoxErrorCodeDesc.DataBindings.Add("Text", currentTsErrorCause.tsErrorCode.errorCode, "ecdesc");
            CBoxDuty.DataBindings.Add("Text", currentTsErrorCause.duty, "dutydesc");
            CBoxSolution.DataBindings.Add("Text", currentTsErrorCause.solution, "soldesc");
            CBoxErrorCause.DataBindings.Add("Text", currentTsErrorCause.errorCodeSeason, "ecsdesc");
            CBoxErrorCauseGroup.DataBindings.Add("Text", currentTsErrorCause.errorCodeSeason.ecsg, "ecsgdesc");
            TBoxErrorComponent.DataBindings.Add("Text", currentTsErrorCause.errorCom, "errorComponent");
            RBoxPremunition.DataBindings.Add("Text", currentTsErrorCause, "solmemo");
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
           

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().SaveTs(currentTs);
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
            if (((TreeView)sender).SelectedNode.Tag is TsErrorCause)
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
                    int index_listBoxe1 = frm.listBox1.FindString(currentTsErrorCause.errorCom.errorComponent);
                    if (index_listBoxe1 == -1)
                        MessageBox.Show("Item is not available in ListBox1");
                    else
                        frm.listBox1.SetSelected(index_listBoxe1, true);

                    int index_listBoxe2 = frm.listBox2.FindString(currentTsErrorCause.errorCodeSeason.ecsg.ecsgdesc);
                    if (index_listBoxe2 == -1)
                        MessageBox.Show("Item is not available in ListBox2");
                    else
                        frm.listBox2.SetSelected(index_listBoxe2, true);

                    int index_listBoxe4 = frm.listBox4.FindString(currentTsErrorCause.duty.dutydesc);
                    if (index_listBoxe4 == -1)
                        MessageBox.Show("Item is not available in ListBox4");
                    else
                        frm.listBox4.SetSelected(index_listBoxe4, true);

                    int index_listBoxe5 = frm.listBox5.FindString(currentTsErrorCause.solution.soldesc);
                    if (index_listBoxe5 == -1)
                        MessageBox.Show("Item is not available in ListBox5");
                    else
                        frm.listBox5.SetSelected(index_listBoxe5, true);
                    frm.formStatus = Frms.FrmTsInputEdit_TsErrorCause.Status.UPDATE;
                    frm.ShowDialog();
                }
            }
            if (((TreeView)sender).SelectedNode.Tag is TsErrorCode)
            {
                FrmTsInputEdit_TsErrorCode frm = Program.programContainer.GetExportedValue<FrmTsInputEdit_TsErrorCode>();
                OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().TsErrorCauseEdit(((Ts)treeView1.Nodes[0].Tag).rcard);
                if (operationResult.ResultType == OperationResultType.Success)
                {
                    TsErrorCauseSelectCollection tsErrorCauseSelectCollection = (TsErrorCauseSelectCollection)operationResult.AppendData;
                    frm.listBox1.DataSource = tsErrorCauseSelectCollection.errorCodeGroups;
                    int index_listBoxe1 = frm.listBox1.FindString(currentTsErrorCode.errorCode.ecg.ToString());
                    if (index_listBoxe1 == -1)
                        MessageBox.Show("Item is not available in ListBox1");
                    else
                        frm.listBox1.SetSelected(index_listBoxe1, true);
                    frm.formStatus = Frms.FrmTsInputEdit_TsErrorCode.Status.UPDATE;
                    frm.ShowDialog();
                }
            }
            
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
