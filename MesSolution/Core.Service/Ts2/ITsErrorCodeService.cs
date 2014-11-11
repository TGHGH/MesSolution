using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsErrorCodeService
	{
		 OperationResult AddEntity(TsErrorCode tsErrorCode,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsErrorCode tsErrorCode,bool isSave=true);
		 IQueryable<TsErrorCode>TsErrorCodes( );
	}
}
