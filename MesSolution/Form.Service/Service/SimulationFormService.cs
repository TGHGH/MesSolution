using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace Frm.Service
{

	[Export(typeof(ISimulationFormService))]
	public class SimulationFormService : SimulationService ,ISimulationFormService
	{

	}
}
