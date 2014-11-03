using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class RouteService : CoreServiceBase,IRouteService
	{
		[Import]
		protected IRouteRepository routeRepository { get; set; } 
		public IQueryable<Route> Routes()
		{
			return routeRepository.Entities;
		}
		public virtual OperationResult AddEntity(Route route,bool isSave=true)
		{
			return routeRepository.Insert(route,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return routeRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "route");
			return routeRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Route route,bool isSave=true)
		{
			return routeRepository.Update(route,isSave);
		}
	}
}
