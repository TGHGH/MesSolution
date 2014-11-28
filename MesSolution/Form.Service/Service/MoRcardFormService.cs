using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IMoRcardFormService))]
	public class MoRcardFormService : MoRcardService ,IMoRcardFormService
	{

	}
}
