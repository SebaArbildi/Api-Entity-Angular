using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;

namespace DocSystTest.DataAccessTest
{
    [TestClass]
    public class UserDataAccessTest
    {
        
        [TestMethod]
        public void CreateUserDataAccess_WithoutParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();

            Assert.IsNotNull(userDataAccess);
        }
    }
}
