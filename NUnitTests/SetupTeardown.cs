using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.NUnitTests
{
    internal class SetupTeardown  //class level
    {
        [SetUp]    //before start of test
        public void launchbrowser() //method level
        {
            Console.WriteLine("Launching Browser");
        }

        [SetUp]
        public void dbconnection() //method level
        {
            Console.WriteLine("Connect DB");
        }

        [TearDown]   //after end of test
        public void closebrowser()
        {
            Console.WriteLine("Closing the Browser");
        }

        [Test, Order(2)] // ordering methods
        public void userreg()
        {
            Console.WriteLine("User Registration completed");
        }

        [Test, Order(1)]
        public void login()
        {
            Console.WriteLine("User Login successful");
        }

        [Test, Order(3)]
        public void products()
        {
            Console.WriteLine("User selects products");
        }
    }
}
