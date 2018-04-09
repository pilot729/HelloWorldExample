using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Business;
using HelloWorld.Data;
using StructureMap;

namespace HelloWorld.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Configuration.WireUpBusinessObjects();
        }

        [TestMethod]
        public void TestMethod_BBL()
        {
            var bll = ObjectFactory.GetInstance<IHelloWorldRepository>();
            var greeting = bll.Get(1);

            Assert.AreEqual("Hello World", greeting);
        }

        [TestMethod]
        public void TestMethod_DAL()
        {
            var dal = ObjectFactory.GetInstance<IDataLayer>();
            var greeting = dal.Get(1);

            Assert.AreEqual("Hello World", greeting);
        }
    }
}