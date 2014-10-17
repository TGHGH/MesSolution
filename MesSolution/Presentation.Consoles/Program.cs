using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Component.Tools;
using Core.Db.Repositories;
using Core.Models;
using Application.Site;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Presentation.Consoles
{
    [Export]
    internal class Program
    {
        private static CompositionContainer _container;

        [Import]
        public IAccountSiteContract AccountContract { get; set; }
        [Import]
        public IUserSiteContract UserContract { get; set; }
        [Import]
        public DbContext MesContext { get; set; }

        #region 主程序

        private static void Main(string[] args)
        {
            //初始化MEF组合容器
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            _container = new CompositionContainer(catalog);

            bool exit = false;
            while (true)
            {
                try
                {
                    Console.WriteLine("请输入命令：0; 退出程序，功能命令：1 - n");
                    string input = Console.ReadLine();
                    if (input == null)
                    {
                        continue;
                    }
                    switch (input.ToLower())
                    {
                        case "0":
                            exit = true;
                            break;
                        case "1":
                            Method01();
                            break;
                        case "2":
                            Method02();
                            break;
                        case "3":
                            Method03();
                            break;
                        case "4":
                            Method04();
                            break;
                        case "5":
                            Method05();
                            break;
                        case "6":
                            Method06();
                            break;
                        case "7":
                            Method07();
                            break;
                        case "8":
                            Method08();
                            break;
                        case "9":
                            Method09();
                            break;
                        case "10":
                            Method10();
                            break;
                        case "11":
                            Method11();
                            break;
                        case "12":
                            Method12();
                            break;
                        case "13":
                            Method13();
                            break;
                        case "14":
                            Method14();
                            break;
                    }
                    if (exit)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler(e);
                }
            }
        }

        private static void ExceptionHandler(Exception e)
        {
            ExceptionMessage emsg = new ExceptionMessage(e);
            Console.WriteLine(emsg.ErrorDetails);
        }

        #endregion

        #region 功能方法

        private static void Method01()
        {
            Program program = _container.GetExportedValue<Program>();
            Console.WriteLine(program.AccountContract.GetType().FullName);
            LoginInfo loginInfo = new LoginInfo { Access = "gmfcn", Password = "123456", IpAddress="127.0.0.1" };
            OperationResult result = program.AccountContract.Login(loginInfo);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }

        private static void Method02()
        {
            Console.WriteLine(_container.GetExportedValue<IMemberRepository>().GetType());
        }

        //添加
        private static void Method03()
        {
            Program program = _container.GetExportedValue<Program>();
            User user = new User();
            user.AddDate = DateTime.Now;
            user.eattribute1 = "123";
            user.IsDeleted = false;
            user.mdate = DateTime.Now;
            user.muser = "123";
            user.usercode = "65128044";
            user.userdepart = "123";
            user.useremail = "123";
            user.username = "lg";
            user.userpwd = "123";
            user.userstat = "123";
            user.usertel = "123";
            OperationResult result = program.UserContract.AddUser(user);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }
        //查询
        private static void Method04()
        {
            Program program = _container.GetExportedValue<Program>();           
            OperationResult result = program.UserContract.QueryUser("65128042");
            User user = (User)result.AppendData;
            Console.WriteLine(user.useremail);
            Console.WriteLine();
        }

        //修改,提交
        private static void Method05()
        {
            Program program = _container.GetExportedValue<Program>();
            OperationResult result = program.UserContract.UpdateUser("65128044","222");
            User user =(User) result.AppendData;
            Console.WriteLine(user.userpwd);
            Console.WriteLine();
        }
        //修改，回滚
        private static void Method06()
        {
            Program program = _container.GetExportedValue<Program>();
            OperationResult result = program.UserContract.UpdateUser("65128043", "12345");           
            User user = (User)result.AppendData;
            Console.WriteLine(user.userpwd);
            Console.WriteLine();
        }

        private static void PrintChangeTrackingInfo(DbContext context, User entity)
        {
            var entry = context.Entry(entity);
            Console.WriteLine(entry.Entity.userpwd);
            Console.WriteLine("State: {0}", entry.State);

            Console.WriteLine("\nCurrent Values:");
            PrintPropertyValues(entry.CurrentValues);

            Console.WriteLine("\nOriginal Values:");
            PrintPropertyValues(entry.OriginalValues);

            Console.WriteLine("\nDatabase Values:");
            PrintPropertyValues(entry.GetDatabaseValues());
        }
        private static void PrintPropertyValues(DbPropertyValues values)
        {
            foreach (var propertyName in values.PropertyNames)
            {
                if (propertyName.ToString().Equals("userpwd"))
                Console.WriteLine(" - {0}: {1}", propertyName, values[propertyName]);
            }
        }

        private static void Method07()
        {
            Program program = _container.GetExportedValue<Program>();
            User user = program.MesContext.Set<User>().Find("65128044");

            program.MesContext.Entry<User>(user).Reload();
           // user.userpwd = "111";
            PrintChangeTrackingInfo(program.MesContext, user);
            Console.WriteLine(user.userpwd);           
            program.MesContext.SaveChanges();            
            Console.WriteLine();
        }

        private static void Method08()
        {
            throw new NotImplementedException();
        }

        private static void Method09()
        {
            throw new NotImplementedException();
        }

        private static void Method10()
        {
            throw new NotImplementedException();
        }

        private static void Method11()
        {
            throw new NotImplementedException();
        }

        private static void Method12()
        {
            throw new NotImplementedException();
        }

        private static void Method13()
        {
            throw new NotImplementedException();
        }

        private static void Method14()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}