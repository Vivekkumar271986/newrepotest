using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEGdecbatch.DataDrivenTesting
{

    internal class TestParUsingTestcaseSource
    {
        [Test, TestCaseSource("GetTestdata")]
        public void LoginTest(String username, string password)
        {
            Console.WriteLine(username + " : " + password);
        }

        public static IEnumerable<TestCaseData> GetTestdata()
        {
            yield return new TestCaseData("abc.com", "gghh");
            yield return new TestCaseData("ybc.com", "eerr");

        }
    }
}