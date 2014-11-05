namespace Forms
{
    partial class FrmGoodNG
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuningCard = new System.Windows.Forms.TextBox();
            this.checkBoxMo = new System.Windows.Forms.CheckBox();
            this.checkBoxLength = new System.Windows.Forms.CheckBox();
            this.checkBoxPrefix = new System.Windows.Forms.CheckBox();
            this.tetMo = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMo2 = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonGood = new System.Windows.Forms.RadioButton();
            this.radioButtonNG = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品序列号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRuningCard
            // 
            this.txtRuningCard.Location = new System.Drawing.Point(161, 232);
            this.txtRuningCard.Name = "txtRuningCard";
            this.txtRuningCard.Size = new System.Drawing.Size(239, 21);
            this.txtRuningCard.TabIndex = 1;
            this.txtRuningCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuningCard_KeyPress);
            // 
            // checkBoxMo
            // 
            this.checkBoxMo.AutoSize = true;
            this.checkBoxMo.Location = new System.Drawing.Point(6, 20);
            this.checkBoxMo.Name = "checkBoxMo";
            this.checkBoxMo.Size = new System.Drawing.Size(96, 16);
            this.checkBoxMo.TabIndex = 2;
            this.checkBoxMo.Text = "设定归属工单";
            this.checkBoxMo.UseVisualStyleBackColor = true;
            this.checkBoxMo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxLength
            // 
            this.checkBoxLength.AutoSize = true;
            this.checkBoxLength.Location = new System.Drawing.Point(6, 44);
            this.checkBoxLength.Name = "checkBoxLength";
            this.checkBoxLength.Size = new System.Drawing.Size(108, 16);
            this.checkBoxLength.TabIndex = 3;
            this.checkBoxLength.Text = "产品序列号长度";
            this.checkBoxLength.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrefix
            // 
            this.checkBoxPrefix.AutoSize = true;
            this.checkBoxPrefix.Location = new System.Drawing.Point(6, 72);
            this.checkBoxPrefix.Name = "checkBoxPrefix";
            this.checkBoxPrefix.Size = new System.Drawing.Size(84, 16);
            this.checkBoxPrefix.TabIndex = 4;
            this.checkBoxPrefix.Text = "序列号前缀";
            this.checkBoxPrefix.UseVisualStyleBackColor = true;
            // 
            // tetMo
            // 
            this.tetMo.Enabled = false;
            this.tetMo.Location = new System.Drawing.Point(163, 15);
            this.tetMo.Name = "tetMo";
            this.tetMo.Size = new System.Drawing.Size(100, 21);
            this.tetMo.TabIndex = 5;
            this.tetMo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_KeyPress);
            // 
            // txtLength
            // 
            this.txtLength.Enabled = false;
            this.txtLength.Location = new System.Drawing.Point(163, 42);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 21);
            this.txtLength.TabIndex = 6;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Enabled = false;
            this.txtPrefix.Location = new System.Drawing.Point(163, 73);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(100, 21);
            this.txtPrefix.TabIndex = 7;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxMo);
            this.groupBox1.Controls.Add(this.tetMo);
            this.groupBox1.Controls.Add(this.checkBoxLength);
            this.groupBox1.Controls.Add(this.txtPrefix);
            this.groupBox1.Controls.Add(this.txtLength);
            this.groupBox1.Controls.Add(this.checkBoxPrefix);
            this.groupBox1.Location = new System.Drawing.Point(-2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工单信息设定";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtMo2);
            this.groupBox2.Controls.Add(this.txtItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(4, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 65);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品信息";
            // 
            // txtMo2
            // 
            this.txtMo2.Location = new System.Drawing.Point(355, 27);
            this.txtMo2.Name = "txtMo2";
            this.txtMo2.Size = new System.Drawing.Size(100, 21);
            this.txtMo2.TabIndex = 3;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(106, 27);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(100, 21);
            this.txtItem.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "工单";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "产品";
            // 
            // radioButtonGood
            // 
            this.radioButtonGood.AutoSize = true;
            this.radioButtonGood.Checked = true;
            this.radioButtonGood.Location = new System.Drawing.Point(70, 193);
            this.radioButtonGood.Name = "radioButtonGood";
            this.radioButtonGood.Size = new System.Drawing.Size(47, 16);
            this.radioButtonGood.TabIndex = 12;
            this.radioButtonGood.TabStop = true;
            this.radioButtonGood.Text = "良品";
            this.radioButtonGood.UseVisualStyleBackColor = true;
            // 
            // radioButtonNG
            // 
            this.radioButtonNG.AutoSize = true;
            this.radioButtonNG.Location = new System.Drawing.Point(211, 193);
            this.radioButtonNG.Name = "radioButtonNG";
            this.radioButtonNG.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNG.TabIndex = 13;
            this.radioButtonNG.Text = "不良品";
            this.radioButtonNG.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.Location = new System.Drawing.Point(4, 259);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(464, 61);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // FrmGoodNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 322);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.radioButtonNG);
            this.Controls.Add(this.radioButtonGood);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRuningCard);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmGoodNG";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuningCard;
        private System.Windows.Forms.CheckBox checkBoxMo;
        private System.Windows.Forms.CheckBox checkBoxLength;
        private System.Windows.Forms.CheckBox checkBoxPrefix;
        private System.Windows.Forms.TextBox tetMo;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMo2;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonGood;
        private System.Windows.Forms.RadioButton radioButtonNG;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}