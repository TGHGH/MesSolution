using System.ComponentModel.DataAnnotations;

namespace DbContexts.Model
{
    /// <summary>
    /// 度假村类
    /// </summary>
    public class Resort : Lodging
    {
        public string Entertainment { get; set; }
        public string Activities { get; set; }
    }
}
