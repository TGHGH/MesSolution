
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;

using Component.Data;


namespace Core.Db.Context
{
    /// <summary>
    ///     Demo项目单元操作类
    /// </summary>
    [Export(typeof (IUnitOfWork))]
    public class RepositoryContext : UnitOfWorkContextBase
    {
        /// <summary>
        ///     获取或设置 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get { return MContext; }
            
        }

        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>
        [Import(typeof(DbContext))]
        public MesContext MContext { get; set; } 
    }
}