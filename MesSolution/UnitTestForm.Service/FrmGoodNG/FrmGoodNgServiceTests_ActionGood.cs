using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Component.Tools;
using Frm.Service.FrmGoodNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForm.Service.FrmGoodNG
{
    [TestClass]
    public class UnitTestIFrmGoodNgService_ActionGood:UnitTestBase
    {
        [TestMethod]
        public void ActionGood()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            const string mocode = "mocode1";
            const string usercode = "usercode1";
            const string card = "20141107002";
            const string leng = "11";
            const string prefix = "2014";
            const string rescode = "rescode1";
            const string rescode2 = "rescode2";


            using (var testContainer = new CompositionContainer(catalog))
            {
                testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(mocode, leng, prefix, card, rescode, usercode);

            }
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().ActionGood(usercode, rescode2, card);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }

        }
    }
}
