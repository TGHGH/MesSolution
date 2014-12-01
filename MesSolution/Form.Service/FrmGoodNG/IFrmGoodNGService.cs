using Component.Tools;

namespace Frm.Service.FrmGoodNG
{
    public interface IFrmGoodNgService
    {
        OperationResult FindSnCheck(string moString);    
        OperationResult CardGoMoCheck(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
        OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card, string rescode, string usercode);
        OperationResult ActionGoodCheck(string usercode, string rescode, string card);
        OperationResult ActionGood(string usercode, string rescode, string card);
        OperationResult ActionNgCheck(string card, string usercode, string rescode, string selectedEcg, string selectedEc);

        OperationResult ActionNg(string card, string usercode, string rescode, string selectedEcg, string selectedEc);
    }
}
