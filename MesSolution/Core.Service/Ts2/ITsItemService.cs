using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsItemService
	{
		 OperationResult AddEntity(TsItem tsItem,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsItem tsItem,bool isSave=true);
		 IQueryable<TsItem>TsItems( );
	}
}
