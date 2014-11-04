using Component.Tools;
using FormApplication.Service;
using System;
namespace FormApplication.Service
{
    public interface IFrmGoodNGService
    {
        OperationResult FindSnCheck(string moString);
        IItem2SnCheckFormService iItem2SnCheckFormService { get; set; }
        IMoFormService iMoFormService { get; set; }
        OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
    }
}
