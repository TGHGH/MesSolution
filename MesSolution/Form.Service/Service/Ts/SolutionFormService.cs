using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ISolutionFormService))]
	public class SolutionFormService : SolutionService ,ISolutionFormService
	{

	}
}
