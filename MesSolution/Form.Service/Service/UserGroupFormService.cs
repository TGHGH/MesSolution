//using Component.Tools;
//using Core.Models;
using Core.Service;
using System;
//using System.Collections.Generic;
using System.ComponentModel.Composition;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Frm.Service
{
    [Export(typeof(IUserGroupFormService))]
    public class UserGroupFormService:UserGroupService,IUserGroupFormService
    {             

    
    }
}
