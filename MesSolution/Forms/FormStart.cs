using FormApplication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FormStart :Form
    {
     
        public FormStart()
        {
            InitializeComponent();        
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//设置启动窗体为无标题栏窗体
           // this.BackgroundImage = Image.FromFile("start.jpg");//设置启动窗体的背景图片
            this.BackgroundImage =Properties.Resources.start;//设置启动窗体的背景图片
            this.BackgroundImageLayout = ImageLayout.Stretch;//设置图片自动适应窗体大小
            using (CompositionContainer _container = new CompositionContainer(Program.programCatalog))
            {
                Console.WriteLine(_container.GetExportedValue<IUserFormService>().FindEntity("123").Message);
                this.timer1.Start();//启动计时器
                this.timer1.Interval = 1000;//设置启动窗体停留时间
            }            
           
        }

        private void FormStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
