using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsErrorCodeService : CoreServiceBase,ITsErrorCodeService
	{
		[Import]
		protected ITsErrorCodeRepository tsErrorCodeRepository { get; set; } 
		public IQueryable<TsErrorCode> TsErrorCodes()
		{
			return tsErrorCodeRepository.Entities;
		}
		public virtual OperationResult AddEntity(TsErrorCode tsErrorCode,bool isSave=true)
		{
			return tsErrorCodeRepository.Insert(tsErrorCode,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsErrorCodeRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsErrorCode");
			return tsErrorCodeRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(TsErrorCode tsErrorCode,bool isSave=true)
		{
			return tsErrorCodeRepository.Update(tsErrorCode,isSave);
		}
	}
}
