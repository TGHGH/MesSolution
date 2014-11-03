using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IResService
	{
		 OperationResult AddEntity(Res res,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Res res,bool isSave=true);
		 IQueryable<Res>Ress( );
	}
}
