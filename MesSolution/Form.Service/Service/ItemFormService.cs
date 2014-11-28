using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IItemFormService))]
	public class ItemFormService : ItemService ,IItemFormService
	{

	}
}
