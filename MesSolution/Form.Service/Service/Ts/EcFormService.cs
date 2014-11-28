using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IEcFormService))]
	public class EcFormService : EcService ,IEcFormService
	{

	}
}
