using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class ResService : CoreServiceBase,IResService
	{
		[Import]
		protected IResRepository resRepository { get; set; } 
		public IQueryable<Res> Ress()
		{
			return resRepository.Entities;
		}
		public virtual OperationResult AddEntity(Res res,bool isSave=true)
		{
			return resRepository.Insert(res,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return resRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "res");
			return resRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Res res,bool isSave=true)
		{
			return resRepository.Update(res,isSave);
		}
	}
}
