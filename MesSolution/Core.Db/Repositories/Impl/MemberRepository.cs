
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

using Component.Data;
using Core.Models;


namespace Core.Db.Repositories
{
    /// <summary>
    ///     仓储操作实现——用户信息
    /// </summary>
    [Export(typeof(IMemberRepository))]
    public class MemberRepository : EFRepositoryBase<Member>, IMemberRepository { }
}