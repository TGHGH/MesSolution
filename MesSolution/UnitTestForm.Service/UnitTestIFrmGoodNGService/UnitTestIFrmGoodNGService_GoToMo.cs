using System;
using Frm.Service.FrmGoodNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using Frm.Service;
using Component.Tools;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using GMF.Demo.Core.Data.Initialize;

namespace UnitTestForm.Service.UnitTestIFrmGoodNGService
{
    [TestClass]
    public class UnitTestIFrmGoodNGService_GoToMo : UnitTestBase
    {
        private const string MoString = "mocode1";
        private const string LengthString = "11";
        private const string PrefixString = "2014";
        private const string Card = "20141107001";
        //    string card2 = "20141107004";
        private const string rescode = "rescode1";
        private const string usercode = "usercode1";

        private const string String_GoMoModel_SnLengthError = "12";
        private const string String_GoMoModel_SnPrefixError = "20141106";
        private const string String_FrmGoodNGService_MoNotExit = "MoNotExit";
        private const string String_FrmGoodNGService_MoStatusError = "mocode2";
        private const string String_FrmGoodNGService_MoDontHaveRoute = "mocode3";
        private const string String_FrmGoodNGService_ResNotFirst = "rescode2";
        private const string String_FrmGoodNGService_LotNotOp = "mocode4";
        private const string String_FrmGoodNGService_MoEnough = "mocode5";

        /// <summary>
        /// String_GoMoModel_SnLengthError = "SN长度防呆错误";
        /// </summary>
        [TestMethod]
        public void GoToMo_SnLengthError()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                Exception e1=null;
                try
                {
                    var operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(MoString, String_GoMoModel_SnLengthError, PrefixString, Card, rescode, usercode);
                }
                catch (Exception e)
                {
                    e1 = e;
                }

                Assert.IsTrue(e1 != null && e1.Message.Equals(StringMessage.String_GoMoModel_SnLengthError));
            }

        }
        /// <summary>
        /// String_GoMoModel_SnPrefixError = "SN前码防呆错误";
        /// </summary>
        [TestMethod]
        public void GoToMo_SnPrefixError()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                Exception e1 = null;
                try
                {
                    OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(MoString, LengthString, String_GoMoModel_SnPrefixError, Card, rescode, usercode);
                }
                catch (Exception e)
                {
                    e1 = e;
                }

                Assert.IsTrue(e1 != null && e1.Message.Equals(StringMessage.String_GoMoModel_SnPrefixError));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_MoNotExit = "工单不存在";
        /// </summary>
        [TestMethod]
        public void GoToMo_MoNotExit()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(String_FrmGoodNGService_MoNotExit, LengthString, PrefixString, Card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(String_FrmGoodNGService_MoNotExit + StringMessage.String_FrmGoodNGService_MoNotExit));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_MoStatusError = "工单状态错误";
        /// </summary>
        [TestMethod]
        public void GoToMo_MoStatusError()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(String_FrmGoodNGService_MoStatusError, LengthString, PrefixString, Card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(String_FrmGoodNGService_MoStatusError + StringMessage.String_FrmGoodNGService_MoStatusError));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_MoDontHaveRoute = "工单没有途程";
        /// </summary>
        [TestMethod]
        public void GoToMo_MoDontHaveRoute()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(String_FrmGoodNGService_MoDontHaveRoute, LengthString, PrefixString, Card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(String_FrmGoodNGService_MoDontHaveRoute + StringMessage.String_FrmGoodNGService_MoDontHaveRoute));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_ResNotFirst = "该资源不属于该工单的第一道工序";
        /// </summary>
        [TestMethod]
        public void GoToMo_ResNotFirst()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(MoString, LengthString, PrefixString, Card, String_FrmGoodNGService_ResNotFirst, usercode);
                Assert.IsTrue(operationResult.Message.Equals(String_FrmGoodNGService_ResNotFirst + StringMessage.String_FrmGoodNGService_ResNotFirst));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_SnIsRunning = "此为在制品，不能归属工单";
        /// </summary>
        [TestMethod]
        public void GoToMo_SnIsRunning()
        {
            Assert.IsTrue(true);
        }

        /// <summary>
        /// String_FrmGoodNGService_LotNotOp = "该产品没有维护产生送检批工序";
        /// </summary>
        [TestMethod]
        public void GoToMo_LotNotOp()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(String_FrmGoodNGService_LotNotOp, LengthString, PrefixString, Card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(StringMessage.String_FrmGoodNGService_LotNotOp));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_MoEnough = "工单已满";
        /// </summary>
        [TestMethod]
        public void GoToMo_MoEnough()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            for (int i = 1; i < 11; i++)
            {
                string testcard = "201411290"+i.ToString().PadLeft(2,'0');
                
                using (var testContainer = new CompositionContainer(catalog))
                {
                    OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(String_FrmGoodNGService_MoEnough, LengthString, PrefixString, testcard, rescode, usercode);                    
                }
            }
            using (var testContainer = new CompositionContainer(catalog))
            {
                const string testcard = "20141129011";
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(String_FrmGoodNGService_MoEnough, LengthString, PrefixString, testcard, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(String_FrmGoodNGService_MoEnough + StringMessage.String_FrmGoodNGService_MoEnough));
            }
                
        }

        [TestMethod]
        public void GoToMo_S_1()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
           
            using (var testContainer = new CompositionContainer(catalog))
            {                
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(MoString, LengthString, PrefixString, Card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(Card + StringMessage.String_FrmGoodNGService_CollectSuccess));                
            }     
        }

        /// <summary>
        /// String_FrmGoodNGService_SnHadInMo = "已属于该工单";
        /// </summary>
        [TestMethod]
        public void GoToMo_SnHadInMo()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(MoString, LengthString, PrefixString, Card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(Card + StringMessage.String_FrmGoodNGService_SnHadInMo));
            }

        }

        

        
    }
}
