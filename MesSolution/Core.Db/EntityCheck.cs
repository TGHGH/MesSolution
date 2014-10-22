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

namespace Core.Help
{
    public static class EntityCheck
    {
        public static DbEntityValidationResult CheckEntity<T>(DbContext DbContext, T entity) where T : Entity
        {
            DbEntityValidationResult result;
            result = DbContext.Entry<T>(entity).GetValidationResult();
            return result;
        }
    }
}
