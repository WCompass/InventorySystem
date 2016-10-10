using DataObjects;
using System;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IDeviceAccess : IBaseAccess<DeviceObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceList(int statusCode);

        /// <summary>
        /// 根据区域来获得设备列表
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceListByArea(int areaId);

        /// <summary>
        /// 获取排序创建时间
        /// </summary>
        /// <param name="createdTime"></param>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceListByTime(DateTime createdTime);

        /// <summary>
        /// 获取创建人Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceListByUser(int userId);

        /// <summary>
        /// 获取设备状态
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceListByStatusCode(int statusCode);

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
