using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IEcFormService))]
	public class EcFormService : EcService ,IEcFormService
	{

	}
}
