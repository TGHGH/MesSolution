using System.ComponentModel.DataAnnotations;

namespace DbContexts.Model
{
    /// <summary>
    /// 会员信息类
    /// </summary>
    [ComplexType]
    public class PersonalInfo
    {
        public Measurement Weight { get; set; }
        public Measurement Height { get; set; }
        public string DietryRestrictions { get; set; }
    }
}
