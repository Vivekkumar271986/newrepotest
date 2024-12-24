using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.DataDrivenTesting
{
    internal class TestParameterusingTestcase //passing value to individual test cases
    {
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest(int n, int d, int q)
        {
            Assert.That(n / d, Is.EqualTo(q));
        }

        [TestCase(12, 3,36)]
        [TestCase(12, 2, 24)]
        [TestCase(12, 4,48)]
        public void MultiplyTest(int n, int d, int q)
        {
            Assert.That(n * d, Is.EqualTo(q));
        }
    }
}
