using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsErrorCause2LocService : CoreServiceBase,ITsErrorCause2LocService
	{
		[Import]
		protected ITsErrorCause2LocRepository tsErrorCause2LocRepository { get; set; } 
		public IQueryable<TsErrorCause2Loc> TsErrorCause2Locs()
		{
			return tsErrorCause2LocRepository.Entities;
		}
		public virtual OperationResult AddEntity(TsErrorCause2Loc tsErrorCause2Loc,bool isSave=true)
		{
			return tsErrorCause2LocRepository.Insert(tsErrorCause2Loc,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsErrorCause2LocRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsErrorCause2Loc");
			return tsErrorCause2LocRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(TsErrorCause2Loc tsErrorCause2Loc,bool isSave=true)
		{
			return tsErrorCause2LocRepository.Update(tsErrorCause2Loc,isSave);
		}
	}
}
