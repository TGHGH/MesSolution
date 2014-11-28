using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ITsErrorCode2LocFormService))]
	public class TsErrorCode2LocFormService : TsErrorCode2LocService ,ITsErrorCode2LocFormService
	{

	}
}
