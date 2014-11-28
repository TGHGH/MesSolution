using Component.Tools;
using System;
namespace Frm.Service
{
    public interface IFrmGoodNGService
    {
        OperationResult FindSnCheck(string moString);    
        OperationResult CardGoMoCheck(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
        OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
        OperationResult ActionGoodCheck(string usercode, string rescode, string card);
        OperationResult ActionGood(string usercode, string rescode, string card);
        OperationResult ActionNGCheck(string card, string usercode, string rescode, string selectedEcg, string selectedEc);

        OperationResult ActionNG(string card, string usercode, string rescode, string selectedEcg, string selectedEc);
    }
}
