using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Bankapplication;
using MongoDB.Driver;
using System.Linq;
using Moq;

namespace Test
{
    [TestClass]
    public class BankServicesTest
    {
        [TestMethod]
        public void TestFunctions()
        {
            var bank = new BankAccount("Newb", 20, new List<string>());
            var service = new BankServices();

            Assert.ThrowsException<System.ArgumentException>(() => service.CreateBankAccount(bank.FullName));
        }
    }
}
