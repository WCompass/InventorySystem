using DataObjects;
using System.Collections.Generic;

namespace IDataAccess
{
    public interface IRoleAccess : IBaseAccess<RoleObject>
    {
        /// <summary>
        /// 获得列表
        /// </summary>
        /// <returns></returns>
        IList<RoleObject> GetRoleList();
    }
}
