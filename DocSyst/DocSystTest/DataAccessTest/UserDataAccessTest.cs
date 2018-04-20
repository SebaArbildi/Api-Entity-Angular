using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
