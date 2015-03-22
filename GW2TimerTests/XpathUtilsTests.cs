using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GW2TimerScraper;

namespace GW2TimerTests
{
    [TestClass]
    public class XpathUtilsTests
    {
        [TestMethod]
        public void XpathSelectByMultipleClassesTest()
        {
            // we expect the following result:
            // /div[contains(@class,'atag') and contains(@class ,'btag')]

            string[] classes = new[] { "atag", "btag" };
            string result = XpathUtils.XpathSelectByMultipleClasses("/div", classes);

            Assert.AreEqual("/div[contains(@class,'atag') and contains(@class ,'btag')]", result);
        }
    }
}
