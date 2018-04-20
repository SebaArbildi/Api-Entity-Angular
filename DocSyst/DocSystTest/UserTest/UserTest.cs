using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.UserTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CreateUser_WithoutParameters_Ok()
        {
            User user = new User();

            Assert.IsNotNull(user);
        }
    }
}
