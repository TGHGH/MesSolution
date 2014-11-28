using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IOpFormService))]
	public class OpFormService : OpService ,IOpFormService
	{

	}
}
