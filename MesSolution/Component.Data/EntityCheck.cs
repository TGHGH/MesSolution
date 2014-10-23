/*************************************************************************************
    * CLR版本：       4.0.30319.18444
    * 类 名 称：       CoreHelp
    * 机器名称：       PC201405051109
    * 命名空间：       Core.Models
    * 文 件 名：       CoreHelp
    * 创建时间：       2014/10/22 21:39:56
    * 作    者：          梁 贵
    * 说   明：。。。。。
    * 修改时间：		
    * 修 改 人：		
   *************************************************************************************/

using Component.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Data
{
    public static class EntityCheck
    {
        /// <summary>
        /// 验证单个实体
        /// </summary>
        /// <typeparam name="T">实体类名</typeparam>
        /// <param name="DbContext">上下文</param>
        /// <param name="entity">实例</param>
        /// <returns></returns>
        public static OperationResult CheckEntity<T>(DbContext DbContext, T entity) where T : Entity
        {            
            DbEntityValidationResult dbEntityValidationResult = DbContext.Entry<T>(entity).GetValidationResult();
            
            if (dbEntityValidationResult.IsValid)
            {
                return new OperationResult(OperationResultType.Success, "验证成功", entity);
            }
            else
                return new OperationResult(OperationResultType.Error, "验证失败:" + ConsoleValidationResults(dbEntityValidationResult), entity);            
        }

       /// <summary>
       /// 通用打印验证错误信息方法
       /// </summary>
       /// <param name="result"></param>
       /// <returns></returns>
        private static string ConsoleValidationResults(DbEntityValidationResult result) 
        {           
            string a="";
            foreach (DbValidationError error in result.ValidationErrors)
            {
               a=a+"\r\n"+error.ErrorMessage;
            }
            return a;
        }
    }
}
