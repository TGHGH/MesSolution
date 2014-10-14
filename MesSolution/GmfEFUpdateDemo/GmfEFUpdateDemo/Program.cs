using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;

using Gmf.Demo.EFUpdate.Migrations;
using Gmf.Demo.EFUpdate.Models;


namespace Gmf.Demo.EFUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var migrate = new MigrateDatabaseToLatestVersion<DataContext, Configuration>();
                Database.SetInitializer(migrate);
                using (var db = new DataContext())
                {
                    Console.WriteLine("数据初始化完成：部门信息{0}条，角色信息{1}条，人员信息{2}条", db.Departments.Count(), db.Roles.Count(), db.Members.Count());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(new ExceptionMessage(e));
            }
        Reinput:
            try
            {
                Console.WriteLine("请输入：功能1-n，退出0");
                int input;
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    goto Reinput;
                }

                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        Method01();
                        goto Reinput;
                    case 2:
                        Method02();
                        goto Reinput;
                    case 3:
                        Method03();
                        goto Reinput;
                    case 4:
                        Method04();
                        goto Reinput;
                    case 5:
                        Method05();
                        goto Reinput;
                    case 6:
                        Method06();
                        goto Reinput;
                    case 7:
                        Method07();
                        goto Reinput;
                    case 8:
                        Method08();
                        goto Reinput;
                    case 9:
                        Method09();
                        goto Reinput;
                    default:
                        Console.WriteLine("编号{0}的功能不存在。\r\n", input);
                        goto Reinput;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(new ExceptionMessage(e));
                goto Reinput;
            }
        }

        //情景一：取出数据更新后直接保存
        private static void Method01()
        {
            using (var db = new DataContext())
            {
                const string userName = "郭明锋";
                Member oldMember = db.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);

                oldMember.AddDate = oldMember.AddDate.AddMinutes(10);
                db.Update(oldMember);
                int count = db.SaveChanges();
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新后：{0}。", newMember.AddDate);
            }
        }

        //情景二：从上下文1中取出数据并修改，再在上下文2中进行保存
        private static void Method02()
        {
            const string userName = "郭明锋";

            Member updateMember;
            using (var db1 = new DataContext())
            {
                updateMember = db1.Members.Single(m => m.UserName == userName);
            }
            updateMember.AddDate = DateTime.Now;

            using (var db2 = new DataContext())
            {
                db2.Members.Attach(updateMember);
                DbEntityEntry<Member> entry = db2.Entry(updateMember);
                Console.WriteLine("Attach成功后的状态：{0}", entry.State); //附加成功之后，状态为EntityState.Unchanged
                entry.State = EntityState.Modified;
                int count = db2.SaveChanges();
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新后：{0}。", newMember.AddDate);
            }
        }

        //情景三：在情景二的基础上，上下文2中已存在与外来实体主键相同的数据了，引发InvalidOperationException异常
        private static void Method03()
        {
            const string userName = "郭明锋";

            Member updateMember;
            using (var db1 = new DataContext())
            {
                updateMember = db1.Members.Single(m => m.UserName == userName);
            }
            updateMember.AddDate = DateTime.Now;

            using (var db2 = new DataContext())
            {
                //先查询一次，让上下文中存在相同主键的对象
                Member oldMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);
                var dbset = db2.Members.Local;

                db2.Members.Attach(updateMember);
                DbEntityEntry<Member> entry = db2.Entry(updateMember);
                Console.WriteLine("Attach成功后的状态：{0}", entry.State); //附加成功之后，状态为EntityState.Unchanged
                entry.State = EntityState.Modified;
                int count = db2.SaveChanges();
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新后：{0}。", newMember.AddDate);
            }
        }

        //针对Method03的InvalidOperationException异常的处理方案
        private static void Method04()
        {
            const string userName = "郭明锋";

            Member updateMember;
            using (var db1 = new DataContext())
            {
                updateMember = db1.Members.Single(m => m.UserName == userName);
            }
            updateMember.AddDate = DateTime.Now;

            using (var db2 = new DataContext())
            {
                //先查询一次，让上下文中存在相同主键的对象
                Member oldMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);

                DbEntityEntry<Member> entry = db2.Entry(oldMember);
                entry.CurrentValues.SetValues(updateMember);
                int count = db2.SaveChanges();
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新后：{0}。", newMember.AddDate);
            }
        }

        private static void Method05()
        {
            const string userName = "郭明锋";

            Member updateMember;
            using (var db1 = new DataContext())
            {
                updateMember = db1.Members.Single(m => m.UserName == userName);
            }
            updateMember.AddDate = DateTime.Now;

            using (var db2 = new DataContext())
            {
                //先查询一次，让上下文中存在相同主键的对象
                Member oldMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);

                db2.Update<Member>(updateMember);
                int count = db2.SaveChanges();
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db2.Members.Single(m => m.UserName == userName);
                Console.WriteLine("更新后：{0}。", newMember.AddDate);
            }
        }

        private static void Method06()
        {
            Member member = new Member { Id = 1, Password = "NewPassword" + DateTime.Now.Second };
            using (var db = new DataContext())
            {
                DbEntityEntry<Member> entry = db.Entry(member);
                entry.State = EntityState.Unchanged;
                entry.Property("Password").IsModified = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                int count = db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新后：{0}。", newMember.Password);
            }
        }

        private static void Method07()
        {
            Member member = new Member { Id = 1, Password = "NewPassword" + DateTime.Now.Second };
            using (var db = new DataContext())
            {
                //先查询一次，让上下文中存在相同主键的对象
                Member oldMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);

                try
                {
                    DbEntityEntry<Member> entry = db.Entry(member);
                    entry.State = EntityState.Unchanged;
                    entry.Property("Password").IsModified = true;
                }
                catch (InvalidOperationException)
                {
                    DbEntityEntry<Member> entry = db.Entry(oldMember);
                    entry.CurrentValues.SetValues(member);
                    entry.State = EntityState.Unchanged;
                    entry.Property("Password").IsModified = true;
                }
                db.Configuration.ValidateOnSaveEnabled = false;
                int count = db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新后：{0}。", newMember.Password);
            }
        }

        private static void Method08()
        {
            Member member = new Member { Id = 1, Password = "NewPassword" + DateTime.Now.Second };
            using (var db = new DataContext())
            {
                //先查询一次，让上下文中存在相同主键的对象
                Member oldMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);

                try
                {
                    DbEntityEntry<Member> entry = db.Entry(member);
                    entry.State = EntityState.Unchanged;
                    entry.Property("Password").IsModified = true;
                }
                catch (InvalidOperationException)
                {
                    ObjectContext objectContext = ((IObjectContextAdapter)db).ObjectContext;
                    ObjectStateEntry objectEntry = objectContext.ObjectStateManager.GetObjectStateEntry(oldMember);
                    objectEntry.ApplyCurrentValues(member);
                    objectEntry.ChangeState(EntityState.Unchanged);
                    objectEntry.SetModifiedProperty("Password");
                }
                db.Configuration.ValidateOnSaveEnabled = false;
                int count = db.SaveChanges();
                db.Configuration.ValidateOnSaveEnabled = true;
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新后：{0}。", newMember.Password);
            }
        }

        private static void Method09()
        {
            Member member = new Member { Id = 1, Password = "NewPassword" + DateTime.Now.Second };
            using (var db = new DataContext())
            {
                //先查询一次，让上下文中存在相同主键的对象
                Member oldMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新前：{0}。", oldMember.AddDate);

                db.Update<Member>(m => new { m.Password }, member);
                int count = db.SaveChanges(false);
                Console.WriteLine("操作结果：{0}", count > 0 ? "更新成功。" : "未更新。");

                Member newMember = db.Members.Single(m => m.Id == 1);
                Console.WriteLine("更新后：{0}。", newMember.Password);
            }
        }
    }
}
