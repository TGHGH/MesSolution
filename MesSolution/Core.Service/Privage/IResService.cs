using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IResService
	{
		 OperationResult AddEntity(Res res);
		 OperationResult DeleteEntity(string key);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Res res);
		 IQueryable<Res> Ress( );
	}
}
