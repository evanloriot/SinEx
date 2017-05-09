using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinExWebApp20444290.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinExWebApp20444290.Controllers.Tests
{
    [TestClass()]
    public class PackagesControllerTests
    {
        [TestMethod()]
        public void PackageFeeTestEnveloppe1()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(1, 1);
            Assert.IsTrue(amount.Equals(160));
        }
        [TestMethod()]
        public void PackageFeeTestEnveloppe2()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(10, 1);
            Assert.IsTrue(amount.Equals(160));
        }

        [TestMethod()]
        public void PackageFeeTestPak1kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(1, 2);
            Assert.IsTrue(amount.Equals(160));
        }
        [TestMethod()]
        public void PackageFeeTestPak2kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(2, 2);
            Assert.IsTrue(amount.Equals(200));
        }
        [TestMethod()]
        public void PackageFeeTestPak7kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(7, 2);
            Assert.IsTrue(amount.Equals(1200));
        }
        [TestMethod()]
        public void PackageFeeTestBox1kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(1, 4);
            Assert.IsTrue(amount.Equals(160));
        }
        [TestMethod()]
        public void PackageFeeTestBox2kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(2, 4);
            Assert.IsTrue(amount.Equals(220));
        }
        [TestMethod()]
        public void PackageFeeTestBox15kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(15, 4);
            Assert.IsTrue(amount.Equals(2150));
        }
        [TestMethod()]
        public void PackageFeeTestTube1kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(1, 3);
            Assert.IsTrue(amount.Equals(160));
        }
        [TestMethod()]
        public void PackageFeeTestTube2kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(2, 3);
            Assert.IsTrue(amount.Equals(200));
        }
        [TestMethod()]
        public void PackageFeeTestCustomer1kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(1, 5);
            Assert.IsTrue(amount.Equals(160));
        }
        [TestMethod()]
        public void PackageFeeTestCustomer2kg()
        {
            PackagesController test = new PackagesController();
            decimal amount = test.PackageFeePublic(2, 5);
            Assert.IsTrue(amount.Equals(220));
        }
    }
}