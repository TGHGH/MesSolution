using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IItemService
	{
		 OperationResult AddEntity(Item item,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Item item,bool isSave=true);
		 IQueryable<Item>Items( );
	}
}
