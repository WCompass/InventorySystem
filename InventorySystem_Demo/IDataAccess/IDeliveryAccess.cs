using DataObjects;
using System;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IDeliveryAccess : IBaseAccess<DeliveryObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<DeliveryObject> GetDeliveryList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<DeliveryObject> GetDeliveryList(int statusCode);

        /// <summary>
        /// 根据指定时间范围获得的列表
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        IList<DeliveryObject> GetDeliveryListByTimeRange(DateTime startTime, DateTime endTime);

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
