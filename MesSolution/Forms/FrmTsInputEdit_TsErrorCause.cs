using Component.Tools;
using Core.Models;
using FormApplication.Service;
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
    public partial class FrmTsInputEdit_TsErrorCause : Form
    {
        public TsErrorCode tsErrorCode { get; set; }
        public Status formStatus { get; set; }
        public enum Status
        {
            UPDATE = 1,
            ADD = 2,
            NOTHING = 4
        }
        public FrmTsInputEdit_TsErrorCause()
        {
            InitializeComponent();
            this.formStatus = Status.NOTHING;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorCodeSeasonGroup errorCodeSeasonGroup = (ErrorCodeSeasonGroup)listBox2.SelectedItem;
            if (errorCodeSeasonGroup!=null)
            listBox3.DataSource = errorCodeSeasonGroup.ecses.ToList();
            listBox3.SelectedItem = null;
            //OperationResult operationResult = Program.programContainer.GetExportedValue<FrmTsInputEdit>().tsCompositionContainer.GetExportedValue<IFrmTsInputEditService>().GetErrorCodeSeasonByGroup(errorCodeSeasonGroup.ecsgcode);
            //List<ErrorCodeSeason> list = (List<ErrorCodeSeason>)operationResult.AppendData;
            //listBox3.DataSource = list;
            TsErrorCause tec = Program.programContainer.GetExportedValue<FrmTsInputEdit>().tec;
            if (tec != null)
            {
                int index_listBoxe3 = listBox3.FindString(tec.errorCodeSeason.ecsdesc);
                if (index_listBoxe3 == -1)
                    MessageBox.Show("Item is not available in ListBox2");
                else
                    listBox3.SetSelected(index_listBoxe3, true);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formStatus == Status.UPDATE)
                UpdateTsErrorCause();
            if (formStatus == Status.ADD)
                AddTsErrorCause();

        }

        private void UpdateTsErrorCause()
        {
            TsErrorCause tec = Program.programContainer.GetExportedValue<FrmTsInputEdit>().tec;
            tec.errorCom = (ErrorCom)listBox1.SelectedItem;
            tec.errorCodeSeason = (ErrorCodeSeason)listBox3.SelectedItem;
            tec.duty = (Duty)listBox4.SelectedItem;
            tec.solution = (Solution)listBox5.SelectedItem;
            tec.solmemo = richTextBox1.Text;
            tec.muser = "123";
            DateTime dt = DateTime.Now;
            tec.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
            tec.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().BindFresh();
            formStatus = Status.NOTHING;
            this.Hide();
            
        }

        private void AddTsErrorCause()
        {
            TsErrorCause tec = new TsErrorCause();
            tec.errorCom = (ErrorCom)listBox1.SelectedItem;
            tec.errorCodeSeason = (ErrorCodeSeason)listBox3.SelectedItem;
            tec.duty = (Duty)listBox4.SelectedItem;
            tec.solution = (Solution)listBox5.SelectedItem;
            tec.solmemo = richTextBox1.Text;
            tec.muser = "123";
            DateTime dt = DateTime.Now;
            tec.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
            tec.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
            tec.shiftday = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
            if (tsErrorCode.tsErrorCauses == null)
            {
                tsErrorCode.tsErrorCauses = new List<TsErrorCause>();
                tsErrorCode.tsErrorCauses.Add(tec);
            }
            else
            tsErrorCode.tsErrorCauses.Add(tec);
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().TreeFresh();
            formStatus = Status.NOTHING;
            this.Hide();
        }
    }
}
