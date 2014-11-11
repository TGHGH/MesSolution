using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(IDutyFormService))]
	public class DutyFormService : DutyService ,IDutyFormService
	{

	}
}
