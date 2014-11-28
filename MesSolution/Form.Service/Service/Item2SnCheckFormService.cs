using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IItem2SnCheckFormService))]
	public class Item2SnCheckFormService : Item2SnCheckService ,IItem2SnCheckFormService
	{

	}
}
