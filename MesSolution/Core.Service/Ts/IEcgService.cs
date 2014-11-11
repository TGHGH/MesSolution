using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IEcgService
	{
		 OperationResult AddEntity(Ecg ecg,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(Ecg ecg,bool isSave=true);
		 IQueryable<Ecg>Ecgs( );
	}
}
