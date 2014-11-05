using Component.Tools;
using System;
namespace FormApplication.Service
{
    public interface IFrmGoodNGService
    {
        OperationResult FindSnCheck(string moString);    
        OperationResult CheckCardFristOp(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
        OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
    }
}
