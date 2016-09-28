
namespace DataObjects
{
    public class ItemObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 物品ID
        /// </summary>
        public int ItemId { get; private set; }

        /// <summary>
        /// 物品编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物品类目
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 物品价格
        /// </summary>
        public float Price { get; set; }

        /* Join */
        public string CategoryIdName { get; set; }
    }
}
