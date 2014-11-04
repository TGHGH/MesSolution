using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ISimulationReportService
	{
		 OperationResult AddEntity(SimulationReport simulationReport,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(SimulationReport simulationReport,bool isSave=true);
		 IQueryable<SimulationReport>SimulationReports( );
	}
}
