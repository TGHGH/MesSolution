using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

using Core.Models;


namespace Core.Db.Context
{
    /// <summary>
    ///     Demo项目数据访问上下文
    /// </summary>
    [Export(typeof (DbContext))]
    public class MesContext : DbContext
    {
        #region 构造函数

        /// <summary>
        ///     初始化一个 使用连接名称为“default”的数据访问上下文类 的新实例
        /// </summary>
        public MesContext()
            : base("MesSolution") { }

        /// <summary>
        /// 初始化一个 使用指定数据连接名称或连接串 的数据访问上下文类 的新实例
        /// </summary>
        public MesContext(string nameOrConnectionString)
            : base(nameOrConnectionString) {  }

        #endregion

        #region 属性

        public DbSet<Role> Roles { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<MemberExtend> MemberExtends { get; set; }

        public DbSet<LoginLog> LoginLogs { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}