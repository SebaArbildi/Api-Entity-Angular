
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystEntities.User;
using System.Collections.Generic;
using DocSystDataAccessImplementation.UserDataAccessImplementation;

namespace DocSystTest.DataAccessTest
{
    [TestClass]
    public class UserDataAccessTest
    {
        private IUserDataAccess userDataAccess;
        private User user;

        [TestCleanup]
        public void CleanDataBase()
        {
            Utils.DeleteBd();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            userDataAccess = new UserDataAccess();
            user = Utils.CreateUserForTest();
        }

        [TestMethod]
        public void CreateUserDataAccess_WithoutParameters_Ok()
        {
            IUserDataAccess userDA = new UserDataAccess();

            Assert.IsNotNull(userDA);
        }

        [TestMethod]
        public void AddUserToDb_ExpectedParameters_Ok()
        {
            userDataAccess.Add(user);

            User obtained = userDataAccess.Get(user.Username);
            Assert.AreEqual(user, obtained);
        }

        [TestMethod]
        public void DeleteUserFromDb_ExpectedParameters_Ok()
        {
            userDataAccess.Add(user);

            userDataAccess.Delete(user.Username);

            User obtained = userDataAccess.Get(user.Username);
            Assert.IsNull(obtained);
        }

        [TestMethod]
        public void ModifyUserFromDb_ExpectedParameters_Ok()
        {
            userDataAccess.Add(user);
            user.Name = "Pepito";

            userDataAccess.Modify(user);

            User obtained = userDataAccess.Get(user.Username);
            Assert.AreEqual(user, obtained);
        }

        [TestMethod]
        public void GetAllUsersFromDb_ExpectedParameters_Ok()
        {
            userDataAccess.Add(user);

            IList<User> users = userDataAccess.Get();

            Assert.IsTrue(users.Contains(user));
        }

        [TestMethod]
        public void ExistUserInDb_ExpectedParameters_Ok()
        {
            userDataAccess.Add(user);

            bool exists = userDataAccess.Exists(user.Username);

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void IntegrationTest_ExpectedParameters_Ok()
        {
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
