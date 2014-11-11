using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ITsErrorCodeFormService))]
	public class TsErrorCodeFormService : TsErrorCodeService ,ITsErrorCodeFormService
	{

	}
}
