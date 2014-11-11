using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class EcgService : CoreServiceBase,IEcgService
	{
		[Import]
		protected IEcgRepository ecgRepository { get; set; } 
		public IQueryable<ErrorCodeGroup> Ecgs()
		{
			return ecgRepository.Entities;
		}
		public virtual OperationResult AddEntity(ErrorCodeGroup ecg,bool isSave=true)
		{
			return ecgRepository.Insert(ecg,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return ecgRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "ecg");
			return ecgRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(ErrorCodeGroup ecg,bool isSave=true)
		{
			return ecgRepository.Update(ecg,isSave);
		}
	}
}
