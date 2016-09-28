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
        /// 获得列表创建时间
        /// </summary>
        /// <param name="CreatedTime"></param>
        /// <returns></returns>
        IList<DeviceObject> GetDeviceListCreatedTime(DateTime CreatedTime);//何蕴.名字

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
