using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ITsFormService))]
	public class TsFormService : TsService ,ITsFormService
	{

	}
}
