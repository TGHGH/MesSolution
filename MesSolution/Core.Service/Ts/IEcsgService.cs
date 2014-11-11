using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IEcsgService
	{
		 OperationResult AddEntity(ErrorCodeSeasonGroup ecsg,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(ErrorCodeSeasonGroup ecsg,bool isSave=true);
		 IQueryable<ErrorCodeSeasonGroup>Ecsgs( );
	}
}
