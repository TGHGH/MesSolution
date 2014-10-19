using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using Core.Db.Context;
using Core.Models;


namespace GMF.Demo.Core.Data.Initialize
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void CreateDatabaseIfNotExists( )
        {
            //运行的时候
            Database.SetInitializer(new SampleData());
           
            using (var mesContext = new MesContext())
            {
                mesContext.Database.Initialize(false);
            }
        }
        public static void DropCreateDatabaseIfModelChanges()
        {
            //运行的时候
            //Database.SetInitializer(new SampleData());
            //开发的时候
            Database.SetInitializer(new SampleData2());
            using (var mesContext = new MesContext())
            {
                mesContext.Database.Initialize(false);
            }
        }

      
    }
}
