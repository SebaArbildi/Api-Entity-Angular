using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using DocSystEntities.User;
using System.Collections.Generic;

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

        [TestMethod]
        public void DeleteUserFromDb_ExpectedParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            User user = Utils.CreateUserForTest();
            userDataAccess.Add(user);

            userDataAccess.Delete(user.Username);

            User obtained = userDataAccess.Get(user.Username);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyUserFromDb_ExpectedParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            User user = Utils.CreateUserForTest();
            userDataAccess.Add(user);
            user.Name = "Pepito";

            userDataAccess.Modify(user);

            User obtained = userDataAccess.Get(user.Username);
            Assert.AreEqual(user, obtained);
        }

        [TestMethod]
        public void GetAllUsersFromDb_ExpectedParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            User user = Utils.CreateUserForTest();
            userDataAccess.Add(user);

            IList<User> users = userDataAccess.Get();

            Assert.IsTrue(users.Contains(user));
        }

        [TestMethod]
        public void ExistUserInDb_ExpectedParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            User user = Utils.CreateUserForTest();
            userDataAccess.Add(user);

            bool exists = userDataAccess.Exists(user.Username);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            User user1 = Utils.CreateUserForTest();
            User user2 = Utils.CreateUserForTest();
            User user3 = Utils.CreateUserForTest();
            userDataAccess.Add(user1);
            userDataAccess.Add(user2);
            userDataAccess.Add(user3);

            user1.Name = "Pepito";
            userDataAccess.Modify(user1);
            Assert.AreEqual(user1, userDataAccess.Get(user1.Username));

            userDataAccess.Delete(user2.Username);
            IList<User> users = userDataAccess.Get();

            Assert.IsFalse(users.Contains(user2));
            Assert.IsFalse(userDataAccess.Exists(user2.Username));
            Assert.IsTrue(users.Contains(user1));
            Assert.IsTrue(userDataAccess.Exists(user1.Username));
        }
    }
}
