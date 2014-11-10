using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ITsFormService))]
	public class TsFormService : TsService ,ITsFormService
	{

	}
}
