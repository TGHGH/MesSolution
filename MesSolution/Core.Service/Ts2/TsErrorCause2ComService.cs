using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsErrorCause2ComService : CoreServiceBase,IErrorComService
	{
		[Import]
		protected IErrorComRepository tsErrorCause2ComRepository { get; set; } 
		public IQueryable<ErrorCom> TsErrorCause2Coms()
		{
			return tsErrorCause2ComRepository.Entities;
		}
		public virtual OperationResult AddEntity(ErrorCom tsErrorCause2Com,bool isSave=true)
		{
			return tsErrorCause2ComRepository.Insert(tsErrorCause2Com,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsErrorCause2ComRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "tsErrorCause2Com");
			return tsErrorCause2ComRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(ErrorCom tsErrorCause2Com,bool isSave=true)
		{
			return tsErrorCause2ComRepository.Update(tsErrorCause2Com,isSave);
		}
	}
}
