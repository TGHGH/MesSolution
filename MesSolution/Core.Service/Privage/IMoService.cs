using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IMoService
	{
		 OperationResult AddEntity(Mo mo,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Mo mo,bool isSave=true);
		 IQueryable<Mo>Mos( );
	}
}
