using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IMoRcardFormService))]
	public class MoRcardFormService : MoRcardService ,IMoRcardFormService
	{

	}
}
