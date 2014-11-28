using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ISolutionFormService))]
	public class SolutionFormService : SolutionService ,ISolutionFormService
	{

	}
}
