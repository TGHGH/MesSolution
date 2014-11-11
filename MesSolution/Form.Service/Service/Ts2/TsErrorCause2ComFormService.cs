using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ITsErrorCause2ComFormService))]
	public class TsErrorCause2ComFormService : TsErrorCause2ComService ,ITsErrorCause2ComFormService
	{

	}
}
