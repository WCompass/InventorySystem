using DataObjects;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IItemAccess : IBaseAccess<ItemObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<ItemObject> GetItemList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<ItemObject> GetItemList(int statusCode);

        /// <summary>
        /// 根据类目来获得物品列表
        /// </summary>
        /// <param name="category">类目</param>
        /// <returns></returns>
        IList<ItemObject> GetItemListByCategory(int category);

        /// <summary>
        /// 根据类目来获得对应状态的物品列表
        /// </summary>
        /// <param name="category">类目</param>
        /// <param name="category">状态码</param>
        /// <returns></returns>
        IList<ItemObject> GetItemListByCategory(int category,int statusCode);

        /// <summary>
        /// 获得数据总数
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 获得对应状态的数据总数
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        int GetCount(int statusCode);
    }
}
