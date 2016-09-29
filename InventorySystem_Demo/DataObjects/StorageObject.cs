using System;

namespace DataObjects
{
    public class StorageObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 入库记录ID
        /// </summary>
        public int StorageId { get; private set; }

        /// <summary>
        /// 入库编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 入库物品
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 入库数量
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
        public string ItemIdName { get; set; }
        public string AreaIdName { get; set; }
        public string OperatorIdName { get; set; }
    }
}
