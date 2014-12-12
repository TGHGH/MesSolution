using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Component.Tools
{
    /// <summary>
    ///     可持久到数据库的领域模型的基类。
    /// </summary>
    [Serializable]
    public abstract class Entity
    {
        #region 构造函数

        /// <summary>
        ///     数据实体基类
        /// </summary>
        protected Entity()
        {
            IsDeleted = false;
            AddDate = DateTime.Now;
        }

        #endregion

        #region 属性

        /// <summary>
        ///     获取或设置 获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        ///     获取或设置 添加时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddDate { get; set; }

        /// <summary>
        ///     获取或设置 版本控制标识，用于处理并发
        /// </summary>
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }

        public T Merge<T>(T entity1,T entity2) where T:Entity
        {
            Type t = entity2.GetType();
            foreach (PropertyInfo pi in t.GetProperties())
            {
                if (!(pi.GetValue(entity1).Equals(pi.GetValue(entity2)) && pi.GetValue(entity2)!=null))
                {
                    pi.SetValue(entity1, pi.GetValue(entity2));
                }
            }
            return entity1;
        }
        #endregion
    }
}