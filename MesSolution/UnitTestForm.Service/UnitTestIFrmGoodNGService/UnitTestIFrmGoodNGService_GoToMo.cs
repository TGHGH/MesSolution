using System;
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
        string moString = "mocode1";
        string lengthString = "11";       
        string prefixString = "20141107";        
        string card = "20141107001";
        string rescode = "rescode1";
        string usercode = "usercode1";

        string String_GoMoModel_SnLengthError = "12";
        string String_GoMoModel_SnPrefixError = "20141106";
        string String_FrmGoodNGService_MoNotExit = "MoNotExit";
        /// <summary>
        /// String_GoMoModel_SnLengthError = "SN长度防呆错误";
        /// </summary>
        [TestMethod]
        public void TestGoToMo_SnLengthError()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                Exception e1=null;
                try
                {
                    OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(moString, String_GoMoModel_SnLengthError, prefixString, card, rescode, usercode);
                }
                catch (Exception e)
                {
                    e1 = e;
                }

                Assert.IsTrue(e1.Message.Equals(StringMessage.String_GoMoModel_SnLengthError));
            }

        }
        /// <summary>
        /// String_GoMoModel_SnPrefixError = "SN前码防呆错误";
        /// </summary>
        [TestMethod]
        public void TestGoToMo_SnPrefixError()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                Exception e1 = null;
                try
                {
                    OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(moString, lengthString, String_GoMoModel_SnPrefixError, card, rescode, usercode);
                }
                catch (Exception e)
                {
                    e1 = e;
                }

                Assert.IsTrue(e1.Message.Equals(StringMessage.String_GoMoModel_SnPrefixError));
            }

        }

        /// <summary>
        /// String_FrmGoodNGService_MoNotExit = "工单不存在";
        /// </summary>
        [TestMethod]
        public void TestGoToMo_MoNotExit()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(String_FrmGoodNGService_MoNotExit, lengthString, prefixString, card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(String_FrmGoodNGService_MoNotExit + StringMessage.String_FrmGoodNGService_MoNotExit));
            }

        }

        [TestMethod]
        public void TestGoToMo_S_1()
        {           
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
           
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {                
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(moString, lengthString, prefixString, card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(card + StringMessage.String_FrmGoodNGService_CollectSuccess));                
            }     
        }

        /// <summary>
        /// String_FrmGoodNGService_SnHadInMo = "已属于该工单";
        /// </summary>
        [TestMethod]
        public void TestGoToMo_SnHadInMo()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(moString, lengthString, prefixString, card, rescode, usercode);
                Assert.IsTrue(operationResult.Message.Equals(card + StringMessage.String_FrmGoodNGService_SnHadInMo));
            }

        }

        

        
    }
}
