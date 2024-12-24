using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectVkDec2024.NUnitTests
{
    internal class Assertions //constructer
    {
        [Test, Description ("First test case - adding description for ouyr info it wont be dispalyed in test report")]
        public void Assertrules()
        {
            String actual = "Google";
            String expected = "yahoo";

            if (actual == expected)
            {

                Console.WriteLine("The results are matching");
            }
            else
            {

                Console.WriteLine("The results are not matching");
            }

            // Assert.AreEqual(actual, expected); //  fail
            Assert.AreNotEqual(actual, expected);  // pass
            // Assert.AreSame(actual, expected); // fail
            Assert.AreNotSame(actual, expected); // pass
            
            // assert.that
            // Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual, Is.Not.EqualTo(expected));
            
            // assert for strings  with ignore case
            // Assert.That(actual, Is.EqualTo(expected).IgnoreCase);
            
            // substring
            Assert.That(actual, Does.Contain("goo").IgnoreCase);
            
            // empty assertions
            // Assert.IsTrue(actual.Equals(expected));
            //  Assert.IsEmpty(actual);
            //Assert.IsNull(actual);
            Assert.IsNotNull(actual);

            // collection contraints
            int[] array = new int[] { 1, 4, 3, 8, 5, 6 };
            Assert.NotNull(array);
            Assert.That(array, Is.All.GreaterThan(0));
            //Assert.IsEmpty(array);
            //Assert.That(array, Is.Ordered.Ascending);

            //int age = 17;
            //if (age < 18)
            //{
            //    throw new AssertionException("User is not eligible for voting");
            //}
        }
    }
}
