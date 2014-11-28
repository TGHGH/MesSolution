using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(IDutyFormService))]
	public class DutyFormService : DutyService ,IDutyFormService
	{

	}
}
