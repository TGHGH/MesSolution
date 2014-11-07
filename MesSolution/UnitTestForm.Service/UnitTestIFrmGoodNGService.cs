using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using FormApplication.Service;
using Component.Tools;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace UnitTestForm.Service
{
    [TestClass]
    public class UnitTestIFrmGoodNGService:UnitTestBase
    {       

        [TestMethod]
        public void TestGoToMo()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo("mocode1", "11", "20141107", "20141107001", "rescode1", "usercode1");
            Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
     
        }
        [TestMethod]
        public void TestGoToMo2()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo("mocode1", "11", "20141107", "20141107001", "rescode1", "usercode1");
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Error);
                
            }

        }
    }
}
