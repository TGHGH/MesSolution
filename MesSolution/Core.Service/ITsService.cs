using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsService
	{
		 OperationResult AddEntity(Ts ts,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Ts ts,bool isSave=true);
		 IQueryable<Ts>Tss( );
	}
}
