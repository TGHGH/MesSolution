using Frm.Service.FrmGoodNG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Frm.Service;
using Component.Tools;

namespace UnitTestForm.Service.UnitTestIFrmGoodNGService
{
    [TestClass]
    public class UnitTestIFrmGoodNgServiceActionNg:UnitTestBase
    {      
        [TestMethod]
        public void ActionNg()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            const string mocode = "mocode1";
            const string usercode = "usercode1";
            const string card = "20141107005";
            const string rescode = "rescode1";
            const string rescode2 = "rescode2";
            const string leng = "11";
            const string prefix = "2014";
            const string ecg = "AUTONG";
            const string ec = "AUTONG";
            
            
            using (var testContainer = new CompositionContainer(catalog))
            {
                testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(mocode, leng, prefix, card, rescode, usercode);

            }
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmGoodNgService>().ActionNg(card, usercode, rescode2, ecg, ec);
                Assert.IsTrue(operationResult.Message.Equals(card +Properties.Resources.String_FrmGoodNGService_CollectSuccess));
            }

        }
    }
}
