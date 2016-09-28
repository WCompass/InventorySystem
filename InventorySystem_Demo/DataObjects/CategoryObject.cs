
namespace DataObjects
{
    public class CategoryObject:BaseDataObject
    {
        /*Field*/
        /// <summary>
        /// 类目ID
        /// </summary>
        public int CategoryId { get; private set; }

        /// <summary>
        /// 类目编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 类目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类目等级
        /// </summary>
        public int Level { get; set; }
    }
}
