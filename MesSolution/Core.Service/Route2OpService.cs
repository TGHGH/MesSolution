using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class Route2OpService : CoreServiceBase,IRoute2OpService
	{
		[Import]
		protected IRoute2OpRepository route2OpRepository { get; set; } 
		public IQueryable<Route2Op> Route2Ops()
		{
			return route2OpRepository.Entities;
		}
		public virtual OperationResult AddEntity(Route2Op route2Op,bool isSave=true)
		{
			return route2OpRepository.Insert(route2Op,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return route2OpRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "route2Op");
			return route2OpRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Route2Op route2Op,bool isSave=true)
		{
			return route2OpRepository.Update(route2Op,isSave);
		}
	}
}
