using System;

namespace DataObjects
{
    public class InventoryObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 库存ID
        /// </summary>
        public int InventoryId { get; private set; }

        /// <summary>
        /// 库存编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 所属区域
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /* Join */
        public string AreaIdName { get; set; }
        public string ItemIdName { get; set; }
    }
}
