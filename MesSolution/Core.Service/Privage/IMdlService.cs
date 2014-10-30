using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IMdlService
	{
		 OperationResult AddEntity(Mdl mdl);
		 OperationResult DeleteEntity(string key);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Mdl mdl);
		 IQueryable<Mdl>Mdls( );
	}
}
