using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsErrorCauseService
	{
		 OperationResult AddEntity(TsErrorCause tsErrorCause,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsErrorCause tsErrorCause,bool isSave=true);
		 IQueryable<TsErrorCause>TsErrorCauses( );
	}
}
