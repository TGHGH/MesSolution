using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IOpService
	{
		 OperationResult AddEntity(Op op,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Op op,bool isSave=true);
		 IQueryable<Op>Ops( );
	}
}
