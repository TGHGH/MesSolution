using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IEcsService
	{
		 OperationResult AddEntity(ErrorCodeSeason ecs,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(ErrorCodeSeason ecs,bool isSave=true);
		 IQueryable<ErrorCodeSeason>Ecss( );
	}
}
