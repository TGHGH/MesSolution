using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ITsErrorCauseFormService))]
	public class TsErrorCauseFormService : TsErrorCauseService ,ITsErrorCauseFormService
	{

	}
}
