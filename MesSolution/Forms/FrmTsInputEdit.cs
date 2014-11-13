using Component.Tools;
using Core.Models;
using FormApplication.Service;
using Forms.Helper;
//using MESModel3;
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
        public class FormStatus
        {
            public static string Update = "Update";
            public static string Ready = "Ready";
            public static string NoReady = "NoReady";
        }
        private enum ErrorInfoEditStatus
        {
            DoNothing,
            UpdateErrorCode,
            AddErrorCause,
            UpdateErrorCause
        }

        private void clearErrorInfo()
        {
            if (this.CBoxErrorCauseGroup.Items.Count > 0)
            {
                this.CBoxErrorCauseGroup.SelectedIndex = 0;
            }
            if (this.CBoxErrorCause.Items.Count > 0)
            {
                this.CBoxErrorCause.SelectedIndex = 0;
            }
            this.CBoxDuty.SelectedIndex = -1;
            this.CBoxSolution.SelectedIndex = -1;
            this.RBoxPremunition.Text = string.Empty;
            this.TBoxErrorComponent.Text = string.Empty;
            this.RBoxLocationSelected.Clear();
            this.RBoxLocation.Clear();
            this.RBoxErrorCopSelected.Clear();
            this.RBoxErrorCop.Clear();
         //   this._locationHelper.Clear();
         //   this._partHelper.Clear();
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
                    //    this.btnViewSmart.Enabled = true;
                 //   this.status = "enabled";
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
                using (CompositionContainer testContainer = new CompositionContainer(Program.programCatalog))
                {
                    OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().ActionNGConfirm(TBoxSN.Text);                    
                    Program.programContainer.GetExportedValue<FrmMain>().richTextBox1.AppendText(operationResult.Message + "\r");
                    if (operationResult.ResultType == OperationResultType.Success)
                    {
                        treeView1.Nodes.Clear();
                        Ts ts=(Ts)operationResult.AppendData;
                        TreeNode tn1 = new TreeNode();
                        tn1.Tag = ts;
                        tn1.Text = "TSID：" + ts.TSID;
                        foreach (var tserrorcode in ts.tsErrorCodes)
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
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
