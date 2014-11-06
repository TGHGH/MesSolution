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
            this.label1.Location = new System.Drawing.Point(63, 309);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品序列号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtRuningCard
            // 
            this.txtRuningCard.Location = new System.Drawing.Point(215, 309);
            this.txtRuningCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRuningCard.Name = "txtRuningCard";
            this.txtRuningCard.Size = new System.Drawing.Size(317, 26);
            this.txtRuningCard.TabIndex = 1;
            this.txtRuningCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuningCard_KeyPress);
            // 
            // checkBoxMo
            // 
            this.checkBoxMo.AutoSize = true;
            this.checkBoxMo.Location = new System.Drawing.Point(8, 27);
            this.checkBoxMo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxMo.Name = "checkBoxMo";
            this.checkBoxMo.Size = new System.Drawing.Size(123, 20);
            this.checkBoxMo.TabIndex = 2;
            this.checkBoxMo.Text = "设定归属工单";
            this.checkBoxMo.UseVisualStyleBackColor = true;
            this.checkBoxMo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBoxLength
            // 
            this.checkBoxLength.AutoSize = true;
            this.checkBoxLength.Location = new System.Drawing.Point(8, 59);
            this.checkBoxLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLength.Name = "checkBoxLength";
            this.checkBoxLength.Size = new System.Drawing.Size(139, 20);
            this.checkBoxLength.TabIndex = 3;
            this.checkBoxLength.Text = "产品序列号长度";
            this.checkBoxLength.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrefix
            // 
            this.checkBoxPrefix.AutoSize = true;
            this.checkBoxPrefix.Location = new System.Drawing.Point(8, 96);
            this.checkBoxPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxPrefix.Name = "checkBoxPrefix";
            this.checkBoxPrefix.Size = new System.Drawing.Size(107, 20);
            this.checkBoxPrefix.TabIndex = 4;
            this.checkBoxPrefix.Text = "序列号前缀";
            this.checkBoxPrefix.UseVisualStyleBackColor = true;
            // 
            // tetMo
            // 
            this.tetMo.Enabled = false;
            this.tetMo.Location = new System.Drawing.Point(217, 20);
            this.tetMo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tetMo.Name = "tetMo";
            this.tetMo.Size = new System.Drawing.Size(132, 26);
            this.tetMo.TabIndex = 5;
            this.tetMo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMo_KeyPress);
            // 
            // txtLength
            // 
            this.txtLength.Enabled = false;
            this.txtLength.Location = new System.Drawing.Point(217, 56);
            this.txtLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(132, 26);
            this.txtLength.TabIndex = 6;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Enabled = false;
            this.txtPrefix.Location = new System.Drawing.Point(217, 97);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(132, 26);
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
            this.groupBox1.Location = new System.Drawing.Point(-3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(627, 133);
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
            this.groupBox2.Location = new System.Drawing.Point(5, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(619, 87);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品信息";
            // 
            // txtMo2
            // 
            this.txtMo2.Location = new System.Drawing.Point(473, 36);
            this.txtMo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMo2.Name = "txtMo2";
            this.txtMo2.Size = new System.Drawing.Size(132, 26);
            this.txtMo2.TabIndex = 3;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(141, 36);
            this.txtItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(132, 26);
            this.txtItem.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "工单";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "产品";
            // 
            // radioButtonGood
            // 
            this.radioButtonGood.AutoSize = true;
            this.radioButtonGood.Checked = true;
            this.radioButtonGood.Location = new System.Drawing.Point(93, 257);
            this.radioButtonGood.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonGood.Name = "radioButtonGood";
            this.radioButtonGood.Size = new System.Drawing.Size(58, 20);
            this.radioButtonGood.TabIndex = 12;
            this.radioButtonGood.TabStop = true;
            this.radioButtonGood.Text = "良品";
            this.radioButtonGood.UseVisualStyleBackColor = true;
            // 
            // radioButtonNG
            // 
            this.radioButtonNG.AutoSize = true;
            this.radioButtonNG.Location = new System.Drawing.Point(281, 257);
            this.radioButtonNG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonNG.Name = "radioButtonNG";
            this.radioButtonNG.Size = new System.Drawing.Size(74, 20);
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
            this.richTextBox1.Location = new System.Drawing.Point(5, 345);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(617, 80);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // FrmGoodNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 429);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.radioButtonNG);
            this.Controls.Add(this.radioButtonGood);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRuningCard);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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