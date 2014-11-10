using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class TsService : CoreServiceBase,ITsService
	{
		[Import]
		protected ITsRepository tsRepository { get; set; } 
		public IQueryable<Ts> Tss()
		{
			return tsRepository.Entities;
		}
		public virtual OperationResult AddEntity(Ts ts,bool isSave=true)
		{
			return tsRepository.Insert(ts,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return tsRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "ts");
			return tsRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Ts ts,bool isSave=true)
		{
			return tsRepository.Update(ts,isSave);
		}
	}
}
