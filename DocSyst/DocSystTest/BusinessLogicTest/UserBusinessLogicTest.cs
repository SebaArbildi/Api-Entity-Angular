using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.BusinessLogicTest
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        [TestMethod]
        public void CreateUserBL_WithoutParameters_Ok()
        {
            IUserBusinessLogic userBusinessLogic = new UserBusinessLogicTest();

            Assert.IsNotNull(userBusinessLogic);
        }

        [TestMethod]
        public void CreateUserBL_WithParameters_Ok()
        {
            IUserDataAccess userDataAccess = new IUserDataAccess();

            IUserBusinessLogic userBusinessLogic = new UserBusinessLogicTest(userDataAccess);

            Assert.IsNotNull(userBusinessLogic);
        }
    }
}
