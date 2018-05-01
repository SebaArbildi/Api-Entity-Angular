using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocSystTest.EntitiesTest.StyleStructure
{
    [TestClass]
    public class SpecificStyleTest
    {
        [TestMethod]
        public void CreateSpecificStyle_WithoutParameters_Ok()
        {
            SpecificStyleTest specificStyle = new SpecificStyleTest();
        }

        [TestMethod]
        public void CreateSpecificStyle_WithParameters_Ok()
        {
            SpecificStyleTest specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
        }
    }
}
