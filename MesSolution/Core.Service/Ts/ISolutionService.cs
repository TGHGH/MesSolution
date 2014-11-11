using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ISolutionService
	{
		 OperationResult AddEntity(Solution solution,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Solution solution,bool isSave=true);
		 IQueryable<Solution>Solutions( );
	}
}
