using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.NUnitTests
{
    [Parallelizable(ParallelScope.All)]
    internal class ParallelExecution
    {
        [Test] 
        public void Registration()  //Function Name
        {
            Console.WriteLine("User Registration completed");
        }

        [Test]
        public void login()
        {
            Console.WriteLine("User Login successful");
        }

        [Test]
        public void products()
        {
            Console.WriteLine("User selects products");
        }

        [Test]
        public void addtocart()
        {
            Console.WriteLine("User adds products to cart");
        }

        [Test]
        public void payment()
        {
            Console.WriteLine("User created order");
        }
    }
}
