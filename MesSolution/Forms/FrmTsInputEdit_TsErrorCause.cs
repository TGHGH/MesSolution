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
                listBox3.Items.Clear();
                listBox3.Items.AddRange(list.ToArray());
            }

        }
    }
}
