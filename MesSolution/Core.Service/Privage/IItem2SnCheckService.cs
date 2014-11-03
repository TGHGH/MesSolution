using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IItem2SnCheckService
	{
		 OperationResult AddEntity(Item2SnCheck item2SnCheck,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Item2SnCheck item2SnCheck,bool isSave=true);
		 IQueryable<Item2SnCheck>Item2SnChecks( );
	}
}
