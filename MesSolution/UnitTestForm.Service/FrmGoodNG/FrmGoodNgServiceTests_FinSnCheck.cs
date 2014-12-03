using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Component.Tools;
using Frm.Service.FrmGoodNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForm.Service.FrmGoodNG
{
    [TestClass]
    public class FrmGoodNgServiceTests:UnitTestBase
    {
        [TestMethod]
        public void FindSnCheck()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            const string mocode = "mocode1";

            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().FindSnCheck(mocode);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
        }
    }
}
