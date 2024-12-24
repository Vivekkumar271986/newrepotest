using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEGdecbatch.NunitTests
{
    [TestFixture(2, 3)]//passing value to entire class or all test case present in this suite or under this class
    [TestFixture(4, 8)]
    [TestFixture(6, 7)]
    internal class ParametarizedTestFixture
    {
        private readonly int _a;
        private readonly int _b;

        public ParametarizedTestFixture(int a, int b)
        {
            _a = a;
            _b = b;
        }

        [Test]
        public void Testsum()
        {
            Assert.AreEqual(_a + _b, _a * 1 + _b * 1);

            //  Assert.That(actual, Is.EqualTo(expected))
        }

        [Test]
        public void Testsub()
        {
            Assert.AreEqual(_a - _b, _a * 1 - _b * 1);
        }


        [Test]
        public void Testpmul()
        {
            Assert.AreEqual(_a * _b, _a * _b);
        }

    }
}