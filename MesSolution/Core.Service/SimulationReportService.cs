using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class SimulationReportService : CoreServiceBase,ISimulationReportService
	{
		[Import]
		protected ISimulationReportRepository simulationReportRepository { get; set; } 
		public IQueryable<SimulationReport> SimulationReports()
		{
			return simulationReportRepository.Entities;
		}
		public virtual OperationResult AddEntity(SimulationReport simulationReport,bool isSave=true)
		{
			return simulationReportRepository.Insert(simulationReport,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return simulationReportRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "simulationReport");
			return simulationReportRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(SimulationReport simulationReport,bool isSave=true)
		{
			return simulationReportRepository.Update(simulationReport,isSave);
		}
	}
}
