using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class EcService : CoreServiceBase,IEcService
	{
		[Import]
		protected IEcRepository ecRepository { get; set; } 
		public IQueryable<Ec> Ecs()
		{
			return ecRepository.Entities;
		}
		public virtual OperationResult AddEntity(Ec ec,bool isSave=true)
		{
			return ecRepository.Insert(ec,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return ecRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "ec");
			return ecRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Ec ec,bool isSave=true)
		{
			return ecRepository.Update(ec,isSave);
		}
	}
}
