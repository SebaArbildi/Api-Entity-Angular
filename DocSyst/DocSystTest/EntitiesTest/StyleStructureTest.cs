using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocSystEntities.StyleStructure;

namespace DocSystTest.EntitiesTest.StyleStructure
{
    [TestClass]
    public class StyleStructureTest
    {
        [TestMethod]
        public void CreateSpecificStyle_WithoutParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle();
        }

        [TestMethod]
        public void CreateSpecificStyle_WithParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
        }

        [TestMethod]
        public void CreateStyle_WithoutParameters_Ok()
        {
            Style style = new Style();
        }

        [TestMethod]
        public void CreateStyle_WithParameters_Ok()
        {
            SpecificStyle specificStyle = new SpecificStyle("name", "<html><body>{0}</body></html>");
            Style style = new Style("name", specificStyle);
        }

    }
}
