using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ITsSplitItemFormService))]
	public class TsSplitItemFormService : TsSplitItemService ,ITsSplitItemFormService
	{

	}
}
