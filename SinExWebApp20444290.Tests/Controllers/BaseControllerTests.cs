using NUnit.Framework;
using SinExWebApp20444290.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinExWebApp20444290.Controllers.Tests
{
    [TestFixture()]
    public class BaseControllerTests
    {
        [Test()]
        public void convertUselessTestCNY()
        {
            BaseController test = new BaseController();
            decimal amount = test.convertUseless("CNY", 100);
            Assert.That(amount, Is.EqualTo(100.00));
        }
        [Test()]
        public void convertUselessTestHKD()
        {
            BaseController test = new BaseController();
            decimal amount = test.convertUseless("HKD", 100);
            Assert.That(amount, Is.EqualTo(113.00));
        }
        [Test()]
        public void convertUselessTestMOP()
        {
            BaseController test = new BaseController();
            decimal amount = test.convertUseless("MOP", 100);
            Assert.That(amount, Is.EqualTo(116.00));
        }
        [Test()]
        public void convertUselessTestTWD()
        {
            BaseController test = new BaseController();
            decimal amount = test.convertUseless("TWD", 100);
            Assert.That(amount, Is.EqualTo(456.00));
        }
    }
}