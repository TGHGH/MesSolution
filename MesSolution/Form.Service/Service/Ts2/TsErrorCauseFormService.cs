using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ITsErrorCauseFormService))]
	public class TsErrorCauseFormService : TsErrorCauseService ,ITsErrorCauseFormService
	{

	}
}
