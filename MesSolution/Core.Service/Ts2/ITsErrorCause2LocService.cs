using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsErrorCause2LocService
	{
		 OperationResult AddEntity(TsErrorCause2Loc tsErrorCause2Loc,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsErrorCause2Loc tsErrorCause2Loc,bool isSave=true);
		 IQueryable<TsErrorCause2Loc>TsErrorCause2Locs( );
	}
}
