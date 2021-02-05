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

            Assert.IsInstanceOfType(cont.BusResource.GetBusesNearClassroom(500), typeof(List<Buses>));
        }
    }
}
