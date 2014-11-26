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
            if (errorCodeGroup != null)
                listBox2.DataSource = errorCodeGroup.errorCodes.ToList();
            listBox2.SelectedItem = null;
            TsErrorCode tsErrorCode = Program.programContainer.GetExportedValue<FrmTsInputEdit>().currentTsErrorCode;
            if (tsErrorCode != null)
            {
                int index_listBoxe2 = listBox2.FindString(tsErrorCode.errorCode.ecdesc);
                if (index_listBoxe2 == -1)
                    MessageBox.Show("Item is not available in ListBox2");
                else
                    listBox2.SetSelected(index_listBoxe2, true);
            }
          
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
            TsErrorCode currentTsErrorCode = Program.programContainer.GetExportedValue<FrmTsInputEdit>().currentTsErrorCode;
            currentTsErrorCode.errorCode = (ErrorCode)listBox2.SelectedItem;
            currentTsErrorCode.muser = Program.usercode;
            DateTime dt = DateTime.Now;
            currentTsErrorCode.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
            currentTsErrorCode.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);            
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().TreeFresh();
            formStatus = Status.NOTHING;
            this.Hide();

        }

        private void AddTsErrorCode()
        {
            TsErrorCode tc = new TsErrorCode();
            tc.errorCode=(ErrorCode)listBox2.SelectedItem;
            tc.muser = Program.usercode;
            DateTime dt = DateTime.Now;
            tc.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
            tc.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().currentTs.tsErrorCodes.Add(tc);
            tc.ts = Program.programContainer.GetExportedValue<FrmTsInputEdit>().currentTs;
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().TreeFresh();
            formStatus = Status.NOTHING;
            this.Hide();
        }
    }
}
