using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Component.Tools;
using Frm.Models.FrmLogin;
using Frm.Service.FrmLogin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForm.Service.FrmLogin
{
    [TestClass]
    public class FrmLoginTest_Login:UnitTestBase
    {
        private const string UserCode = "usercode1";
        private const string Password = "userpwd1";
        private const string ResCode = "rescode1";

        private const string UserNotExist = "123";
        private const string PasswordError = "123";
        private const string UserNotRes = "123";
        [TestMethod]
        public void Login()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var loginModel = new LoginModel {Account = UserCode, Password = Password, ResCode = ResCode};
            using (var container = new CompositionContainer(catalog))
            {
                OperationResult operationResult = container.GetExportedValue<IFrmLoginService>().Login(loginModel);
                Assert.IsTrue(operationResult.Message.Equals(Properties.Resources.FrmLogin_Login_LoginSuccess));
            }
        }
         [TestMethod]
        public void Login_UserNotExist()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var loginModel = new LoginModel { Account = UserNotExist, Password = Password, ResCode = ResCode };
             using (var container = new CompositionContainer(catalog))
            {
                OperationResult operationResult = container.GetExportedValue<IFrmLoginService>().Login(loginModel);
                Assert.IsTrue(operationResult.Message.Equals(Properties.Resources.FrmLogin_Login_UserNotExist));
            }
        }

        [TestMethod]
         public void Login_PasswordError()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var loginModel = new LoginModel { Account = UserCode, Password = PasswordError, ResCode = ResCode };
            using (var container = new CompositionContainer(catalog))
            {
                OperationResult operationResult = container.GetExportedValue<IFrmLoginService>().Login(loginModel);
                Assert.IsTrue(operationResult.Message.Equals(Properties.Resources.FrmLogin_Login_PasswordError));
            }
        }

        [TestMethod]
        public void Login_Login_UserNotRes()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var loginModel = new LoginModel { Account = UserCode, Password = Password, ResCode = UserNotRes };
            using (var container = new CompositionContainer(catalog))
            {
                OperationResult operationResult = container.GetExportedValue<IFrmLoginService>().Login(loginModel);
                Assert.IsTrue(operationResult.Message.Equals(Properties.Resources.FrmLogin_Login_UserNotRes));
            }
        }
    }
}
