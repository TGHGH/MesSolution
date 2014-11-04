using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class MoRcardService : CoreServiceBase,IMoRcardService
	{
		[Import]
		protected IMoRcardRepository moRcardRepository { get; set; } 
		public IQueryable<MoRcard> MoRcards()
		{
			return moRcardRepository.Entities;
		}
		public virtual OperationResult AddEntity(MoRcard moRcard,bool isSave=true)
		{
			return moRcardRepository.Insert(moRcard,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return moRcardRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "moRcard");
			return moRcardRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(MoRcard moRcard,bool isSave=true)
		{
			return moRcardRepository.Update(moRcard,isSave);
		}
	}
}
