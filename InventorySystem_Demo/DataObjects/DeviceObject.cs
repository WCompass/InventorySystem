
namespace DataObjects
{
    public class DeviceObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 设备ID
        /// </summary>
        public int DeviceId { get; private set; }

        /// <summary>
        /// 设备IMEI
        /// </summary>
        public string IMEI { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public int AreaId { get; set; }
        /* Join */
        public string AreaIdName { get; set; }
    }
}
