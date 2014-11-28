using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ITsErrorCause2LocFormService))]
	public class TsErrorCause2LocFormService : TsErrorCause2LocService ,ITsErrorCause2LocFormService
	{

	}
}
