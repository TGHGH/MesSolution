using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IEcsgFormService))]
	public class EcsgFormService : EcsgService ,IEcsgFormService
	{

	}
}
