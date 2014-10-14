using Component.Tools;
using Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Site
{
    [Export(typeof(IUserSiteContract))]
    internal class UserSiteContract:UserService,IUserSiteContract
    {

        OperationResult IUserService.AddUser(Core.Models.User user)
        {
            throw new NotImplementedException();
        }

        OperationResult IUserService.DeleteUser(Core.Models.User user)
        {
            throw new NotImplementedException();
        }

        OperationResult IUserService.QueryUser(string key)
        {
            throw new NotImplementedException();
        }

        OperationResult IUserService.UpdateUser(Core.Models.User user,string pwd)
        {
            base.QueryUser("65128044");
            return null;
        }
    }
}
