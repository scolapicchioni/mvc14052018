using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SimoController ctr = new SimoController();
            ViewResult res = ctr.SayHiWithView();
            Assert.AreEqual("thename", res.ViewName);
        }

        [TestMethod]
        public void TestMethod2()
        {
            PeopleController ctr = new PeopleController();
            ActionResult res = ctr.GetPerson(100);

            //Assert.AreEqual("thename", res.ViewName);
        }
    }
}
