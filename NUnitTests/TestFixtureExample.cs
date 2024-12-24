using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.NUnitTests
{
    [TestFixture, Description("This is a Sanity Test Suite"), Category("Sanity")]//, Ignore("Ignore this test")]
    internal class TestFixtureExample
    {
        [Test, Order(1)]     //Test is defined to let NUNIT consider it as Test case
        public void Registration()  //Function Name
        {
            Console.WriteLine("User Registration completed");
        }

        [Test, Order(2)]  //NUNIT will run the functions based on the order given
        public void login()
        {
            Console.WriteLine("User Login successful");
        }

        [Test, Order(3), Ignore("Defect#1234")]  //NUNIT will ignore/skip this function.
        public void products()
        {
            Console.WriteLine("User selects products");
        }

        [Test, Order(4)]
        public void addtocart()
        {
            Console.WriteLine("User adds products to cart");
        }

        [Test, Order(5)]
        public void payment()
        {
            Console.WriteLine("User created order");
        }
    }
}
