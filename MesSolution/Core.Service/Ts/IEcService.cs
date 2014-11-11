using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IEcService
	{
		 OperationResult AddEntity(Ec ec,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Ec ec,bool isSave=true);
		 IQueryable<Ec>Ecs( );
	}
}
