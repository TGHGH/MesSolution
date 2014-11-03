using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IOpFormService))]
	public class OpFormService : OpService ,IOpFormService
	{

	}
}
