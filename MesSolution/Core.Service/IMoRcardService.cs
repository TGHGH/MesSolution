using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IMoRcardService
	{
		 OperationResult AddEntity(MoRcard moRcard,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(MoRcard moRcard,bool isSave=true);
		 IQueryable<MoRcard>MoRcards( );
	}
}
