using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IErrorComFormService))]
	public class TsErrorCause2ComFormService : TsErrorCause2ComService ,IErrorComFormService
	{

	}
}
