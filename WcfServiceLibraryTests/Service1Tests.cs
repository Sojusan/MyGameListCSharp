using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary.Tests
{
    [TestClass()]
    public class Service1Tests
    {
        Service1 service = new Service1();
        [TestMethod()]
        public void GetGameTest()
        {
            Assert.AreEqual("Gothic", service.GetGameById(13).Title);
        }

        [TestMethod()]
        public void GetGameExceptionTest()
        {
            Assert.ThrowsException<ArgumentException>(() => service.GetGameById(-10));
        }
        [TestMethod()]
        public void GetGameAverageScore()
        {
            double doubleType = 0.0;
            Assert.AreSame(doubleType.GetType(), service.GetAccountAverageScore(7).GetType());
        }
        [TestMethod()]
        public void GetNullFromAccount()
        {
            Assert.IsNull(service.GetAccount("abc"));
        }
    }
}