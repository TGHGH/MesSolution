using Component.Tools;
using FormApplication.Service;
using System;
namespace FormApplication.Service
{
    interface IFrmGoodNGService
    {
        OperationResult FindSnCheck(string moString);
        IItem2SnCheckFormService iItem2SnCheckFormService { get; set; }
        IMoFormService iMoFormService { get; set; }
    }
}
