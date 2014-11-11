using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ISimulationFormService))]
	public class SimulationFormService : SimulationService ,ISimulationFormService
	{

	}
}
