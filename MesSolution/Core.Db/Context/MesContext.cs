using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

using Core.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;


namespace Core.Db.Context
{
    /// <summary>
    ///     Demo项目数据访问上下文
    /// </summary>
    
    [Export(typeof(DbContext))]
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

       
        //Craft
        public DbSet<ItemRoute2Op> ItemRoute2Ops { get; set; }
        public DbSet<ItemRouteOp2Ecsg> ItemRouteOp2Ecsgs { get; set; }
        public DbSet<Op> Ops { get; set; }
        public DbSet<OpBom> OpBoms { get; set; }
        public DbSet<OpBomDetail> OpBomDetails { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Sbom> Sboms { get; set; }
        public DbSet<Route2Op> Route2Ops { get; set; }
        

        //ItemAndMaterial
        public DbSet<Item> Items { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Item2Ckdinfo> Item2Ckdinfos { get; set; }

        //Location
        public DbSet<Org> Orgs { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Seg> Segs { get; set; }
        public DbSet<Ss> Sses { get; set; }
        public DbSet<Res> Reses { get; set; }

        //Manufacture
        public DbSet<Down> Downs { get; set; }
        public DbSet<Item2SnCheck> Item2SnChecks { get; set; }
        public DbSet<Mo> Moes { get; set; }
        public DbSet<Mo2Sap> Mo2Sap { get; set; }
       // public DbSet<Mo2SapDetail> Mo2SapDetail { get; set; }
        public DbSet<MoBom> MoBoms { get; set; }
        public DbSet<MoBomLog> MoBomLogs { get; set; }
        public DbSet<MoRcard> MoRcards { get; set; }
        public DbSet<OffMoCard> OffMoCards { get; set; }
        public DbSet<RcardChange> RcardChanges { get; set; }
        public DbSet<WorkingError> WorkingErrors { get; set; }

        //Privage
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Mdl> Mdls { get; set; }

        //Processing
        public DbSet<Simulation> simulations { get; set; }
        public DbSet<SimulationReport> simulationreports { get; set; }


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Craft           
            modelBuilder.Entity<ItemRouteOp2Ecsg>().HasKey(t => new { t.OPID, t.ECSGCODE });
            modelBuilder.Entity<Sbom>().HasKey(t => new { t.ITEMCODE, t.SBITEMCODE, t.SBOMVER, t.SBITEMPROJECT, t.SBITEMSEQ, t.ORGID });
            modelBuilder.Entity<OpBom>().HasKey(t => new { t.ITEMCODE, t.OBCODE, t.OPBOMVER, t.ORGID });
            modelBuilder.Entity<OpBomDetail>().HasKey(t => new { t.OBITEMCODE, t.ITEMCODE, t.OBCODE, t.OPBOMVER, t.OPID, t.ACTIONTYPE, t.ORGID });

            //Manufacture           
            // modelBuilder.Entity<MoRcard>().HasKey(t => new { t.MOCODE, t.SEQ });
            modelBuilder.Entity<MoBom>().HasKey(t => new { t.MOCODE, t.ITEMCODE, t.MOBITEMCODE, t.SEQ });
            modelBuilder.Entity<Item2SnCheck>().HasKey(t => new { t.ITEMCODE, t.TYPE });
            modelBuilder.Entity<WorkingError>().HasKey(t => new { t.RESCODE, t.CUSER, t.CDATE, t.CTIME });
            modelBuilder.Entity<Mo2Sap>().HasKey(t => new { t.MOCODE, t.POSTSEQ });


         //   modelBuilder.Entity<Simulation>().HasKey(t => new { t.RCARD, t.MOCODE });
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

        }
        //标识
        public bool LogChangesDuringSave { get; set; }

        /// <summary>
        /// 记录帮助类
        /// </summary>
        private void PrintPropertyValues(DbPropertyValues values, IEnumerable<string> propertiesToPrint, int indent = 1)
        {
            foreach (var propertyName in propertiesToPrint)
            {
                var value = values[propertyName];
                if (value is DbPropertyValues)
                {
                    Console.WriteLine("{0}- Complex Property: {1}", string.Empty.PadLeft(indent), propertyName);
                    var complexPropertyValues = (DbPropertyValues)value;
                    PrintPropertyValues(complexPropertyValues, complexPropertyValues.PropertyNames, indent + 1);
                }
                else
                {
                    Console.WriteLine("{0}- {1}: {2}", string.Empty.PadLeft(indent), propertyName, values[propertyName]);
                }
            }
        }
        public override int SaveChanges()
        {
            this.LogChangesDuringSave = false;
            if (LogChangesDuringSave)  //根据表示判断用重写的SaveChanges方法，还是普通的上下文SaveChanges方法
            {
                var entries = from e in this.ChangeTracker.Entries()
                              where e.State != EntityState.Unchanged
                              select e;   //过滤所有修改了的实体，包括：增加 / 修改 / 删除
                Console.WriteLine("entries.Count:" + entries.Count());                
                foreach (var entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            Console.WriteLine("Adding a {0}", entry.Entity.GetType());
                            PrintPropertyValues(entry.CurrentValues, entry.CurrentValues.PropertyNames);
                            break;
                        case EntityState.Deleted:
                            Console.WriteLine("Deleting a {0}", entry.Entity.GetType());
                            PrintPropertyValues(entry.OriginalValues, GetKeyPropertyNames(entry.Entity));
                            break;
                        case EntityState.Modified:
                            Console.WriteLine("Modifying a {0}", entry.Entity.GetType());
                            var modifiedPropertyNames = from n in entry.CurrentValues.PropertyNames
                                                        where entry.Property(n).IsModified
                                                        select n;
                            PrintPropertyValues(entry.CurrentValues, GetKeyPropertyNames(entry.Entity).Concat(modifiedPropertyNames));
                            break;
                    }
                }                
            }
            return base.SaveChanges();  //返回普通的上下文SaveChanges方法
            //try
            //{
            //    return base.SaveChanges();  //返回普通的上下文SaveChanges方法
            //}
            //catch (DbEntityValidationException e)
            //{
            //    DisplayErrors(e.EntityValidationErrors);
            //}
            //return 0;
        }
        private IEnumerable<string> GetKeyPropertyNames(object entity)
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            return objectContext.ObjectStateManager.GetObjectStateEntry(entity).EntityKey.EntityKeyValues.Select(k => k.Key);
        }

        private static void DisplayErrors(IEnumerable<DbEntityValidationResult> results)
        {
            int counter = 0;
            foreach (DbEntityValidationResult result in results)
            {
                counter++;
                Console.WriteLine("Failed Object #{0}: Type is {1}", counter, result.Entry.Entity.GetType().Name);
                Console.WriteLine(" Number of Problems: {0}", result.ValidationErrors.Count);
                foreach (DbValidationError error in result.ValidationErrors)
                {
                    Console.WriteLine(" - {0}", error.ErrorMessage);
                }
            }
        }
    }
}