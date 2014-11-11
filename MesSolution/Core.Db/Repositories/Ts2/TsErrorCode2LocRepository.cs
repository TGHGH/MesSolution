using System;using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Component.Data;
using Core.Models;

namespace Core.Db.Repositories
{

	[Export(typeof(ITsErrorCode2LocRepository))]
	public class TsErrorCode2LocRepository : EFRepositoryBase<TsErrorCode2Loc>,ITsErrorCode2LocRepository
	{
	}
}
