using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using DocSystEntities.User;

namespace DocSystTest.DataAccessTest
{
    [TestClass]
    public class UserDataAccessTest
    {
        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

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

            User obtained = userDataAccess.Get(user.Username);
            Assert.AreEqual(user, obtained);
        }
    }
}
