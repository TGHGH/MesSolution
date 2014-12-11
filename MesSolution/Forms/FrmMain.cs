using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
        public List<Mdl> Mdls { get; set; }
        public AggregateCatalog Catalog;
        public CultureInfo CultureInfo { get; set; }
       
       // public CompositionContainer _container;
        public FrmMain()
        {
            InitializeComponent();
            Catalog = new AggregateCatalog();
            Catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            Catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            CultureInfo=new CultureInfo("en-US");
        //    _container = new CompositionContainer(catalog);
            
        }

        /// <summary>
        /// 应用资源
        /// ApplyResources 的第一个参数为要设置的控件
        ///                  第二个参数为在资源文件中的ID，默认为控件的名称
        /// </summary>
        private void ApplyResource(Type t)
        {
            Thread.CurrentThread.CurrentUICulture =CultureInfo;
            var res = new ComponentResourceManager(t);
            ApplyResource2(res,this.Controls);
           

            ////菜单
            //foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            //{
            //    res.ApplyResources(item, item.Name);
            //    foreach (ToolStripMenuItem subItem in item.DropDownItems)
            //    {
            //        res.ApplyResources(subItem, subItem.Name);
            //    }
            //}

            //Caption
           // res.ApplyResources(this, "$this");
        }

        private void ApplyResource2(ComponentResourceManager res,Control.ControlCollection cc)
        {
            foreach (Control ctl in cc)
            {
                res.ApplyResources(ctl, ctl.Name);
                ApplyResource2(res, ctl.Controls);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {            
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var frm = new FrmStart();//实例化Form2窗体对象
            frm.StartPosition = FormStartPosition.CenterScreen;//设置窗体居中显示
            frm.ShowDialog();//显示Form2窗体           
          //  MdlInitialize();
            this.WindowState = FormWindowState.Maximized;
            var formLogin = Program.programContainer.GetExportedValue<FrmLogin>();
            formLogin.TopLevel = false;
            formLogin.Dock = DockStyle.Fill;
            formLogin.Show();
            this.panel4.Controls.Add(formLogin);
            ApplyResource(this.GetType());
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
            Mdl mdl = Mdls.Single(m => m.parentcode == "0");
            tn1.Tag = mdl;
            tn1.Text = mdl.form;      
            treeView1.Nodes.Add(tn1);
            this.Bind(tn1);
            treeView1.Font = new Font("宋体", 15, FontStyle.Bold);
            treeView1.ExpandAll();
           
        }

        public void Bind(TreeNode node)
        {
            List<Mdl> drs = Mdls.FindAll(m => m.parentcode == ((Mdl)node.Tag).mdlcode);
            foreach (Mdl dr in drs)
            {
                var n = new TreeNode();
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
                        FrmLogin formLogin = Program.programContainer.GetExportedValue<FrmLogin>();
                        formLogin.TopLevel = false;
                        formLogin.Dock = DockStyle.Fill;
                        formLogin.Show();
                        this.panel4.Controls.Add(formLogin);
                        ApplyResource(typeof (FrmLogin));
                        break;
                    case "FrmGoodNG":
                        FrmGoodNg frmGoodNG = Program.programContainer.GetExportedValue<FrmGoodNg>();
                        frmGoodNG.TopLevel = false;
                        frmGoodNG.Dock = DockStyle.Fill;
                        frmGoodNG.Show();
                        this.panel4.Controls.Add(frmGoodNG);
                        ApplyResource(typeof(FrmGoodNg));
                        break;
                    case "FrmTsInputEdit":
                        FrmTsInputEdit frmTsInputEdit = Program.programContainer.GetExportedValue<FrmTsInputEdit>();
                        frmTsInputEdit.TopLevel = false;
                        frmTsInputEdit.Dock = DockStyle.Fill;
                        frmTsInputEdit.Show();
                        this.panel4.Controls.Add(frmTsInputEdit);
                        ApplyResource(typeof(FrmTsInputEdit));
                        break;
                }   
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
