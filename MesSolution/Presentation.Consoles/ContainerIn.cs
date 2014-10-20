using Application.Site;
using Core.Db.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Consoles
{
  //  [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export]
    public class ContainerIn
    {
        [Import]
        public IAccountSiteContract AccountContract { get; set; }
        [Import]
        public IUserSiteContract UserContract { get; set; }
        
    }
}
