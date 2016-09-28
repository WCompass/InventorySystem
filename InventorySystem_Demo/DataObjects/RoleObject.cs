
namespace DataObjects
{
    public class RoleObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 权限ID
        /// </summary>
        public int RoleId { get; private set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

    }
}
