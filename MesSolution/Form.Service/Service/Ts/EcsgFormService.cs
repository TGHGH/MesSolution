using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IEcsgFormService))]
	public class EcsgFormService : EcsgService ,IEcsgFormService
	{

	}
}
