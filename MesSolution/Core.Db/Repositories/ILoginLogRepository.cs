using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Component.Data;
using Core.Models;


namespace Core.Db.Repositories
{
    /// <summary>
    ///     仓储操作接口——登录记录信息
    /// </summary>
    public interface ILoginLogRepository : IRepository<LoginLog> { }
}