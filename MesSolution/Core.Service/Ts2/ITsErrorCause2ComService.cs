using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface ITsErrorCause2ComService
	{
		 OperationResult AddEntity(TsErrorCause2Com tsErrorCause2Com,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(TsErrorCause2Com tsErrorCause2Com,bool isSave=true);
		 IQueryable<TsErrorCause2Com>TsErrorCause2Coms( );
	}
}
