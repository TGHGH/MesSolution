using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Frm.Service;
using Component.Tools;

namespace UnitTestForm.Service.UnitTestIFrmGoodNGService
{
    [TestClass]
    public class UnitTestIFrmGoodNGService_ActionNG:UnitTestBase
    {      
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
           // string prefix = "2014";
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
