//Test explorere select triats in Groupby
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.NUnitTests
{
    internal class Categories
    {
        [Test, Order(1), Category("Regression")]
        public void userreg()
        {
            Console.WriteLine("User Registration completed");
        }

        [Test, Order(2), Category("Smoke")]
        public void login()
        {
            Console.WriteLine("User Login successful");
        }

        [Test, Order(3), Ignore("Defect#1234"), Category("Regression")]
        public void products()
        {
            Console.WriteLine("User selects products");
        }

        [Test, Order(4), Category("Regression")]
        public void addtocart()
        {
            Console.WriteLine("User adds products to cart");
        }

        [Test, Order(5), Category("Sanity")]
        public void payment()
        {
            Console.WriteLine("User created order");
        }
    }
}