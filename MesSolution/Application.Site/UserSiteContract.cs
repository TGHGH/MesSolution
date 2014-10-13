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
            
    }
}
