using DataObjects;
using System;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IStorageAccess : IBaseAccess<StorageObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<StorageObject> GetStorageList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageList(int statusCode);

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

        /// <summary>
        /// 获得时间范围
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByTimeRange(DateTime startTime, DateTime endTime);

        /// <summary>
        /// 获得区域Id
        /// </summary>
        /// <param name="AreaId">区域Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByArea(int AreaId);

        /// <summary>
        /// 获得类目Id
        /// </summary>
        /// <param name="CategoryId">类目Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByCategory(int CategoryId);

        /// <summary>
        /// 获得库存数量
        /// </summary>
        /// <param name="Count">库存数量</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByCount(int Count);

        /// <summary>
        /// 获得物品Id
        /// </summary>
        /// <param name="ItemId">物品Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByItem(int ItemId);

        /// <summary>
        /// 获得操作人Id
        /// </summary>
        /// <param name="UserId">操作人Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByOperatorId(int UserId);
    }
}
