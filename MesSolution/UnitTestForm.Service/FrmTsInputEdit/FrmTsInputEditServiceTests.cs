using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Component.Tools;
using Core.Models;
using Core.Service;
using Frm.Models;
using Frm.Service;
using Frm.Service.FrmGoodNG;
using Frm.Service.FrmTsInputEdit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForm.Service.FrmTsInputEdit
{
    [TestClass]
    public class FrmTsInputEditServiceTests
    {
       
        const string Mocode = "mocode1";
        const string Usercode = "usercode1";
        const string Card = "20141107006";
        const string Rescode = "rescode1";
        const string Rescode2 = "rescode2";
        const string Leng = "11";
        const string Prefix = "2014";
        const string ErrorSeasonCodeGroup = "ecsgcode1";
        const string Ecg = "AUTONG";
        const string Ec = "AUTONG";
        private const string RouteCode = "routecode1";
        private const string OpCode = "opcode2";
        [TestMethod]
        public void ActionNgConfirm()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                testContainer.GetExportedValue<IFrmGoodNgService>().CardGoMo(Mocode, Leng, Prefix, Card, Rescode, Usercode);

            }
            using (var testContainer = new CompositionContainer(catalog))
            {
                testContainer.GetExportedValue<IFrmGoodNgService>().ActionNg(Card, Usercode, Rescode2, Ecg, Ec);
                
            }
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().ActionNgConfirm(Card);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
        }

        [TestMethod]
        public void TsErrorCauseEdit()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().TsErrorCauseEdit(Card);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
        }

        [TestMethod]
        public void GetErrorCodeSeasonByGroup()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().GetErrorCodeSeasonByGroup(ErrorSeasonCodeGroup);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
        }

        [TestMethod]
        public void TsCompleteCheck()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            
            
            using (var testContainer = new CompositionContainer(catalog))
            {
                TsErrorCause tec = new TsErrorCause();
                tec.errorCom = testContainer.GetExportedValue<IModelFormService>().Models().FirstOrDefault(m => m.MODELCODE == "modelcode1").errorComs.FirstOrDefault();
                tec.errorCodeSeason = testContainer.GetExportedValue<IEcsFormService>().Ecss().FirstOrDefault();
                tec.duty = testContainer.GetExportedValue<IDutyFormService>().Dutys().FirstOrDefault();
                tec.solution = testContainer.GetExportedValue<IModelFormService>().Models().FirstOrDefault(m => m.MODELCODE == "modelcode1").solutions.FirstOrDefault();
                tec.solmemo = Usercode;
                tec.muser = Usercode;
                DateTime dt = DateTime.Now;
                tec.mtime = Convert.ToInt32(dt.Hour.ToString() + dt.Minute + dt.Second);
                tec.mdate = Convert.ToInt32(dt.Year.ToString() + dt.Month + dt.Day);
                testContainer.GetExportedValue<ITsFormService>().Tss().FirstOrDefault(t => t.rcard == Card).tsErrorCodes.FirstOrDefault().tsErrorCauses.Add(tec);
                OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().TsCompleteCheck(Card);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
        }
        
        [TestMethod]
        public void TsCompleteConfirm()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Directory.GetCurrentDirectory()));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            using (var testContainer = new CompositionContainer(catalog))
            {
                TsCompleteModel CompleteModel=new TsCompleteModel();
                CompleteModel.moString = Mocode;
                CompleteModel.routeString = RouteCode;
                CompleteModel.opString = OpCode;
                CompleteModel.ts =testContainer.GetExportedValue<ITsFormService>().Tss().FirstOrDefault(t => t.rcard == Card);
                OperationResult operationResult = testContainer.GetExportedValue<IFrmTsInputEditService>().TsCompleteConfirm(CompleteModel);
                Assert.IsTrue(operationResult.ResultType == OperationResultType.Success);
            }
        }
    }
}
