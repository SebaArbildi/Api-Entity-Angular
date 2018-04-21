using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystBusinessLogicInterface.UserBusinessLogicInterface;
using DocSystBusinessLogicImplementation.UserBusinessLogicImplementation;
using DocSystDataAccessInterface.UserDataAccessInterface;
using DocSystDataAccess.UserDataAccessImplementation;
using System;
using DocSystEntities.User;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        private IUserBusinessLogic CreateUserBusinessLogicForTest()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            return new UserBusinessLogic(userDataAccess);
        }

        [TestMethod]
        public void CreateUserBL_WithoutParameters_Ok()
        {
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic();

            Assert.IsNotNull(userBusinessLogic);
        }

        [TestMethod]
        public void CreateUserBL_WithParameters_Ok()
        {
            IUserDataAccess userDataAccess = new UserDataAccess();

            IUserBusinessLogic userBusinessLogic = new UserBusinessLogic(userDataAccess);

            Assert.IsNotNull(userBusinessLogic);
        }

        [TestMethod]
        public void AddUser_ExpectedParameters_Ok()
        {
            IUserBusinessLogic userBusinessLogic = CreateUserBusinessLogicForTest();
            User newUser = Utils.CreateUserForTest();

            userBusinessLogic.AddUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddUser_UserHasNullFields_ArgumentNullException()
        {
            IUserBusinessLogic userBusinessLogic = CreateUserBusinessLogicForTest();
            User newUser = Utils.CreateUserForTest();
            newUser.Name = null;

            userBusinessLogic.AddUser(newUser);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateWaitObjectException))]
        public void AddUser_UserAlreadyExists_DuplicateException()
        {
            IUserBusinessLogic userBusinessLogic = CreateUserBusinessLogicForTest();
            User newUser = Utils.CreateUserForTest();
            newUser.Name = null;

            userBusinessLogic.AddUser(newUser);
        }
    }
}
