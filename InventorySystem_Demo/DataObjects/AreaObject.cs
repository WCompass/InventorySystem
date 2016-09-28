
namespace DataObjects
{
    public class AreaObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaId { get; private set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 区域等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 区域负责人
        /// </summary>
        public int Owner { get; set; }

        /*Join*/
        public string OwnerName { get; set; }
    }
}
