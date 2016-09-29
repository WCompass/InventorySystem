using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;



namespace InventorySystem_UnitTest
{
    public class BaseTests<T> where T : BaseDataObject, new()
    {
        protected IDataAccess.IBaseAccess<T> dal;
        public BaseTests(string type)
        {
            dal = FactoryDataAccess.DataAccess<IDataAccess.IBaseAccess<T>>.CreateDAL(type);
        }
    }
}
