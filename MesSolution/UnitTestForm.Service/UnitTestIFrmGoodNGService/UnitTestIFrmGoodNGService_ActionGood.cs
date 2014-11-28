using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Frm.Service;
using Component.Tools;
using System.Reflection;

namespace UnitTestForm.Service.UnitTestIFrmGoodNGService
{
    [TestClass]
    public class UnitTestIFrmGoodNGService_ActionGood:UnitTestBase
    {
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
    }
}
