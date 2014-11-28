using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IEcgFormService))]
	public class EcgFormService : EcgService ,IEcgFormService
	{

	}
}
