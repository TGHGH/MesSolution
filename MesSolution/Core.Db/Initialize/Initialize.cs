using Component.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Db.Initialize
{
    public static class Initialize<T> where T:Entity,new ()
    {
        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="infinum">初始化个数</param>
        /// <returns>返回实体list</returns>
        public static List<T> Infial(int infinum)
        {
            List<T> list = new List<T>();
            for (int i = 1; i < infinum; i++)
            {
                T entity = new T();
                Type t = entity.GetType();
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    object value1 = pi.PropertyType.Name;
                    if (value1.Equals("String"))
                    {
                        pi.SetValue(entity, pi.Name.ToLower() + i, null);
                    }
                    if (value1.Equals("DateTime"))
                    {
                        pi.SetValue(entity, DateTime.Now, null);
                    }
                    if (value1.Equals("Boolean"))
                    {
                        pi.SetValue(entity, false, null);
                    }                    
                    
                }

                list.Add(entity);
            }
            return list;
        }
    }
}
