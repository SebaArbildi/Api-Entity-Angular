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
        private User user;

        [TestInitialize]
        public void CreateUserBusinessLogicForTest()
        {
            mockUserDataAccess = new Mock<IUserDataAccess>();
            userBusinessLogic = new UserBusinessLogic(mockUserDataAccess.Object);
            user = Utils.CreateUserForTest();
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
            userBusinessLogic.AddUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddUser_UserHasNullFields_ArgumentNullException()
        {
            user.Name = null;

            userBusinessLogic.AddUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddUser_UserAlreadyExists_DuplicateException()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(true);

            userBusinessLogic.AddUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddUser_DataAccessThrowException_ExceptionCatched()
        {
            mockUserDataAccess.Setup(b1 => b1.Add(user)).Throws(new Exception());

            userBusinessLogic.AddUser(user);
        }

        [TestMethod]
        public void DeleteUser_ExpectedParameters_Ok()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(true);

            userBusinessLogic.DeleteUser(user.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUser_UserHasNullFields_ArgumentNullException()
        {
            user.Username = null;

            userBusinessLogic.DeleteUser(user.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteUser_UserNotExists_DuplicateException()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(false);

            userBusinessLogic.DeleteUser(user.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeleteUser_DataAccessThrowException_ExceptionCatched()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(true);
            mockUserDataAccess.Setup(b1 => b1.Delete(user.Username)).Throws(new Exception());

            userBusinessLogic.DeleteUser(user.Username);
        }

        [TestMethod]
        public void ModifyUser_ExpectedParameters_Ok()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(true);

            userBusinessLogic.ModifyUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModifyUser_UserHasNullFields_ArgumentNullException()
        {
            user.Name = null;

            userBusinessLogic.ModifyUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyUser_UserNotExists_DuplicateException()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(false);

            userBusinessLogic.ModifyUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ModifyUser_DataAccessThrowException_ExceptionCatched()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(true);
            mockUserDataAccess.Setup(b1 => b1.Modify(user)).Throws(new Exception());

            userBusinessLogic.ModifyUser(user);
        }

        [TestMethod]
        public void GetUsers_ExpectedParameters_Ok()
        {
            userBusinessLogic.GetUsers();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetUsers_DataAccessThrowException_ExceptionCatched()
        {
            mockUserDataAccess.Setup(b1 => b1.Get()).Throws(new Exception());

            userBusinessLogic.GetUsers(user);
        }

        [TestMethod]
        public void GetUser_ExpectedParameters_Ok()
        {
            userBusinessLogic.GetUser(user.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUser_UserHasNullFields_ArgumentNullException()
        {
            userBusinessLogic.GetUser(user.Username);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void GetUser_UserNotExists_DuplicateException()
        {
            mockUserDataAccess.Setup(b1 => b1.Exists(user.Username)).Returns(false);

            userBusinessLogic.GetUser(user);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetUser_DataAccessThrowException_ExceptionCatched()
        {
            mockUserDataAccess.Setup(b1 => b1.Get(user.Username)).Throws(new Exception());

            userBusinessLogic.GetUser(user);
        }
    }
}
