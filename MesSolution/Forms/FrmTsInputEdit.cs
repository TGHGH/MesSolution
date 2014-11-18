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
        private ErrorInfoEditStatus _errInfoStatus;
        public TsErrorCause tec { get; set; }
        public Ts ts { get; set; }
        public CompositionContainer tsCompositionContainer { get; set; }
      
        private enum ErrorInfoEditStatus
        {
            DoNothing,
            UpdateErrorCode,
            AddErrorCause,
            UpdateErrorCause
        }

        private void clearErrorInfo()
        {
            this.RBoxPremunition.Text = string.Empty;
            this.TBoxErrorComponent.Text = string.Empty;
            this.RBoxLocationSelected.Clear();
            this.RBoxLocation.Clear();
            this.RBoxErrorCopSelected.Clear();
            this.RBoxErrorCop.Clear();
        }
        private ErrorInfoEditStatus TSEditStatus
        {
            get
            {
                return this._errInfoStatus;
            }
            set
            {
                this._errInfoStatus = value;
                this.clearErrorInfo();
                if (this._errInfoStatus == ErrorInfoEditStatus.DoNothing)
                {
                    this.TBoxErrorCodeGroupDesc.Text = string.Empty;
                    this.TBoxErrorCodeDesc.Text = string.Empty;
                    this.CBoxErrorCause.Text = string.Empty;
                    this.CBoxErrorCause.Enabled = false;
                    this.CBoxErrorCauseGroup.Enabled = false;
                    this.CBoxErrorCause.Enabled = false;
                    this.CBoxDuty.Enabled = false;
                    this.CBoxSolution.Enabled = false;
                    this.RBoxPremunition.ReadOnly = true;

                    this.enableEditLocation(false);
                    this.enableEditPart(false);

                    this.BtnAdd.Enabled = false;
                    this.BtnAddInfo.Enabled = false;
                    this.BtnDelete.Enabled = false;
                    this.BtnSave.Enabled = false;
                    this.BtnCancel.Enabled = false;
                    // this.btnViewSmart.Enabled = false;
                    //   this.status = "enabled";
                }
                if (this._errInfoStatus == ErrorInfoEditStatus.UpdateErrorCode)
                {
                    this.TBoxErrorComponent.ReadOnly = true;
                    this.CBoxErrorCauseGroup.Enabled = false;
                    this.CBoxErrorCause.Enabled = false;
                    this.CBoxDuty.Enabled = false;
                    this.CBoxSolution.Enabled = false;
                    this.RBoxPremunition.ReadOnly = true;

                    this.enableEditLocation(false);
                    this.enableEditPart(false);

                    this.BtnAdd.Enabled = true;
                    this.BtnAddInfo.Enabled = false;
                    this.BtnDelete.Enabled = false;
                    this.BtnSave.Enabled = true;
                    this.BtnCancel.Enabled = true;
                }
                if (this._errInfoStatus == ErrorInfoEditStatus.AddErrorCause)
                {
                    this.BtnAddInfo.Enabled = true;
                    this.enableEditLocation(true);
                    this.enableEditPart(true);
                    this.BtnDelete.Enabled = false;
                    this.BtnSave.Enabled = true;
                    this.BtnCancel.Enabled = true;
                    //    this.btnViewSmart.Enabled = true;
                    //   this.status = "enabled";
                }
                if (this._errInfoStatus == ErrorInfoEditStatus.UpdateErrorCause)
                {

                    this.TBoxErrorComponent.ReadOnly = true;
                    this.CBoxErrorCauseGroup.Enabled = false;
                    this.CBoxErrorCause.Enabled = false;
                    this.CBoxDuty.Enabled = false;
                    this.CBoxSolution.Enabled = false;
                    this.RBoxPremunition.ReadOnly = true;
                    this.enableEditLocation(true);
                    this.enableEditPart(true);
                    this.BtnAdd.Enabled = false;
                    this.BtnAddInfo.Enabled = true;
                    this.BtnDelete.Enabled = true;
                    this.BtnSave.Enabled = true;
                    this.BtnCancel.Enabled = true;
                    //  this.btnViewSmart.Enabled = false;
                    //   this.status = "disabled";
                }
            }
        }
        private void enableEditLocation(bool enable)
        {
            this.BtnDeleteLocationSelected.Enabled = enable;
            this.BtnAddErrLocation.Enabled = enable;
            this.TBoxErrorLocation.Enabled = enable;
            this.RBoxLocationSelected.Enabled = enable;
            this.RBoxLocation.Enabled = enable;
        }
        private void enableEditPart(bool enable)
        {
            this.BtnDeleteErrCopSelected.Enabled = enable;
            this.BtnAddErrCop.Enabled = enable;
            this.TBoxErrorCop.Enabled = enable;
            this.RBoxErrorCopSelected.Enabled = enable;
            this.RBoxErrorCop.Enabled = enable;
        }

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

        private void TreeFresh(Ts tsTest)
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
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
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
                }
                frm.ShowDialog();
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
                Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(e.Node.Text + "\r");
            }
            if (e.Node.Tag is TsErrorCode)
            {
                TsErrorCode te = (TsErrorCode)e.Node.Tag;
                ClearText();
                TBoxErrorCodeGroupDesc.Text = te.errorCode.ecg.ecgdesc;
                TBoxErrorCodeDesc.Text = te.errorCode.ecdesc;               
            }
            if (e.Node.Tag is TsErrorCause)
            {
                tec = (TsErrorCause)e.Node.Tag;
                BindFresh();
                BtnAddInfo.Enabled = true;
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
                frm.ShowDialog();
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            OperationResult operationResult = tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().SaveTs(ts);
            Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            tsCompositionContainer = null;
            ClearText();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            BtnAddInfo_Click(this, null);
        }
    }
}
