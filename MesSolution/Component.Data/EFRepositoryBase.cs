using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Component.Tools;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;


namespace Component.Data
{
    /// <summary>
    ///     EntityFramework仓储操作基类
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public abstract class EFRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        #region 属性

        /// <summary>
        ///     获取 仓储上下文的实例
        /// </summary>
        [Import]
        public IUnitOfWork UnitOfWork { get; set; }

        public DbContext GetDbContext()
        {
            return this.UnitOfWork.GetContext();
        }

        /// <summary>
        ///     获取或设置 EntityFramework的数据仓储上下文
        /// </summary>
        protected IUnitOfWorkContext EFContext
        {
            get
            {
                if (UnitOfWork is IUnitOfWorkContext)
                {
                    return UnitOfWork as IUnitOfWorkContext;
                }
                throw new DataAccessException(string.Format("数据仓储上下文对象类型不正确，应为IRepositoryContext，实际为 {0}", UnitOfWork.GetType().Name));
               
            }
        }

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        public virtual IQueryable<TEntity> Entities
        {
            get { return EFContext.Set<TEntity>(); }
        }

       

      

        #endregion

        #region 公共方法

        /// <summary>
        /// 为指定的上下文实体返回 System.Data.Entity.Infrastructure.DbEntityEntry，这将允许对上下文中的给定实体执行 从数据库更新 操作。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual DbEntityEntry<TEntity> Entry(TEntity entity)
        {
            return EFContext.Entity<TEntity>(entity);
        }

        /// <summary>
        ///     插入实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Insert(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");           
            OperationResult operationResult = new OperationResult(OperationResultType.Success);           
            EFContext.RegisterNew(entity);
            int number = (isSave ? EFContext.Commit() : 0);
            operationResult.Message = "添加成功：" + number + "条数据";
            operationResult.AppendData = number;
            return operationResult;
        }

        /// <summary>
        ///     批量插入实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entities");
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            EFContext.RegisterNew(entities);
            int number = (isSave ? EFContext.Commit() : 0);
            operationResult.Message = "添加成功：" +number  + "条数据";
            operationResult.AppendData = number;
            return operationResult;
        }

        /// <summary>
        ///     删除指定编号的记录
        /// </summary>
        /// <param name="id"> 实体记录编号 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Delete(object id, bool isSave = true)
        {
            PublicHelper.CheckArgument(id, "id");
            OperationResult operationResult=new OperationResult(OperationResultType.Success,"删除成功");
            TEntity entity = (TEntity)GetByKey(id).AppendData;
            if (entity == null)
            {
                operationResult.ResultType = OperationResultType.Error;
                operationResult.Message = id + "不存在";
            }
            else
            {                
                return Delete(entity, isSave);
            }            
            return operationResult;
        }

        /// <summary>
        ///     删除实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Delete(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            EFContext.RegisterDeleted(entity);
            int number = (isSave ? EFContext.Commit() : 0);
            operationResult.Message = "删除成功：" + number + "条数据";
            operationResult.AppendData = number;
            return operationResult;
        }

        /// <summary>
        ///     删除实体记录集合
        /// </summary>
        /// <param name="entities"> 实体记录集合 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            PublicHelper.CheckArgument(entities, "entity");
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            EFContext.RegisterDeleted(entities);
            int number = isSave ? EFContext.Commit() : 0;
            operationResult.Message = "删除成功：" + number + "条数据";
            operationResult.AppendData = number;
            return operationResult;
        }

        /// <summary>
        ///     删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate"> 查询条件谓语表达式 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true)
        {
            PublicHelper.CheckArgument(predicate, "predicate");
            List<TEntity> entities = EFContext.Set<TEntity>().Where(predicate).ToList();
            return entities.Count > 0 ? Delete(entities, isSave) : new OperationResult(OperationResultType.Error,"没有符合条件的删除数据");
        }

        /// <summary>
        ///     更新实体记录
        /// </summary>
        /// <param name="entity"> 实体对象 </param>
        /// <param name="isSave"> 是否执行保存 </param>
        /// <returns> 操作影响的行数 </returns>
        public virtual OperationResult Update(TEntity entity, bool isSave = true)
        {
            PublicHelper.CheckArgument(entity, "entity");            
            OperationResult operationResult = new OperationResult(OperationResultType.Success);           
            EFContext.RegisterModified(entity);
            operationResult.Message = "修改成功：" + (isSave ? EFContext.Commit() : 0) + "条数据";
            operationResult.AppendData = entity;
            return operationResult;
        }

        /// <summary>
        ///     查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public virtual OperationResult GetByKey(object key)
        {
            PublicHelper.CheckArgument(key, "key");
            TEntity entity=EFContext.Set<TEntity>().Find(key);
            if (entity != null)
            {
                return new OperationResult(OperationResultType.Success, "查询成功。", entity);
            }
            else
                return new OperationResult(OperationResultType.Error, key+"不存在。", null);
             
        }

        #endregion
    }
}