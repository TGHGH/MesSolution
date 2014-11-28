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
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);                
            }     
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestGoToMo_F_1()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(moString, lengthString, prefixString, card, rescode, usercode);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Error);

            }

        }

        

        
    }
}
