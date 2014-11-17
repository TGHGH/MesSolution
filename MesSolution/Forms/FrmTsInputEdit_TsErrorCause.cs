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
        public FrmTsInputEdit_TsErrorCause()
        {
            InitializeComponent();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ErrorCodeSeasonGroup errorCodeSeasonGroup = (ErrorCodeSeasonGroup)listBox2.SelectedItem;
            using (CompositionContainer testContainer = new CompositionContainer(Program.programCatalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().GetErrorCodeSeasonByGroup(errorCodeSeasonGroup.ecsgcode);
                List<ErrorCodeSeason> list = (List<ErrorCodeSeason>)operationResult.AppendData;               
                listBox3.DataSource=list;
                int index_listBoxe3 = listBox3.FindString(Program.programContainer.GetExportedValue<FrmTsInputEdit>().tec.errorCodeSeason.ecsdesc);
                if (index_listBoxe3 == -1)
                    MessageBox.Show("Item is not available in ListBox2");
                else
                    listBox3.SetSelected(index_listBoxe3, true);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TsErrorCause tec= Program.programContainer.GetExportedValue<FrmTsInputEdit>().tec;
            //tec.errorCom =(ErrorCom) listBox1.SelectedItem;
            //tec.errorCodeSeason =(ErrorCodeSeason) listBox3.SelectedItem;
            tec.duty = (Duty)listBox4.SelectedItem;
            //tec.solution =(Solution) listBox5.SelectedItem;
            tec.solmemo = richTextBox1.Text;
            Program.programContainer.GetExportedValue<FrmTsInputEdit>().BindFresh();
            this.Hide();
        }
    }
}
