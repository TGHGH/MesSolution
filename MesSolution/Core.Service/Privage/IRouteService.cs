using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IRouteService
	{
		 OperationResult AddEntity(Route route,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Route route,bool isSave=true);
		 IQueryable<Route>Routes( );
	}
}
