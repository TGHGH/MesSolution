using System;
using Component.Tools;
using System.Linq;
using System.Text;
using Core.Models;

namespace Core.Service
{

	public interface IUserGroupService
	{
		 OperationResult AddEntity(UserGroup userGroup,bool isSave=true);
		 OperationResult DeleteEntity(string key,bool isSave=true);
		 OperationResult FindEntity(string key);
		 OperationResult UpdateEntity(UserGroup userGroup,bool isSave=true);
		 IQueryable<UserGroup>UserGroups( );
	}
}
