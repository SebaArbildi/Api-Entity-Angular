using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using DocSystEntities.User;

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

        [TestMethod]
        public void AddUserToDb_ExpectedParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            User user = Utils.CreateUserForTest();

            userDataAccess.Add(user);

            User obtained = userDataAccess.Get(user.UserName);
            Assert.AreEqual(user, obtained);
        }
    }
}
