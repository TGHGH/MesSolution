using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class EcsgService : CoreServiceBase,IEcsgService
	{
		[Import]
		protected IEcsgRepository ecsgRepository { get; set; } 
		public IQueryable<ErrorCodeSeasonGroup> Ecsgs()
		{
			return ecsgRepository.Entities;
		}
		public virtual OperationResult AddEntity(ErrorCodeSeasonGroup ecsg,bool isSave=true)
		{
			return ecsgRepository.Insert(ecsg,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return ecsgRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "ecsg");
			return ecsgRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(ErrorCodeSeasonGroup ecsg,bool isSave=true)
		{
			return ecsgRepository.Update(ecsg,isSave);
		}
	}
}
