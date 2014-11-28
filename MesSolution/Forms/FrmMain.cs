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
using Core.Models;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace Frms
{
    [Export]
    public partial class FrmMain : Form
    {
        public List<Mdl> mdls { get; set; }
        public AggregateCatalog catalog;
       // public CompositionContainer _container;
        public FrmMain()
        {
            InitializeComponent();
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        //    _container = new CompositionContainer(catalog);
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FormStart frm = new FormStart();//实例化Form2窗体对象
            frm.StartPosition = FormStartPosition.CenterScreen;//设置窗体居中显示
            frm.ShowDialog();//显示Form2窗体           
          //  MdlInitialize();
            this.WindowState = FormWindowState.Maximized;
            FormLogin formLogin = Program.programContainer.GetExportedValue<FormLogin>();
            formLogin.TopLevel = false;
            formLogin.Dock = DockStyle.Fill;
            formLogin.Show();
            this.panel4.Controls.Add(formLogin);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        public void MdlInitialize() 
        {

            treeView1.Nodes.Clear();
            TreeNode tn1 = new TreeNode("0");
            Mdl mdl = mdls.Single(m => m.parentcode == "0");
            tn1.Tag = mdl;
            tn1.Text = mdl.form;      
            treeView1.Nodes.Add(tn1);
            this.Bind(tn1);
            treeView1.Font = new Font("宋体", 15, FontStyle.Bold);
            treeView1.ExpandAll();
           
        }

        public void Bind(TreeNode node)
        {
            List<Mdl> drs = mdls.FindAll(m => m.parentcode == ((Mdl)node.Tag).mdlcode);
            foreach (Mdl dr in drs)
            {
                TreeNode n = new TreeNode();
                n.Tag = dr;
                n.Text = dr.form;                
                node.Nodes.Add(n);
                this.Bind(n);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {                
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Mdl)
            {
                Mdl mdl = (Mdl)e.Node.Tag;
                this.panel4.Controls.Clear();
                switch (mdl.form)
                {
                    case "FormLogin":
                        FormLogin formLogin = Program.programContainer.GetExportedValue<FormLogin>();
                        formLogin.TopLevel = false;
                        formLogin.Dock = DockStyle.Fill;
                        formLogin.Show();
                        this.panel4.Controls.Add(formLogin);
                        break;
                    case "FrmGoodNG":
                        FrmGoodNG frmGoodNG = Program.programContainer.GetExportedValue<FrmGoodNG>();
                        frmGoodNG.TopLevel = false;
                        frmGoodNG.Dock = DockStyle.Fill;
                        frmGoodNG.Show();
                        this.panel4.Controls.Add(frmGoodNG);
                        break;
                    case "FrmTsInputEdit":
                        FrmTsInputEdit frmTsInputEdit = Program.programContainer.GetExportedValue<FrmTsInputEdit>();
                        frmTsInputEdit.TopLevel = false;
                        frmTsInputEdit.Dock = DockStyle.Fill;
                        frmTsInputEdit.Show();
                        this.panel4.Controls.Add(frmTsInputEdit);
                        break;
                }   
            }
        }
    }
}
