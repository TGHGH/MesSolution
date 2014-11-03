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
		public virtual OperationResult AddEntity(Mdl mdl,bool isSave=true)
		{
            return mdlRepository.Insert(mdl, isSave);
		}
        public virtual OperationResult DeleteEntity(string key, bool isSave = true)
		{
            return mdlRepository.Delete(key, isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "mdl");
			return mdlRepository.GetByKey(key);
		}
        public virtual OperationResult UpdateEntity(Mdl mdl, bool isSave = true)
		{
            return mdlRepository.Update(mdl, isSave);
		}
	}
}
