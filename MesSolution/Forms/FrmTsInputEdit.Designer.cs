namespace Forms
{
    partial class FrmTsInputEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.TBoxMemo = new System.Windows.Forms.TextBox();
            this.TBoxSN = new System.Windows.Forms.TextBox();
            this.BtnErrInfo = new System.Windows.Forms.Button();
            this.LabMemo = new System.Windows.Forms.Label();
            this.LabSN = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnAddInfo = new System.Windows.Forms.Button();
            this.RBoxPremunition = new System.Windows.Forms.RichTextBox();
            this.CBoxDuty = new System.Windows.Forms.ComboBox();
            this.CBoxErrorCause = new System.Windows.Forms.ComboBox();
            this.CBoxSolution = new System.Windows.Forms.ComboBox();
            this.CBoxErrorCauseGroup = new System.Windows.Forms.ComboBox();
            this.TBoxErrorComponent = new System.Windows.Forms.TextBox();
            this.LabPremunition = new System.Windows.Forms.Label();
            this.LabSolution = new System.Windows.Forms.Label();
            this.LabDuty = new System.Windows.Forms.Label();
            this.LabErrorCauseGroup = new System.Windows.Forms.Label();
            this.LabErrorCause = new System.Windows.Forms.Label();
            this.LabErrorComponent = new System.Windows.Forms.Label();
            this.LabErrorCodeGroupDesc = new System.Windows.Forms.Label();
            this.LabErrorCodeDesc = new System.Windows.Forms.Label();
            this.TBoxErrorCodeGroupDesc = new System.Windows.Forms.TextBox();
            this.TBoxErrorCodeDesc = new System.Windows.Forms.TextBox();
            this.LabErrorLocationSelected = new System.Windows.Forms.Label();
            this.LabErrorLocation = new System.Windows.Forms.Label();
            this.BtnDeleteLocationSelected = new System.Windows.Forms.Button();
            this.BtnAddErrLocation = new System.Windows.Forms.Button();
            this.TBoxErrorLocation = new System.Windows.Forms.TextBox();
            this.RBoxLocationSelected = new System.Windows.Forms.RichTextBox();
            this.RBoxLocation = new System.Windows.Forms.RichTextBox();
            this.LabErrorCopSelected = new System.Windows.Forms.Label();
            this.LabCop = new System.Windows.Forms.Label();
            this.BtnDeleteErrCopSelected = new System.Windows.Forms.Button();
            this.BtnAddErrCop = new System.Windows.Forms.Button();
            this.TBoxErrorCop = new System.Windows.Forms.TextBox();
            this.RBoxErrorCopSelected = new System.Windows.Forms.RichTextBox();
            this.RBoxErrorCop = new System.Windows.Forms.RichTextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TBoxMemo);
            this.panel1.Controls.Add(this.TBoxSN);
            this.panel1.Controls.Add(this.BtnErrInfo);
            this.panel1.Controls.Add(this.LabMemo);
            this.panel1.Controls.Add(this.LabSN);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 47);
            this.panel1.TabIndex = 0;
            // 
            // TBoxMemo
            // 
            this.TBoxMemo.Location = new System.Drawing.Point(331, 15);
            this.TBoxMemo.Name = "TBoxMemo";
            this.TBoxMemo.Size = new System.Drawing.Size(100, 21);
            this.TBoxMemo.TabIndex = 4;
            // 
            // TBoxSN
            // 
            this.TBoxSN.Location = new System.Drawing.Point(93, 14);
            this.TBoxSN.Name = "TBoxSN";
            this.TBoxSN.Size = new System.Drawing.Size(124, 21);
            this.TBoxSN.TabIndex = 3;
            this.TBoxSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBoxSN_KeyPress);
            // 
            // BtnErrInfo
            // 
            this.BtnErrInfo.Location = new System.Drawing.Point(579, 14);
            this.BtnErrInfo.Name = "BtnErrInfo";
            this.BtnErrInfo.Size = new System.Drawing.Size(90, 23);
            this.BtnErrInfo.TabIndex = 2;
            this.BtnErrInfo.Text = "维护不良信息";
            this.BtnErrInfo.UseVisualStyleBackColor = true;
            // 
            // LabMemo
            // 
            this.LabMemo.AutoSize = true;
            this.LabMemo.Location = new System.Drawing.Point(285, 18);
            this.LabMemo.Name = "LabMemo";
            this.LabMemo.Size = new System.Drawing.Size(29, 12);
            this.LabMemo.TabIndex = 1;
            this.LabMemo.Text = "备注";
            // 
            // LabSN
            // 
            this.LabSN.AutoSize = true;
            this.LabSN.Location = new System.Drawing.Point(22, 18);
            this.LabSN.Name = "LabSN";
            this.LabSN.Size = new System.Drawing.Size(65, 12);
            this.LabSN.TabIndex = 0;
            this.LabSN.Text = "产品序列号";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(-1, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 496);
            this.treeView1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnAddInfo);
            this.panel2.Controls.Add(this.RBoxPremunition);
            this.panel2.Controls.Add(this.CBoxDuty);
            this.panel2.Controls.Add(this.CBoxErrorCause);
            this.panel2.Controls.Add(this.CBoxSolution);
            this.panel2.Controls.Add(this.CBoxErrorCauseGroup);
            this.panel2.Controls.Add(this.TBoxErrorComponent);
            this.panel2.Controls.Add(this.LabPremunition);
            this.panel2.Controls.Add(this.LabSolution);
            this.panel2.Controls.Add(this.LabDuty);
            this.panel2.Controls.Add(this.LabErrorCauseGroup);
            this.panel2.Controls.Add(this.LabErrorCause);
            this.panel2.Controls.Add(this.LabErrorComponent);
            this.panel2.Location = new System.Drawing.Point(126, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 160);
            this.panel2.TabIndex = 2;
            // 
            // BtnAddInfo
            // 
            this.BtnAddInfo.Location = new System.Drawing.Point(14, 137);
            this.BtnAddInfo.Name = "BtnAddInfo";
            this.BtnAddInfo.Size = new System.Drawing.Size(75, 23);
            this.BtnAddInfo.TabIndex = 12;
            this.BtnAddInfo.Text = "选择";
            this.BtnAddInfo.UseVisualStyleBackColor = true;
            // 
            // RBoxPremunition
            // 
            this.RBoxPremunition.Location = new System.Drawing.Point(358, 95);
            this.RBoxPremunition.Name = "RBoxPremunition";
            this.RBoxPremunition.Size = new System.Drawing.Size(150, 36);
            this.RBoxPremunition.TabIndex = 11;
            this.RBoxPremunition.Text = "";
            // 
            // CBoxDuty
            // 
            this.CBoxDuty.FormattingEnabled = true;
            this.CBoxDuty.Location = new System.Drawing.Point(358, 53);
            this.CBoxDuty.Name = "CBoxDuty";
            this.CBoxDuty.Size = new System.Drawing.Size(150, 20);
            this.CBoxDuty.TabIndex = 10;
            // 
            // CBoxErrorCause
            // 
            this.CBoxErrorCause.FormattingEnabled = true;
            this.CBoxErrorCause.Location = new System.Drawing.Point(358, 14);
            this.CBoxErrorCause.Name = "CBoxErrorCause";
            this.CBoxErrorCause.Size = new System.Drawing.Size(150, 20);
            this.CBoxErrorCause.TabIndex = 9;
            // 
            // CBoxSolution
            // 
            this.CBoxSolution.FormattingEnabled = true;
            this.CBoxSolution.Location = new System.Drawing.Point(95, 95);
            this.CBoxSolution.Name = "CBoxSolution";
            this.CBoxSolution.Size = new System.Drawing.Size(157, 20);
            this.CBoxSolution.TabIndex = 8;
            // 
            // CBoxErrorCauseGroup
            // 
            this.CBoxErrorCauseGroup.FormattingEnabled = true;
            this.CBoxErrorCauseGroup.Location = new System.Drawing.Point(95, 53);
            this.CBoxErrorCauseGroup.Name = "CBoxErrorCauseGroup";
            this.CBoxErrorCauseGroup.Size = new System.Drawing.Size(157, 20);
            this.CBoxErrorCauseGroup.TabIndex = 7;
            // 
            // TBoxErrorComponent
            // 
            this.TBoxErrorComponent.Location = new System.Drawing.Point(95, 11);
            this.TBoxErrorComponent.Name = "TBoxErrorComponent";
            this.TBoxErrorComponent.Size = new System.Drawing.Size(157, 21);
            this.TBoxErrorComponent.TabIndex = 6;
            // 
            // LabPremunition
            // 
            this.LabPremunition.AutoSize = true;
            this.LabPremunition.Location = new System.Drawing.Point(275, 98);
            this.LabPremunition.Name = "LabPremunition";
            this.LabPremunition.Size = new System.Drawing.Size(53, 12);
            this.LabPremunition.TabIndex = 5;
            this.LabPremunition.Text = "预防措施";
            // 
            // LabSolution
            // 
            this.LabSolution.AutoSize = true;
            this.LabSolution.Location = new System.Drawing.Point(12, 98);
            this.LabSolution.Name = "LabSolution";
            this.LabSolution.Size = new System.Drawing.Size(53, 12);
            this.LabSolution.TabIndex = 4;
            this.LabSolution.Text = "解决方案";
            // 
            // LabDuty
            // 
            this.LabDuty.AutoSize = true;
            this.LabDuty.Location = new System.Drawing.Point(275, 56);
            this.LabDuty.Name = "LabDuty";
            this.LabDuty.Size = new System.Drawing.Size(41, 12);
            this.LabDuty.TabIndex = 3;
            this.LabDuty.Text = "责任别";
            // 
            // LabErrorCauseGroup
            // 
            this.LabErrorCauseGroup.AutoSize = true;
            this.LabErrorCauseGroup.Location = new System.Drawing.Point(12, 56);
            this.LabErrorCauseGroup.Name = "LabErrorCauseGroup";
            this.LabErrorCauseGroup.Size = new System.Drawing.Size(65, 12);
            this.LabErrorCauseGroup.TabIndex = 2;
            this.LabErrorCauseGroup.Text = "不良原因组";
            // 
            // LabErrorCause
            // 
            this.LabErrorCause.AutoSize = true;
            this.LabErrorCause.Location = new System.Drawing.Point(275, 20);
            this.LabErrorCause.Name = "LabErrorCause";
            this.LabErrorCause.Size = new System.Drawing.Size(53, 12);
            this.LabErrorCause.TabIndex = 1;
            this.LabErrorCause.Text = "不良原因";
            // 
            // LabErrorComponent
            // 
            this.LabErrorComponent.AutoSize = true;
            this.LabErrorComponent.Location = new System.Drawing.Point(12, 14);
            this.LabErrorComponent.Name = "LabErrorComponent";
            this.LabErrorComponent.Size = new System.Drawing.Size(53, 12);
            this.LabErrorComponent.TabIndex = 0;
            this.LabErrorComponent.Text = "不良组件";
            // 
            // LabErrorCodeGroupDesc
            // 
            this.LabErrorCodeGroupDesc.AutoSize = true;
            this.LabErrorCodeGroupDesc.Location = new System.Drawing.Point(126, 68);
            this.LabErrorCodeGroupDesc.Name = "LabErrorCodeGroupDesc";
            this.LabErrorCodeGroupDesc.Size = new System.Drawing.Size(89, 12);
            this.LabErrorCodeGroupDesc.TabIndex = 3;
            this.LabErrorCodeGroupDesc.Text = "不良代码组描述";
            // 
            // LabErrorCodeDesc
            // 
            this.LabErrorCodeDesc.AutoSize = true;
            this.LabErrorCodeDesc.Location = new System.Drawing.Point(401, 68);
            this.LabErrorCodeDesc.Name = "LabErrorCodeDesc";
            this.LabErrorCodeDesc.Size = new System.Drawing.Size(77, 12);
            this.LabErrorCodeDesc.TabIndex = 4;
            this.LabErrorCodeDesc.Text = "不良代码描述";
            // 
            // TBoxErrorCodeGroupDesc
            // 
            this.TBoxErrorCodeGroupDesc.Location = new System.Drawing.Point(221, 65);
            this.TBoxErrorCodeGroupDesc.Name = "TBoxErrorCodeGroupDesc";
            this.TBoxErrorCodeGroupDesc.Size = new System.Drawing.Size(157, 21);
            this.TBoxErrorCodeGroupDesc.TabIndex = 5;
            // 
            // TBoxErrorCodeDesc
            // 
            this.TBoxErrorCodeDesc.Location = new System.Drawing.Point(484, 65);
            this.TBoxErrorCodeDesc.Name = "TBoxErrorCodeDesc";
            this.TBoxErrorCodeDesc.Size = new System.Drawing.Size(150, 21);
            this.TBoxErrorCodeDesc.TabIndex = 6;
            // 
            // LabErrorLocationSelected
            // 
            this.LabErrorLocationSelected.AutoSize = true;
            this.LabErrorLocationSelected.Location = new System.Drawing.Point(126, 268);
            this.LabErrorLocationSelected.Name = "LabErrorLocationSelected";
            this.LabErrorLocationSelected.Size = new System.Drawing.Size(77, 12);
            this.LabErrorLocationSelected.TabIndex = 7;
            this.LabErrorLocationSelected.Text = "已选不良位置";
            // 
            // LabErrorLocation
            // 
            this.LabErrorLocation.AutoSize = true;
            this.LabErrorLocation.Location = new System.Drawing.Point(389, 268);
            this.LabErrorLocation.Name = "LabErrorLocation";
            this.LabErrorLocation.Size = new System.Drawing.Size(53, 12);
            this.LabErrorLocation.TabIndex = 8;
            this.LabErrorLocation.Text = "不良位置";
            // 
            // BtnDeleteLocationSelected
            // 
            this.BtnDeleteLocationSelected.Location = new System.Drawing.Point(259, 263);
            this.BtnDeleteLocationSelected.Name = "BtnDeleteLocationSelected";
            this.BtnDeleteLocationSelected.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteLocationSelected.TabIndex = 9;
            this.BtnDeleteLocationSelected.Text = "删除";
            this.BtnDeleteLocationSelected.UseVisualStyleBackColor = true;
            // 
            // BtnAddErrLocation
            // 
            this.BtnAddErrLocation.Location = new System.Drawing.Point(578, 263);
            this.BtnAddErrLocation.Name = "BtnAddErrLocation";
            this.BtnAddErrLocation.Size = new System.Drawing.Size(75, 23);
            this.BtnAddErrLocation.TabIndex = 10;
            this.BtnAddErrLocation.Text = "添加";
            this.BtnAddErrLocation.UseVisualStyleBackColor = true;
            // 
            // TBoxErrorLocation
            // 
            this.TBoxErrorLocation.Location = new System.Drawing.Point(472, 265);
            this.TBoxErrorLocation.Name = "TBoxErrorLocation";
            this.TBoxErrorLocation.Size = new System.Drawing.Size(100, 21);
            this.TBoxErrorLocation.TabIndex = 11;
            // 
            // RBoxLocationSelected
            // 
            this.RBoxLocationSelected.Location = new System.Drawing.Point(126, 292);
            this.RBoxLocationSelected.Name = "RBoxLocationSelected";
            this.RBoxLocationSelected.Size = new System.Drawing.Size(252, 80);
            this.RBoxLocationSelected.TabIndex = 12;
            this.RBoxLocationSelected.Text = "";
            // 
            // RBoxLocation
            // 
            this.RBoxLocation.Location = new System.Drawing.Point(391, 292);
            this.RBoxLocation.Name = "RBoxLocation";
            this.RBoxLocation.Size = new System.Drawing.Size(262, 80);
            this.RBoxLocation.TabIndex = 13;
            this.RBoxLocation.Text = "";
            // 
            // LabErrorCopSelected
            // 
            this.LabErrorCopSelected.AutoSize = true;
            this.LabErrorCopSelected.Location = new System.Drawing.Point(126, 392);
            this.LabErrorCopSelected.Name = "LabErrorCopSelected";
            this.LabErrorCopSelected.Size = new System.Drawing.Size(77, 12);
            this.LabErrorCopSelected.TabIndex = 14;
            this.LabErrorCopSelected.Text = "已选不良零件";
            // 
            // LabCop
            // 
            this.LabCop.AutoSize = true;
            this.LabCop.Location = new System.Drawing.Point(389, 392);
            this.LabCop.Name = "LabCop";
            this.LabCop.Size = new System.Drawing.Size(53, 12);
            this.LabCop.TabIndex = 15;
            this.LabCop.Text = "不良零件";
            // 
            // BtnDeleteErrCopSelected
            // 
            this.BtnDeleteErrCopSelected.Location = new System.Drawing.Point(259, 387);
            this.BtnDeleteErrCopSelected.Name = "BtnDeleteErrCopSelected";
            this.BtnDeleteErrCopSelected.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteErrCopSelected.TabIndex = 16;
            this.BtnDeleteErrCopSelected.Text = "删除";
            this.BtnDeleteErrCopSelected.UseVisualStyleBackColor = true;
            // 
            // BtnAddErrCop
            // 
            this.BtnAddErrCop.Location = new System.Drawing.Point(578, 387);
            this.BtnAddErrCop.Name = "BtnAddErrCop";
            this.BtnAddErrCop.Size = new System.Drawing.Size(75, 23);
            this.BtnAddErrCop.TabIndex = 17;
            this.BtnAddErrCop.Text = "添加";
            this.BtnAddErrCop.UseVisualStyleBackColor = true;
            // 
            // TBoxErrorCop
            // 
            this.TBoxErrorCop.Location = new System.Drawing.Point(472, 387);
            this.TBoxErrorCop.Name = "TBoxErrorCop";
            this.TBoxErrorCop.Size = new System.Drawing.Size(100, 21);
            this.TBoxErrorCop.TabIndex = 18;
            // 
            // RBoxErrorCopSelected
            // 
            this.RBoxErrorCopSelected.Location = new System.Drawing.Point(126, 416);
            this.RBoxErrorCopSelected.Name = "RBoxErrorCopSelected";
            this.RBoxErrorCopSelected.Size = new System.Drawing.Size(252, 96);
            this.RBoxErrorCopSelected.TabIndex = 19;
            this.RBoxErrorCopSelected.Text = "";
            // 
            // RBoxErrorCop
            // 
            this.RBoxErrorCop.Location = new System.Drawing.Point(391, 416);
            this.RBoxErrorCop.Name = "RBoxErrorCop";
            this.RBoxErrorCop.Size = new System.Drawing.Size(262, 96);
            this.RBoxErrorCop.TabIndex = 20;
            this.RBoxErrorCop.Text = "";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(126, 526);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 21;
            this.BtnAdd.Text = "添加";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(238, 526);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 22;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(355, 526);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 23;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(472, 526);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 24;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(578, 526);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(75, 23);
            this.BtnQuit.TabIndex = 25;
            this.BtnQuit.Text = "退出";
            this.BtnQuit.UseVisualStyleBackColor = true;
            // 
            // FrmTsInputEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 552);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.RBoxErrorCop);
            this.Controls.Add(this.RBoxErrorCopSelected);
            this.Controls.Add(this.TBoxErrorCop);
            this.Controls.Add(this.BtnAddErrCop);
            this.Controls.Add(this.BtnDeleteErrCopSelected);
            this.Controls.Add(this.LabCop);
            this.Controls.Add(this.LabErrorCopSelected);
            this.Controls.Add(this.RBoxLocation);
            this.Controls.Add(this.RBoxLocationSelected);
            this.Controls.Add(this.TBoxErrorLocation);
            this.Controls.Add(this.BtnAddErrLocation);
            this.Controls.Add(this.BtnDeleteLocationSelected);
            this.Controls.Add(this.LabErrorLocation);
            this.Controls.Add(this.LabErrorLocationSelected);
            this.Controls.Add(this.TBoxErrorCodeDesc);
            this.Controls.Add(this.TBoxErrorCodeGroupDesc);
            this.Controls.Add(this.LabErrorCodeDesc);
            this.Controls.Add(this.LabErrorCodeGroupDesc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTsInputEdit";
            this.Text = "FrmTsInputEdit";
            this.Load += new System.EventHandler(this.FrmTsInputEdit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TBoxMemo;
        private System.Windows.Forms.TextBox TBoxSN;
        private System.Windows.Forms.Button BtnErrInfo;
        private System.Windows.Forms.Label LabMemo;
        private System.Windows.Forms.Label LabSN;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnAddInfo;
        private System.Windows.Forms.RichTextBox RBoxPremunition;
        private System.Windows.Forms.ComboBox CBoxDuty;
        private System.Windows.Forms.ComboBox CBoxErrorCause;
        private System.Windows.Forms.ComboBox CBoxSolution;
        private System.Windows.Forms.ComboBox CBoxErrorCauseGroup;
        private System.Windows.Forms.TextBox TBoxErrorComponent;
        private System.Windows.Forms.Label LabPremunition;
        private System.Windows.Forms.Label LabSolution;
        private System.Windows.Forms.Label LabDuty;
        private System.Windows.Forms.Label LabErrorCauseGroup;
        private System.Windows.Forms.Label LabErrorCause;
        private System.Windows.Forms.Label LabErrorComponent;
        private System.Windows.Forms.Label LabErrorCodeGroupDesc;
        private System.Windows.Forms.Label LabErrorCodeDesc;
        private System.Windows.Forms.TextBox TBoxErrorCodeGroupDesc;
        private System.Windows.Forms.TextBox TBoxErrorCodeDesc;
        private System.Windows.Forms.Label LabErrorLocationSelected;
        private System.Windows.Forms.Label LabErrorLocation;
        private System.Windows.Forms.Button BtnDeleteLocationSelected;
        private System.Windows.Forms.Button BtnAddErrLocation;
        private System.Windows.Forms.TextBox TBoxErrorLocation;
        private System.Windows.Forms.RichTextBox RBoxLocationSelected;
        private System.Windows.Forms.RichTextBox RBoxLocation;
        private System.Windows.Forms.Label LabErrorCopSelected;
        private System.Windows.Forms.Label LabCop;
        private System.Windows.Forms.Button BtnDeleteErrCopSelected;
        private System.Windows.Forms.Button BtnAddErrCop;
        private System.Windows.Forms.TextBox TBoxErrorCop;
        private System.Windows.Forms.RichTextBox RBoxErrorCopSelected;
        private System.Windows.Forms.RichTextBox RBoxErrorCop;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnQuit;
    }
}