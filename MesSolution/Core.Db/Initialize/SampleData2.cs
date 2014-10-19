/*************************************************************************************
    * CLR版本：       4.0.30319.18444
    * 类 名 称：       SampleData2
    * 机器名称：       PC201405051109
    * 命名空间：       Core.Db.Initialize
    * 文 件 名：       SampleData2
    * 创建时间：       2014/10/17 20:13:35
    * 作    者：          梁 贵
    * 说   明：。。。。。
    * 修改时间：		
    * 修 改 人：		
   *************************************************************************************/

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
    public class SampleData2 : DropCreateDatabaseIfModelChanges<MesContext>
    {
        protected override void Seed(MesContext context)
        {
            List<User> users = new List<User>
            {
                new User{usercode = "65128041",userpwd = "123",AddDate = DateTime.Now,eattribute1 = "123",IsDeleted = false,mdate = DateTime.Now,muser = "123",userdepart = "123",useremail = "123",username = "lg",userstat = "123",usertel = "123"},
                new User{usercode = "65128042",userpwd = "123",AddDate = DateTime.Now,eattribute1 = "123",IsDeleted = false,mdate = DateTime.Now,muser = "123",userdepart = "123",useremail = "123",username = "lg",userstat = "123",usertel = "123"},
                new User{usercode = "65128043",userpwd = "123",AddDate = DateTime.Now,eattribute1 = "123",IsDeleted = false,mdate = DateTime.Now,muser = "123",userdepart = "123",useremail = "123",username = "lg",userstat = "123",usertel = "123"},
                new User{usercode = "65128044",userpwd = "123",AddDate = DateTime.Now,eattribute1 = "123",IsDeleted = false,mdate = DateTime.Now,muser = "123",userdepart = "123",useremail = "123",username = "lg",userstat = "123",usertel = "123"},
                new User{usercode = "65128045",userpwd = "123",AddDate = DateTime.Now,eattribute1 = "123",IsDeleted = false,mdate = DateTime.Now,muser = "123",userdepart = "123",useremail = "123",username = "lg",userstat = "123",usertel = "123"}
            };
            DbSet<User> userSet = context.Set<User>();
            users.ForEach(u => userSet.Add(u));

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