using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IModelService
	{
		 OperationResult AddEntity(Model model,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Model model,bool isSave=true);
		 IQueryable<Model>Models( );
	}
}
