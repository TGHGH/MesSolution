using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class Item2SnCheckService : CoreServiceBase,IItem2SnCheckService
	{
		[Import]
		protected IItem2SnCheckRepository item2SnCheckRepository { get; set; } 
		public IQueryable<Item2SnCheck> Item2SnChecks()
		{
			return item2SnCheckRepository.Entities;
		}
		public virtual OperationResult AddEntity(Item2SnCheck item2SnCheck,bool isSave=true)
		{
			return item2SnCheckRepository.Insert(item2SnCheck,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return item2SnCheckRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "item2SnCheck");
			return item2SnCheckRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Item2SnCheck item2SnCheck,bool isSave=true)
		{
			return item2SnCheckRepository.Update(item2SnCheck,isSave);
		}
	}
}
