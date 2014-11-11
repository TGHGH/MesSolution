using Component.Tools;
using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IMoFormService))]
	public class MoFormService : MoService ,IMoFormService
	{
       
	}
}
