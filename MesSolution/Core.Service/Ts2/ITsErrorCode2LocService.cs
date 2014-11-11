using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsErrorCode2LocService
	{
		 OperationResult AddEntity(TsErrorCode2Loc tsErrorCode2Loc,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsErrorCode2Loc tsErrorCode2Loc,bool isSave=true);
		 IQueryable<TsErrorCode2Loc>TsErrorCode2Locs( );
	}
}
