using Component.Tools;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IUserService
    {
        OperationResult AddUser(User user);
        OperationResult DeleteUser(User user);
        OperationResult QueryUser(string key);
        OperationResult UpdateUser(string usercode,string pwd);

        OperationResult UpdateUser2(string usercode, string pwd);
       
    }
}
