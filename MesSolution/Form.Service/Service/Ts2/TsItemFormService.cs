using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ITsItemFormService))]
	public class TsItemFormService : TsItemService ,ITsItemFormService
	{

	}
}
