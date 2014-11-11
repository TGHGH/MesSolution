using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class SolutionService : CoreServiceBase,ISolutionService
	{
		[Import]
		protected ISolutionRepository solutionRepository { get; set; } 
		public IQueryable<Solution> Solutions()
		{
			return solutionRepository.Entities;
		}
		public virtual OperationResult AddEntity(Solution solution,bool isSave=true)
		{
			return solutionRepository.Insert(solution,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return solutionRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "solution");
			return solutionRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Solution solution,bool isSave=true)
		{
			return solutionRepository.Update(solution,isSave);
		}
	}
}
