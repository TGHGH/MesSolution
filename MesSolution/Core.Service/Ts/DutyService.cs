using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class DutyService : CoreServiceBase,IDutyService
	{
		[Import]
		protected IDutyRepository dutyRepository { get; set; } 
		public IQueryable<Duty> Dutys()
		{
			return dutyRepository.Entities;
		}
		public virtual OperationResult AddEntity(Duty duty,bool isSave=true)
		{
			return dutyRepository.Insert(duty,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return dutyRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "duty");
			return dutyRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Duty duty,bool isSave=true)
		{
			return dutyRepository.Update(duty,isSave);
		}
	}
}
