using Component.Tools;
using Core.Models;
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
    public class UserSiteContract:UserService,IUserSiteContract
    {             

    
    }
}
