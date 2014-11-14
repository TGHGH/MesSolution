using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class ModelService : CoreServiceBase,IModelService
	{
		[Import]
		protected IModelRepository modelRepository { get; set; } 
		public IQueryable<Model> Models()
		{
			return modelRepository.Entities;
		}
		public virtual OperationResult AddEntity(Model model,bool isSave=true)
		{
			return modelRepository.Insert(model,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return modelRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "model");
			return modelRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(Model model,bool isSave=true)
		{
			return modelRepository.Update(model,isSave);
		}
	}
}
