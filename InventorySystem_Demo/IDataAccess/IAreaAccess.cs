﻿using DataObjects;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IAreaAccess : IBaseAccess<AreaObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<AreaObject> GetAreaList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<AreaObject> GetAreaList(int statusCode);

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
