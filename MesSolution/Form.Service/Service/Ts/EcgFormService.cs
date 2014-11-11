using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IEcgFormService))]
	public class EcgFormService : EcgService ,IEcgFormService
	{

	}
}
