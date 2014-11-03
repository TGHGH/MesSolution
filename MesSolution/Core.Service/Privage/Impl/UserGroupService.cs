using System.ComponentModel.Composition;
using Component.Tools;
using System.Linq;
using Core.Db.Repositories;
using Core.Models;
namespace Core.Service
{

	public abstract class UserGroupService : CoreServiceBase,IUserGroupService
	{
		[Import]
		protected IUserGroupRepository userGroupRepository { get; set; } 
		public IQueryable<UserGroup> UserGroups()
		{
			return userGroupRepository.Entities;
		}
		public virtual OperationResult AddEntity(UserGroup userGroup,bool isSave=true)
		{
			return userGroupRepository.Insert(userGroup,isSave);
		}
		public virtual OperationResult DeleteEntity(string key,bool isSave=true)
		{
			return userGroupRepository.Delete(key,isSave);
		}
		public virtual OperationResult FindEntity(string key)
		{
			PublicHelper.CheckArgument(key, "userGroup");
			return userGroupRepository.GetByKey(key);
		}
		public virtual OperationResult UpdateEntity(UserGroup userGroup,bool isSave=true)
		{
			return userGroupRepository.Update(userGroup,isSave);
		}
	}
}
