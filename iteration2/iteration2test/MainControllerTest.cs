using iteration2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace iteration2test
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void TestOnline()
        {
            MainController cont = new MainController(MainController.Statuses.ONLINE);
            string target = cont.GetCloseBuses(new JsonResponseTest());

            Assert.IsTrue((target).Contains("Test Response"));
        }
    }
}
