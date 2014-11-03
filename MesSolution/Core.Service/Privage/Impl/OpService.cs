using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class OpService : CoreServiceBase,IOpService
	{
		[Import]
		protected IOpRepository opRepository { get; set; } 
		public IQueryable<Op> Ops()
		{
			return opRepository.Entities;
		}
		public virtual OperationResult AddEntity(Op op,bool isSave=true)
		{
			return opRepository.Insert(op,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return opRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "op");
			return opRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Op op,bool isSave=true)
		{
			return opRepository.Update(op,isSave);
		}
	}
}
