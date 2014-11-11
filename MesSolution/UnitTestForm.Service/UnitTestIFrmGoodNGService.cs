using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using FormApplication.Service;
using Component.Tools;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using GMF.Demo.Core.Data.Initialize;

namespace UnitTestForm.Service
{
    [TestClass]
    public class UnitTestIFrmGoodNGService
    {
        public UnitTestIFrmGoodNGService()
        {
           
        }

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
        public void TestGoToMo_fail()
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

        [TestMethod]
        public void ActionGood()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            string mocode = "mocode1";
            string usercode = "usercode1";
            string card = "20141107002";
            string leng = "11";
            string prefix = "2014";
            string rescode = "rescode1";
            string rescode2 = "rescode2";


            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(mocode, leng, prefix, card, rescode, usercode);

            }
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().ActionGood(usercode, rescode2, card);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }

        }

        [TestMethod]
        public void ActionNG()
        {
            AggregateCatalog catalog;
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            string mocode = "mocode1";
            string usercode = "usercode1";
            string card = "20141107003";
            string rescode = "rescode1";
            string rescode2 = "rescode2";
            string leng = "11";
            string prefix = "2014";
            string ecg = "AUTONG";
            string ec = "AUTONG";

            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                testContainer.GetExportedValue<IFrmGoodNGService>().CardGoMo(mocode, leng, prefix, card, rescode, usercode);

            }
            using (CompositionContainer testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNGService>().ActionNG(card, usercode, rescode2, ecg, ec);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }

        }
    }
}
