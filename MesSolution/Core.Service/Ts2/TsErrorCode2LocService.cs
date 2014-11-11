using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsErrorCode2LocService : CoreServiceBase,ITsErrorCode2LocService
	{
		[Import]
		protected ITsErrorCode2LocRepository tsErrorCode2LocRepository { get; set; } 
		public IQueryable<TsErrorCode2Loc> TsErrorCode2Locs()
		{
			return tsErrorCode2LocRepository.Entities;
		}
		public virtual OperationResult AddEntity(TsErrorCode2Loc tsErrorCode2Loc,bool isSave=true)
		{
			return tsErrorCode2LocRepository.Insert(tsErrorCode2Loc,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsErrorCode2LocRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsErrorCode2Loc");
			return tsErrorCode2LocRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(TsErrorCode2Loc tsErrorCode2Loc,bool isSave=true)
		{
			return tsErrorCode2LocRepository.Update(tsErrorCode2Loc,isSave);
		}
	}
}
