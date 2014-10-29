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
using Component.Tools;
using System.Reflection;
using System.Collections.ObjectModel;
using Core.Db.Initialize;


namespace GMF.Demo.Core.Data.Initialize
{
    /// <summary>
    /// 数据库初始化策略
    /// </summary>
    public class DropCreateDatabaseIfModel : DropCreateDatabaseAlways<MesContext> 
    {
        protected override void Seed(MesContext context)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            int num = 11;
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

            Initialize<User>.Infial(num).ForEach(u => context.Set<User>().Add(u));
            Initialize<UserGroup>.Infial(num).ForEach(u => context.Set<UserGroup>().Add(u));
            Initialize<Res>.Infial(num).ForEach(u => context.Set<Res>().Add(u));
            Initialize<Mdl>.Infial(num).ForEach(u => context.Set<Mdl>().Add(u));


            //List<UserGroup> userGroups = new List<UserGroup>
            //{
            //    new UserGroup{usergroupcode="usergroupcode1",usergroupdesc="usergroupdesc1",usergrouptype="usergrouptype1",muser="muser1",mdate=DateTime.Now,eattribute1="eattribute1"},
            //    new UserGroup{usergroupcode="usergroupcode2",usergroupdesc="usergroupdesc2",usergrouptype="usergrouptype2",muser="muser2",mdate=DateTime.Now,eattribute1="eattribute2"}
            //};
            //DbSet<UserGroup> userGroup = context.Set<UserGroup>();
            //userGroups.ForEach(u => userGroup.Add(u));
            //var userGroupList = userSet.Find("65128044").UserGroups;
            //userGroupList.Add(userGroup.First());
            
            context.Configuration.AutoDetectChangesEnabled = true;
            context.SaveChanges();
        }
        #region 用户初始化
        public List<User> UserInfial()
        {
            List<User> users = new List<User>();
            User userType = new User();
            Type t = userType.GetType();
            for (int i = 1; i < 11; i++)
            {
                User user = new User();
                user.AddDate = DateTime.Now;
                user.eattribute1 = "123";
                user.IsDeleted = false;
                user.mdate = DateTime.Now;
                user.muser = "123";
                user.usercode = "65128047";
                user.userdepart = "123";
                user.useremail = "123";
                user.username = "lg";
                user.userpwd = "123";
                user.userstat = "123";
                user.usertel = "123";
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    pi.Attributes.GetType();
                    //object value1 = pi.GetValue(user, null);//用pi.GetValue获得值
                    object value1 = pi.PropertyType;
                    string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                    //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数  
                    if (value1 == null)
                    {
                        continue;
                    }
                    if (value1.GetType() == typeof(string))
                    {
                        pi.SetValue(user, name + i, null);
                    }
                    if (value1.GetType() == typeof(DateTime))
                    {
                        pi.SetValue(user, DateTime.Now, null);
                    }
                    if (value1.GetType() == typeof(bool))
                    {
                        pi.SetValue(user, false, null);
                    }
                    object value2 = pi.GetValue(user, null);//用pi.GetValue获得值                
                    //  Console.WriteLine(name + ":" + value2);

                }
                if (user.usercode != null)
                    users.Add(user);
            }


            return users;

        }
        #endregion
        #region 用户组初始化

        #endregion



    }
}