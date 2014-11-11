using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsSplitItemService : CoreServiceBase,ITsSplitItemService
	{
		[Import]
		protected ITsSplitItemRepository tsSplitItemRepository { get; set; } 
		public IQueryable<TsSplitItem> TsSplitItems()
		{
			return tsSplitItemRepository.Entities;
		}
		public virtual OperationResult AddEntity(TsSplitItem tsSplitItem,bool isSave=true)
		{
			return tsSplitItemRepository.Insert(tsSplitItem,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsSplitItemRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsSplitItem");
			return tsSplitItemRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(TsSplitItem tsSplitItem,bool isSave=true)
		{
			return tsSplitItemRepository.Update(tsSplitItem,isSave);
		}
	}
}
