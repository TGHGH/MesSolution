using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    [Export]
    public partial class FrmTsInputEdit_TsErrorCode : Form
    {
        public Status formStatus { get; set; }
        public enum Status
        {
            UPDATE = 1,
            ADD = 2,
            NOTHING = 4
        }
        public FrmTsInputEdit_TsErrorCode()
        {
            InitializeComponent();
            this.formStatus = Status.NOTHING;
        }
        


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorCodeGroup errorCodeGroup = (ErrorCodeGroup)listBox1.SelectedItem;
            if (errorCodeGroup!=null)
            listBox2.DataSource = errorCodeGroup.errorCodes.ToList();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formStatus == Status.UPDATE)
                UpdateTsErrorCode();
            if (formStatus == Status.ADD)
                AddTsErrorCode();
        }
        private void UpdateTsErrorCode()
        {
            //TsErrorCause tec = Program.programContainer.GetExportedValue<FrmTsInputEdit>().tec;
            //tec.errorCom = (ErrorCom)listBox1.SelectedItem;
            //tec.errorCodeSeason = (ErrorCodeSeason)listBox3.SelectedItem;
            //tec.duty = (Duty)listBox4.SelectedItem;
            //tec.solution = (Solution)listBox5.SelectedItem;
            //tec.solmemo = richTextBox1.Text;
            //tec.muser = "123";
            //DateTime dt = DateTime.Now;
            //tec.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
            //tec.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
            //Program.programContainer.GetExportedValue<FrmTsInputEdit>().BindFresh();
            //formStatus = Status.NOTHING;
            //this.Hide();

        }

        private void AddTsErrorCode()
        {
            TsErrorCode tc = new TsErrorCode();
            tc.errorCode=(ErrorCode)listBox2.SelectedItem;          
            tc.muser = "123";
            DateTime dt = DateTime.Now;
            tc.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
            tc.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().ts.tsErrorCodes.Add(tc);
            tc.ts = Program.programContainer.GetExportedValue<FrmTsInputEdit>().ts;
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().TreeFresh();
            formStatus = Status.NOTHING;
            this.Hide();
        }
    }
}
