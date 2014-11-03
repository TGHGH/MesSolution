using Component.Tools;
using Core.Models;
using Core.Service;
using System;
using System.ComponentModel.Composition;
using System.Linq;


namespace FormApplication.Service
{
    [Export(typeof(IFrmGoodNGService))]
    public class FrmGoodNGService : IFrmGoodNGService  
	{
        [Import]
        public IMoFormService iMoFormService { get; set; }
        [Import]
        public IItem2SnCheckFormService iItem2SnCheckFormService { get; set; }     
     

        public OperationResult FindSnCheck(string moString)
        {
            OperationResult operationResult = iMoFormService.FindEntity(moString);
            Mo mo =(Mo) operationResult.AppendData;
            if (operationResult.ResultType == OperationResultType.Success)
            {         
                Item2SnCheck item2SnCheck= iItem2SnCheckFormService.Item2SnChecks().SingleOrDefault(i => i.ITEMCODE==mo.ITEMCODE);
                operationResult.AppendData = item2SnCheck;
            }
            return operationResult;
        }
	}
}
