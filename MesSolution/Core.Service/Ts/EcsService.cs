using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class EcsService : CoreServiceBase,IEcsService
	{
		[Import]
		protected IEcsRepository ecsRepository { get; set; } 
		public IQueryable<ErrorCodeSeason> Ecss()
		{
			return ecsRepository.Entities;
		}
		public virtual OperationResult AddEntity(ErrorCodeSeason ecs,bool isSave=true)
		{
			return ecsRepository.Insert(ecs,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return ecsRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "ecs");
			return ecsRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(ErrorCodeSeason ecs,bool isSave=true)
		{
			return ecsRepository.Update(ecs,isSave);
		}
	}
}
