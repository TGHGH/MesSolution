using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IDutyService
	{
		 OperationResult AddEntity(Duty duty,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Duty duty,bool isSave=true);
		 IQueryable<Duty>Dutys( );
	}
}
