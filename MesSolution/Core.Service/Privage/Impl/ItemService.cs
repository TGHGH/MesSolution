using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class ItemService : CoreServiceBase,IItemService
	{
		[Import]
		protected IItemRepository itemRepository { get; set; } 
		public IQueryable<Item> Items()
		{
			return itemRepository.Entities;
		}
		public virtual OperationResult AddEntity(Item item,bool isSave=true)
		{
			return itemRepository.Insert(item,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return itemRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "item");
			return itemRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Item item,bool isSave=true)
		{
			return itemRepository.Update(item,isSave);
		}
	}
}
