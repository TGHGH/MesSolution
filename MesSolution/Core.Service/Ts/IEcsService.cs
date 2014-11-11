using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IEcsService
	{
		 OperationResult AddEntity(Ecs ecs,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Ecs ecs,bool isSave=true);
		 IQueryable<Ecs>Ecss( );
	}
}
