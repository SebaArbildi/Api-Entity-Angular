using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using System;
using DocSystEntities.User;
using Moq;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        private Mock<IUserDataAccess> mockUserDataAccess;
        private IUserBusinessLogic userBusinessLogic;

        [TestInitialize]
        public void CreateUserBusinessLogicForTest()
        {
            mockUserDataAccess = new Mock<IUserDataAccess>();
            userBusinessLogic = new UserBusinessLogic(mockUserDataAccess.Object);
        }

        [TestMethod]
        public void CreateUserBL_WithoutParameters_Ok()
        {
            IUserBusinessLogic userBL = new UserBusinessLogic();

            Assert.IsNotNull(userBL);
        }

        [TestMethod]
        public void CreateUserBL_WithParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();

            IUserBusinessLogic userBL = new UserBusinessLogic(userDataAccess);

            Assert.IsNotNull(userBL);
        }

        [TestMethod]
        public void AddUser_ExpectedParameters_Ok()
        {
            User newUser = Utils.CreateUserForTest();

            mockUserDataAccess.Setup(b1 => b1.Add(newUser));

            userBusinessLogic.AddUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddUser_UserHasNullFields_ArgumentNullException()
        {
            User newUser = Utils.CreateUserForTest();
            newUser.Name = null;

            userBusinessLogic.AddUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddUser_UserAlreadyExists_DuplicateException()
        {
            User newUser = Utils.CreateUserForTest();

            mockUserDataAccess.Setup(b1 => b1.Exists(newUser.Username)).Returns(true);

            userBusinessLogic.AddUser(newUser);
        }

        [TestMethod]
        public void DeleteUser_ExpectedParameters_Ok()
        {
            User newUser = Utils.CreateUserForTest();

            mockUserDataAccess.Setup(b1 => b1.Add(newUser));

            userBusinessLogic.DeleteUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUser_UserHasNullFields_ArgumentNullException()
        {
            User newUser = Utils.CreateUserForTest();
            newUser.Name = null;

            userBusinessLogic.DeleteUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void DeleteUser_UserAlreadyExists_DuplicateException()
        {
            User newUser = Utils.CreateUserForTest();

            mockUserDataAccess.Setup(b1 => b1.Exists(newUser.Username)).Returns(true);

            userBusinessLogic.DeleteUser(newUser);
        }

        [TestMethod]
        public void ModifyUser_ExpectedParameters_Ok()
        {
            User newUser = Utils.CreateUserForTest();

            mockUserDataAccess.Setup(b1 => b1.Add(newUser));

            userBusinessLogic.ModifyUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyUser_UserHasNullFields_ArgumentNullException()
        {
            User newUser = Utils.CreateUserForTest();
            newUser.Name = null;

            userBusinessLogic.ModifyUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void ModifyUser_UserAlreadyExists_DuplicateException()
        {
            User newUser = Utils.CreateUserForTest();

            mockUserDataAccess.Setup(b1 => b1.Exists(newUser.Username)).Returns(true);

            userBusinessLogic.ModifyUser(newUser);
        }
    }
}
