
namespace DataObjects
{
    public class UserObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
            
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaId { get; set; }

        /* Join */
        public string RoleIdName { get; set; }
        public string AreaIdName { get; set; }
    }
}
