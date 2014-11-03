using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IMdlService
	{
         OperationResult AddEntity(Mdl mdl, bool isSave = true);
         OperationResult DeleteEntity(string key, bool isSave = true);
		 OperationResult FindEntity(string key);
         OperationResult UpdateEntity(Mdl mdl, bool isSave = true);
		 IQueryable<Mdl>Mdls( );
	}
}
