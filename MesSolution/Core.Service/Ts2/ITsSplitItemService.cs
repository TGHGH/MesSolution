using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsSplitItemService
	{
		 OperationResult AddEntity(TsSplitItem tsSplitItem,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsSplitItem tsSplitItem,bool isSave=true);
		 IQueryable<TsSplitItem>TsSplitItems( );
	}
}
