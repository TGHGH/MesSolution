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
            this.components = new System.ComponentModel.Container();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.CBoxErrorCause = new System.Windows.Forms.TextBox();
            this.CBoxErrorCauseGroup = new System.Windows.Forms.TextBox();
            this.CBoxDuty = new System.Windows.Forms.TextBox();
            this.CBoxSolution = new System.Windows.Forms.TextBox();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 55);
            this.panel1.TabIndex = 0;
            // 
            // TBoxMemo
            // 
            this.TBoxMemo.Location = new System.Drawing.Point(386, 18);
            this.TBoxMemo.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxMemo.Name = "TBoxMemo";
            this.TBoxMemo.Size = new System.Drawing.Size(116, 23);
            this.TBoxMemo.TabIndex = 4;
            // 
            // TBoxSN
            // 
            this.TBoxSN.Location = new System.Drawing.Point(108, 17);
            this.TBoxSN.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxSN.Name = "TBoxSN";
            this.TBoxSN.Size = new System.Drawing.Size(144, 23);
            this.TBoxSN.TabIndex = 3;
            this.TBoxSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBoxSN_KeyPress);
            // 
            // BtnErrInfo
            // 
            this.BtnErrInfo.Location = new System.Drawing.Point(676, 17);
            this.BtnErrInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnErrInfo.Name = "BtnErrInfo";
            this.BtnErrInfo.Size = new System.Drawing.Size(105, 27);
            this.BtnErrInfo.TabIndex = 2;
            this.BtnErrInfo.Text = "维护不良信息";
            this.BtnErrInfo.UseVisualStyleBackColor = true;
            // 
            // LabMemo
            // 
            this.LabMemo.AutoSize = true;
            this.LabMemo.Location = new System.Drawing.Point(332, 21);
            this.LabMemo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabMemo.Name = "LabMemo";
            this.LabMemo.Size = new System.Drawing.Size(35, 14);
            this.LabMemo.TabIndex = 1;
            this.LabMemo.Text = "备注";
            // 
            // LabSN
            // 
            this.LabSN.AutoSize = true;
            this.LabSN.Location = new System.Drawing.Point(25, 21);
            this.LabSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabSN.Name = "LabSN";
            this.LabSN.Size = new System.Drawing.Size(77, 14);
            this.LabSN.TabIndex = 0;
            this.LabSN.Text = "产品序列号";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(13, 62);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(126, 578);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CBoxSolution);
            this.panel2.Controls.Add(this.CBoxDuty);
            this.panel2.Controls.Add(this.CBoxErrorCauseGroup);
            this.panel2.Controls.Add(this.CBoxErrorCause);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.BtnAddInfo);
            this.panel2.Controls.Add(this.RBoxPremunition);
            this.panel2.Controls.Add(this.TBoxErrorComponent);
            this.panel2.Controls.Add(this.LabPremunition);
            this.panel2.Controls.Add(this.LabSolution);
            this.panel2.Controls.Add(this.LabDuty);
            this.panel2.Controls.Add(this.LabErrorCauseGroup);
            this.panel2.Controls.Add(this.LabErrorCause);
            this.panel2.Controls.Add(this.LabErrorComponent);
            this.panel2.Location = new System.Drawing.Point(147, 109);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 186);
            this.panel2.TabIndex = 2;
            // 
            // BtnAddInfo
            // 
            this.BtnAddInfo.Location = new System.Drawing.Point(17, 160);
            this.BtnAddInfo.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddInfo.Name = "BtnAddInfo";
            this.BtnAddInfo.Size = new System.Drawing.Size(88, 27);
            this.BtnAddInfo.TabIndex = 12;
            this.BtnAddInfo.Text = "选择";
            this.BtnAddInfo.UseVisualStyleBackColor = true;
            this.BtnAddInfo.Click += new System.EventHandler(this.BtnAddInfo_Click);
            // 
            // RBoxPremunition
            // 
            this.RBoxPremunition.Location = new System.Drawing.Point(417, 111);
            this.RBoxPremunition.Margin = new System.Windows.Forms.Padding(4);
            this.RBoxPremunition.Name = "RBoxPremunition";
            this.RBoxPremunition.Size = new System.Drawing.Size(175, 42);
            this.RBoxPremunition.TabIndex = 11;
            this.RBoxPremunition.Text = "";
            // 
            // TBoxErrorComponent
            // 
            this.TBoxErrorComponent.Enabled = false;
            this.TBoxErrorComponent.Location = new System.Drawing.Point(111, 13);
            this.TBoxErrorComponent.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxErrorComponent.Name = "TBoxErrorComponent";
            this.TBoxErrorComponent.Size = new System.Drawing.Size(182, 23);
            this.TBoxErrorComponent.TabIndex = 6;
            // 
            // LabPremunition
            // 
            this.LabPremunition.AutoSize = true;
            this.LabPremunition.Location = new System.Drawing.Point(321, 115);
            this.LabPremunition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabPremunition.Name = "LabPremunition";
            this.LabPremunition.Size = new System.Drawing.Size(63, 14);
            this.LabPremunition.TabIndex = 5;
            this.LabPremunition.Text = "预防措施";
            // 
            // LabSolution
            // 
            this.LabSolution.AutoSize = true;
            this.LabSolution.Location = new System.Drawing.Point(14, 115);
            this.LabSolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabSolution.Name = "LabSolution";
            this.LabSolution.Size = new System.Drawing.Size(63, 14);
            this.LabSolution.TabIndex = 4;
            this.LabSolution.Text = "解决方案";
            // 
            // LabDuty
            // 
            this.LabDuty.AutoSize = true;
            this.LabDuty.Location = new System.Drawing.Point(321, 66);
            this.LabDuty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabDuty.Name = "LabDuty";
            this.LabDuty.Size = new System.Drawing.Size(49, 14);
            this.LabDuty.TabIndex = 3;
            this.LabDuty.Text = "责任别";
            // 
            // LabErrorCauseGroup
            // 
            this.LabErrorCauseGroup.AutoSize = true;
            this.LabErrorCauseGroup.Location = new System.Drawing.Point(14, 66);
            this.LabErrorCauseGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorCauseGroup.Name = "LabErrorCauseGroup";
            this.LabErrorCauseGroup.Size = new System.Drawing.Size(77, 14);
            this.LabErrorCauseGroup.TabIndex = 2;
            this.LabErrorCauseGroup.Text = "不良原因组";
            // 
            // LabErrorCause
            // 
            this.LabErrorCause.AutoSize = true;
            this.LabErrorCause.Location = new System.Drawing.Point(321, 18);
            this.LabErrorCause.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorCause.Name = "LabErrorCause";
            this.LabErrorCause.Size = new System.Drawing.Size(63, 14);
            this.LabErrorCause.TabIndex = 1;
            this.LabErrorCause.Text = "不良原因";
            // 
            // LabErrorComponent
            // 
            this.LabErrorComponent.AutoSize = true;
            this.LabErrorComponent.Location = new System.Drawing.Point(14, 17);
            this.LabErrorComponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorComponent.Name = "LabErrorComponent";
            this.LabErrorComponent.Size = new System.Drawing.Size(63, 14);
            this.LabErrorComponent.TabIndex = 0;
            this.LabErrorComponent.Text = "不良组件";
            // 
            // LabErrorCodeGroupDesc
            // 
            this.LabErrorCodeGroupDesc.AutoSize = true;
            this.LabErrorCodeGroupDesc.Location = new System.Drawing.Point(147, 80);
            this.LabErrorCodeGroupDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorCodeGroupDesc.Name = "LabErrorCodeGroupDesc";
            this.LabErrorCodeGroupDesc.Size = new System.Drawing.Size(105, 14);
            this.LabErrorCodeGroupDesc.TabIndex = 3;
            this.LabErrorCodeGroupDesc.Text = "不良代码组描述";
            // 
            // LabErrorCodeDesc
            // 
            this.LabErrorCodeDesc.AutoSize = true;
            this.LabErrorCodeDesc.Location = new System.Drawing.Point(468, 80);
            this.LabErrorCodeDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorCodeDesc.Name = "LabErrorCodeDesc";
            this.LabErrorCodeDesc.Size = new System.Drawing.Size(91, 14);
            this.LabErrorCodeDesc.TabIndex = 4;
            this.LabErrorCodeDesc.Text = "不良代码描述";
            // 
            // TBoxErrorCodeGroupDesc
            // 
            this.TBoxErrorCodeGroupDesc.Enabled = false;
            this.TBoxErrorCodeGroupDesc.Location = new System.Drawing.Point(258, 76);
            this.TBoxErrorCodeGroupDesc.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxErrorCodeGroupDesc.Name = "TBoxErrorCodeGroupDesc";
            this.TBoxErrorCodeGroupDesc.Size = new System.Drawing.Size(182, 23);
            this.TBoxErrorCodeGroupDesc.TabIndex = 5;
            // 
            // TBoxErrorCodeDesc
            // 
            this.TBoxErrorCodeDesc.Enabled = false;
            this.TBoxErrorCodeDesc.Location = new System.Drawing.Point(564, 76);
            this.TBoxErrorCodeDesc.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxErrorCodeDesc.Name = "TBoxErrorCodeDesc";
            this.TBoxErrorCodeDesc.Size = new System.Drawing.Size(175, 23);
            this.TBoxErrorCodeDesc.TabIndex = 6;
            // 
            // LabErrorLocationSelected
            // 
            this.LabErrorLocationSelected.AutoSize = true;
            this.LabErrorLocationSelected.Location = new System.Drawing.Point(147, 312);
            this.LabErrorLocationSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorLocationSelected.Name = "LabErrorLocationSelected";
            this.LabErrorLocationSelected.Size = new System.Drawing.Size(91, 14);
            this.LabErrorLocationSelected.TabIndex = 7;
            this.LabErrorLocationSelected.Text = "已选不良位置";
            // 
            // LabErrorLocation
            // 
            this.LabErrorLocation.AutoSize = true;
            this.LabErrorLocation.Location = new System.Drawing.Point(454, 312);
            this.LabErrorLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorLocation.Name = "LabErrorLocation";
            this.LabErrorLocation.Size = new System.Drawing.Size(63, 14);
            this.LabErrorLocation.TabIndex = 8;
            this.LabErrorLocation.Text = "不良位置";
            // 
            // BtnDeleteLocationSelected
            // 
            this.BtnDeleteLocationSelected.Location = new System.Drawing.Point(302, 307);
            this.BtnDeleteLocationSelected.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDeleteLocationSelected.Name = "BtnDeleteLocationSelected";
            this.BtnDeleteLocationSelected.Size = new System.Drawing.Size(88, 27);
            this.BtnDeleteLocationSelected.TabIndex = 9;
            this.BtnDeleteLocationSelected.Text = "删除";
            this.BtnDeleteLocationSelected.UseVisualStyleBackColor = true;
            // 
            // BtnAddErrLocation
            // 
            this.BtnAddErrLocation.Location = new System.Drawing.Point(675, 307);
            this.BtnAddErrLocation.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddErrLocation.Name = "BtnAddErrLocation";
            this.BtnAddErrLocation.Size = new System.Drawing.Size(88, 27);
            this.BtnAddErrLocation.TabIndex = 10;
            this.BtnAddErrLocation.Text = "添加";
            this.BtnAddErrLocation.UseVisualStyleBackColor = true;
            // 
            // TBoxErrorLocation
            // 
            this.TBoxErrorLocation.Location = new System.Drawing.Point(550, 309);
            this.TBoxErrorLocation.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxErrorLocation.Name = "TBoxErrorLocation";
            this.TBoxErrorLocation.Size = new System.Drawing.Size(116, 23);
            this.TBoxErrorLocation.TabIndex = 11;
            // 
            // RBoxLocationSelected
            // 
            this.RBoxLocationSelected.Location = new System.Drawing.Point(147, 340);
            this.RBoxLocationSelected.Margin = new System.Windows.Forms.Padding(4);
            this.RBoxLocationSelected.Name = "RBoxLocationSelected";
            this.RBoxLocationSelected.Size = new System.Drawing.Size(294, 92);
            this.RBoxLocationSelected.TabIndex = 12;
            this.RBoxLocationSelected.Text = "";
            // 
            // RBoxLocation
            // 
            this.RBoxLocation.Location = new System.Drawing.Point(456, 340);
            this.RBoxLocation.Margin = new System.Windows.Forms.Padding(4);
            this.RBoxLocation.Name = "RBoxLocation";
            this.RBoxLocation.Size = new System.Drawing.Size(305, 92);
            this.RBoxLocation.TabIndex = 13;
            this.RBoxLocation.Text = "";
            // 
            // LabErrorCopSelected
            // 
            this.LabErrorCopSelected.AutoSize = true;
            this.LabErrorCopSelected.Location = new System.Drawing.Point(147, 458);
            this.LabErrorCopSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabErrorCopSelected.Name = "LabErrorCopSelected";
            this.LabErrorCopSelected.Size = new System.Drawing.Size(91, 14);
            this.LabErrorCopSelected.TabIndex = 14;
            this.LabErrorCopSelected.Text = "已选不良零件";
            // 
            // LabCop
            // 
            this.LabCop.AutoSize = true;
            this.LabCop.Location = new System.Drawing.Point(454, 458);
            this.LabCop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabCop.Name = "LabCop";
            this.LabCop.Size = new System.Drawing.Size(63, 14);
            this.LabCop.TabIndex = 15;
            this.LabCop.Text = "不良零件";
            // 
            // BtnDeleteErrCopSelected
            // 
            this.BtnDeleteErrCopSelected.Location = new System.Drawing.Point(302, 452);
            this.BtnDeleteErrCopSelected.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDeleteErrCopSelected.Name = "BtnDeleteErrCopSelected";
            this.BtnDeleteErrCopSelected.Size = new System.Drawing.Size(88, 27);
            this.BtnDeleteErrCopSelected.TabIndex = 16;
            this.BtnDeleteErrCopSelected.Text = "删除";
            this.BtnDeleteErrCopSelected.UseVisualStyleBackColor = true;
            // 
            // BtnAddErrCop
            // 
            this.BtnAddErrCop.Location = new System.Drawing.Point(675, 452);
            this.BtnAddErrCop.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddErrCop.Name = "BtnAddErrCop";
            this.BtnAddErrCop.Size = new System.Drawing.Size(88, 27);
            this.BtnAddErrCop.TabIndex = 17;
            this.BtnAddErrCop.Text = "添加";
            this.BtnAddErrCop.UseVisualStyleBackColor = true;
            // 
            // TBoxErrorCop
            // 
            this.TBoxErrorCop.Location = new System.Drawing.Point(550, 452);
            this.TBoxErrorCop.Margin = new System.Windows.Forms.Padding(4);
            this.TBoxErrorCop.Name = "TBoxErrorCop";
            this.TBoxErrorCop.Size = new System.Drawing.Size(116, 23);
            this.TBoxErrorCop.TabIndex = 18;
            // 
            // RBoxErrorCopSelected
            // 
            this.RBoxErrorCopSelected.Location = new System.Drawing.Point(147, 486);
            this.RBoxErrorCopSelected.Margin = new System.Windows.Forms.Padding(4);
            this.RBoxErrorCopSelected.Name = "RBoxErrorCopSelected";
            this.RBoxErrorCopSelected.Size = new System.Drawing.Size(294, 112);
            this.RBoxErrorCopSelected.TabIndex = 19;
            this.RBoxErrorCopSelected.Text = "";
            // 
            // RBoxErrorCop
            // 
            this.RBoxErrorCop.Location = new System.Drawing.Point(456, 486);
            this.RBoxErrorCop.Margin = new System.Windows.Forms.Padding(4);
            this.RBoxErrorCop.Name = "RBoxErrorCop";
            this.RBoxErrorCop.Size = new System.Drawing.Size(305, 112);
            this.RBoxErrorCop.TabIndex = 20;
            this.RBoxErrorCop.Text = "";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(147, 613);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(88, 27);
            this.BtnAdd.TabIndex = 21;
            this.BtnAdd.Text = "添加";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(277, 613);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(88, 27);
            this.BtnDelete.TabIndex = 22;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(414, 613);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(88, 27);
            this.BtnSave.TabIndex = 23;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(550, 613);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(88, 27);
            this.BtnCancel.TabIndex = 24;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(675, 613);
            this.BtnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(88, 27);
            this.BtnQuit.TabIndex = 25;
            this.BtnQuit.Text = "退出";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 186);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // CBoxErrorCause
            // 
            this.CBoxErrorCause.Enabled = false;
            this.CBoxErrorCause.Location = new System.Drawing.Point(417, 15);
            this.CBoxErrorCause.Name = "CBoxErrorCause";
            this.CBoxErrorCause.Size = new System.Drawing.Size(175, 23);
            this.CBoxErrorCause.TabIndex = 14;
            // 
            // CBoxErrorCauseGroup
            // 
            this.CBoxErrorCauseGroup.Enabled = false;
            this.CBoxErrorCauseGroup.Location = new System.Drawing.Point(111, 62);
            this.CBoxErrorCauseGroup.Name = "CBoxErrorCauseGroup";
            this.CBoxErrorCauseGroup.Size = new System.Drawing.Size(182, 23);
            this.CBoxErrorCauseGroup.TabIndex = 15;
            // 
            // CBoxDuty
            // 
            this.CBoxDuty.Enabled = false;
            this.CBoxDuty.Location = new System.Drawing.Point(417, 62);
            this.CBoxDuty.Name = "CBoxDuty";
            this.CBoxDuty.Size = new System.Drawing.Size(175, 23);
            this.CBoxDuty.TabIndex = 16;
            // 
            // CBoxSolution
            // 
            this.CBoxSolution.Enabled = false;
            this.CBoxSolution.Location = new System.Drawing.Point(111, 111);
            this.CBoxSolution.Name = "CBoxSolution";
            this.CBoxSolution.Size = new System.Drawing.Size(182, 23);
            this.CBoxSolution.TabIndex = 17;
            // 
            // FrmTsInputEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 644);
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
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.TextBox CBoxSolution;
        private System.Windows.Forms.TextBox CBoxDuty;
        private System.Windows.Forms.TextBox CBoxErrorCauseGroup;
        private System.Windows.Forms.TextBox CBoxErrorCause;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}