﻿using System;
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
using GMF.Demo.Core.Data.Initialize;
using Component.Data;
using Core.Db.Context;


namespace Presentation.Consoles
{
    [Export]
    internal class Program
    {
        private static CompositionContainer _container;
        private static AggregateCatalog catalog;
     //   [Import(RequiredCreationPolicy = CreationPolicy.NonShared)]
     //   public ContainerIn cin { get; set; }



        #region 主程序

        private static void Main(string[] args)
        {
            //初始化数据库，如果存在且模型改变，删除重新建
            DatabaseInitializer.DropCreateDatabaseIfModelChanges();

            //初始化MEF组合容器
            catalog = new AggregateCatalog();
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
            var studentManager1 = _container.GetExportedValue<ContainerIn>();
            var studentManager2 = _container.GetExportedValue<ContainerIn>();
            Console.WriteLine(object.ReferenceEquals(studentManager1, studentManager2));
            var studentManager3 = _container.GetExportedValue<MesContext>();
            var studentManager4 = _container.GetExportedValue<MesContext>();
            Console.WriteLine(object.ReferenceEquals(studentManager3, studentManager4));
        }

        private static void Method02()
        {
            Console.WriteLine(_container.GetExportedValue<IMemberRepository>().GetType());
        }

        //添加
        private static void Method03()
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
            OperationResult result = _container.GetExportedValue<IUserSiteContract>().AddUser(user);
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }
        //查询
        private static void Method04()
        {

            OperationResult result = _container.GetExportedValueOrDefault<ContainerIn>().UserContract.QueryUser("65128044");
            User user = (User)result.AppendData;
            Console.WriteLine(user.userpwd);
            Console.WriteLine();
        }

        //修改,提交
        private static void Method05()
        {
            OperationResult result = _container.GetExportedValueOrDefault<ContainerIn>().UserContract.UpdateUser("65128044", "222");
            User user = (User)result.AppendData;
            Console.WriteLine(user.userpwd);
            Console.WriteLine();
        }
        //修改，回滚
        private static void Method06()
        {
            OperationResult result = _container.GetExportedValueOrDefault<ContainerIn>().UserContract.UpdateUser2("65128044", "222");
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
           
        }

        private static void Method08()
        {

           
        }

        private static void Method09()
        {
            //_container.Dispose();
            
            //_container = new CompositionContainer(catalog);
            
            ContainerIn pro = _container.GetExportedValue<ContainerIn>();
            CompositionBatch batch = new CompositionBatch();           
            if (pro.UserContract == null)
                Console.WriteLine("MesContext null");
            else
                Console.WriteLine("MesContext not null");
        
        }

        private static void Method10()
        {
            Program program = new Program();
            Program progarm2 = new Program();
           // Console.WriteLine(ReferenceEquals(program.cin, progarm2.cin));
            Console.WriteLine(ReferenceEquals(_container.GetExportedValue<ContainerIn>().UserContract, _container.GetExportedValue<ContainerIn>().UserContract));

            Console.WriteLine(_container.GetExportedValue<ContainerIn>().UserContract.Equals(_container.GetExportedValue<ContainerIn>().UserContract));
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