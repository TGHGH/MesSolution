using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsItemService : CoreServiceBase,ITsItemService
	{
		[Import]
		protected ITsItemRepository tsItemRepository { get; set; } 
		public IQueryable<TsItem> TsItems()
		{
			return tsItemRepository.Entities;
		}
		public virtual OperationResult AddEntity(TsItem tsItem,bool isSave=true)
		{
			return tsItemRepository.Insert(tsItem,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsItemRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsItem");
			return tsItemRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(TsItem tsItem,bool isSave=true)
		{
			return tsItemRepository.Update(tsItem,isSave);
		}
	}
}
