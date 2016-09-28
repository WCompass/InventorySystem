using DataObjects;
using IDataAccess;
using NUnit.Framework;
using System.Collections.Generic;

namespace InventorySystem_UnitTest
{
    [TestFixture]
    public class UserAccessTests : BaseTests<UserObject>
    {
        IUserAccess _Dal;
        public UserAccessTests() : base("User")
        {
            _Dal = base.dal as IUserAccess;
        }
        [Test]
        public void GetUserList_Good()
        {
            IList<UserObject> userList = _Dal.GetUserList();

            Assert.False(userList == null);
        }
    }
}
