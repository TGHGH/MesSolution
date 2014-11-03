using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class MoService : CoreServiceBase,IMoService
	{
		[Import]
		protected IMoRepository moRepository { get; set; } 
		public IQueryable<Mo> Mos()
		{
			return moRepository.Entities;
		}
		public virtual OperationResult AddEntity(Mo mo,bool isSave=true)
		{
			return moRepository.Insert(mo,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return moRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "mo");
			return moRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Mo mo,bool isSave=true)
		{
			return moRepository.Update(mo,isSave);
		}
	}
}
