using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DataObjects;

namespace InventorySystem_UnitTest
{
    [TestFixture]
    public class CategoryTests:BaseTests<CategoryObject>
    {
        private const string _Type = "CategoryAccess";
        private ICategoryAccess _Dal;

        public CategoryTests():base(_Type)
        {
            _Dal = base.dal as IDataAccess.ICategoryAccess;

            if (_Dal == null)
            {
                throw new NullReferenceException(_Type);
            }
        }

        [Test]
        public void GetCategoryList_BadExtension_ReturnsNullList()
        {
            IList<CategoryObject> categoryList = _Dal.GetCategoryList();
            Assert.False(categoryList == null);
        }
    }
}
