using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ITsSplitItemFormService))]
	public class TsSplitItemFormService : TsSplitItemService ,ITsSplitItemFormService
	{

	}
}
