using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IItemFormService))]
	public class ItemFormService : ItemService ,IItemFormService
	{

	}
}
