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
2
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
        /// 根据区域Id获得列表
        /// </summary>
        /// <param name="AreaId">区域Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByArea(int areaId);

        /// <summary>
        /// 获得类目Id
        /// </summary>
        /// <param name="CategoryId">类目Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByCategory(int categoryId);


        /// <summary>
        /// 获得物品Id
        /// </summary>
        /// <param name="ItemId">物品Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByItem(int itemId);

        /// <summary>
        /// 获得操作人Id
        /// </summary>
        /// <param name="UserId">操作人Id</param>
        /// <returns></returns>
        IList<StorageObject> GetStorageListByOperatorId(int userId);
    }
}
