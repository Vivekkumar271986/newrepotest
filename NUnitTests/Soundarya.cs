using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.NUnitTests
{
    [TestFixture, Description("This is a Bank Registration Website"), Category("BankXYZ")]
    [Allure.NUnit.AllureNUnit]
    internal class Soundarya
    {

        [TestCase("user2"), Order(2), Category("Login")]
        public void CustomerLogin(string username)
        {
            int found = 0;

            List<string> list = new List<string> { "user1", "user2" };
            foreach (var item in list)
            {
                if (item == username)
                {
                    Console.WriteLine("Customer is logged in successfully.\nCustomer Name " + item);
                    found = 1;
                    break;
                }
                else continue;
            }
            if (found == 0)
            {
                Console.WriteLine("No user named " + username);
            }
        }
        [TestCase("Soundarya"), Order(5), Category("Manager")]
        public void userreg(string username)
        {
            Console.WriteLine("Manager is logged in successfully.");
            Assert.AreEqual(username, "Soundarya", "Manager name does not match.");
        }

        [TestCase("Sakshi"), Order(6), Category("Manager"), Ignore("Manager Absent")]
        public void userreg2(string username)
        {
            Console.WriteLine($"User registration for: {username}");
            Assert.AreEqual(username, "Sakshi", "Username does not match.");
        }
    }

}