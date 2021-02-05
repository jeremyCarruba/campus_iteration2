using iteration2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace iteration2test
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void TestOnline()
        {
            MainController cont = new MainController(MainController.Statuses.ONLINE);
            BusResourceTest bs = new BusResourceTest();

            Assert.IsInstanceOfType(bs.TransformResponse(), typeof(List<Buses>));
        }
    }
}
