using Core.Service;
using System;
using System.ComponentModel.Composition;

namespace FormApplication.Service
{

	[Export(typeof(ISimulationReportFormService))]
	public class SimulationReportFormService : SimulationReportService ,ISimulationReportFormService
	{

	}
}
