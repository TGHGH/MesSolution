using System;using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Component.Data;
using Core.Models;

namespace Core.Db.Repositories
{

	[Export(typeof(IRoute2OpRepository))]
	public class Route2OpRepository : EFRepositoryBase<Route2Op>,IRoute2OpRepository
	{
	}
}
