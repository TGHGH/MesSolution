using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IEcsFormService))]
	public class EcsFormService : EcsService ,IEcsFormService
	{

	}
}
