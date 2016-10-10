using System;

namespace DataObjects
{
    public class DeliveryObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 出库记录ID
        /// </summary>
        public int DeliveryId { get; private set; }

        /// <summary>
        /// 出库编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 领取物品
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 领取数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 对应库存
        /// </summary>
        public int InventoryId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public int OperatorId { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperatedTime { get; set; }

        /* Join */
        public string AreaIdName { get; set; }
        public string ItemIdName { get; set; }
        public string InventoryIdName { get; set; }
        public string OperatedTimeName { get; set; }
    }
}
