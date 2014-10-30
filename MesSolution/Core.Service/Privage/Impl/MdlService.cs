using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class MdlService : CoreServiceBase,IMdlService
	{
		[Import]
		protected IMdlRepository mdlRepository { get; set; } 
		public IQueryable<Mdl> Mdls()
		{
			return mdlRepository.Entities;
		}
		public virtual OperationResult AddEntity(Mdl mdl)
		{
			return mdlRepository.Insert(mdl,true);
		}
		public virtual OperationResult DeleteEntity(string key)
		{
			return mdlRepository.Delete(key,true);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "mdl");
			return mdlRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Mdl mdl)
		{
			return mdlRepository.Update(mdl,true);
		}
	}
}
