using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ITsItemFormService))]
	public class TsItemFormService : TsItemService ,ITsItemFormService
	{

	}
}
