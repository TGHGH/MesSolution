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
    /// 数据库初始化策略
    /// </summary>
    public class SampleData : CreateDatabaseIfNotExists<DemoDbContext>
    {
        protected override void Seed(DemoDbContext context)
        {
            List<Member> members = new List<Member>
            {
                new Member { UserName = "admin", Password = "123456", Email = "admin@gmfcn.net", NickName = "管理员" },
                new Member { UserName = "gmfcn", Password = "123456", Email = "mf.guo@qq.com", NickName = "郭明锋" }
            };
            DbSet<Member> memberSet = context.Set<Member>();
            members.ForEach(m => memberSet.Add(m));
            context.SaveChanges();
        }
    }
}
