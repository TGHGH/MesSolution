using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IResFormService))]
	public class ResFormService : ResService ,IResFormService
	{

	}
}
