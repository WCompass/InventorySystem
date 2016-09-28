using DataObjects;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface ICategoryAccess : IBaseAccess<CategoryObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<CategoryObject> GetCategoryList();

        /// <summary>
        /// 获得对应状态的列表
        /// </summary>
        /// <param name="statusCode">状态码</param>
        /// <returns></returns>
        IList<CategoryObject> GetCategoryList(int statusCode);

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
