using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IEcsgService
	{
		 OperationResult AddEntity(Ecsg ecsg,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Ecsg ecsg,bool isSave=true);
		 IQueryable<Ecsg>Ecsgs( );
	}
}
