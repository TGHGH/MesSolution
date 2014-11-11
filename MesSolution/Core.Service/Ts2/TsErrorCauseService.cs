using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsErrorCauseService : CoreServiceBase,ITsErrorCauseService
	{
		[Import]
		protected ITsErrorCauseRepository tsErrorCauseRepository { get; set; } 
		public IQueryable<TsErrorCause> TsErrorCauses()
		{
			return tsErrorCauseRepository.Entities;
		}
		public virtual OperationResult AddEntity(TsErrorCause tsErrorCause,bool isSave=true)
		{
			return tsErrorCauseRepository.Insert(tsErrorCause,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsErrorCauseRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsErrorCause");
			return tsErrorCauseRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(TsErrorCause tsErrorCause,bool isSave=true)
		{
			return tsErrorCauseRepository.Update(tsErrorCause,isSave);
		}
	}
}
