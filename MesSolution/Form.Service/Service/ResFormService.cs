using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IResFormService))]
	public class ResFormService : ResService ,IResFormService
	{

	}
}
