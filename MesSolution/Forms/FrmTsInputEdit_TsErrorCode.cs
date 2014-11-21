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
        public FrmTsInputEdit_TsErrorCode()
        {
            InitializeComponent();
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
    }
}
