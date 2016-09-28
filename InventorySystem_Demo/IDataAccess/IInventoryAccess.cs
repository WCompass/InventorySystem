using DataObjects;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IInventoryAccess : IBaseAccess<InventoryObject>
    {

        /// <summary>
        /// 获得警告库存列表
        /// </summary>
        /// <returns></returns>
        IList<InventoryObject> GetWarningInventoryList();

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<InventoryObject> GetInventoryList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<InventoryObject> GetInventoryList(int statusCode);

        /// <summary>
        /// 根据类目来获得物品列表
        /// </summary>
        /// <param name="category">类目</param>
        /// <returns></returns>
        IList<ItemObject> GetInventoryListByArea(int area);

        /// <summary>
        /// 根据类目来获得对应状态的物品列表
        /// </summary>
        /// <param name="category">类目</param>
        /// <param name="category">状态码</param>
        /// <returns></returns>
        IList<ItemObject> GetInventoryListByArea(int area, int statusCode);

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
