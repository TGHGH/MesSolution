using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class SimulationService : CoreServiceBase,ISimulationService
	{
		[Import]
		protected ISimulationRepository simulationRepository { get; set; } 
		public IQueryable<Simulation> Simulations()
		{
			return simulationRepository.Entities;
		}
		public virtual OperationResult AddEntity(Simulation simulation,bool isSave=true)
		{
			return simulationRepository.Insert(simulation,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return simulationRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "simulation");
			return simulationRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Simulation simulation,bool isSave=true)
		{
			return simulationRepository.Update(simulation,isSave);
		}
	}
}
