using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspectInjector.Broker;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitSeleniumC_Training.Utilities;


namespace TestEGdecbatch.DataDrivenTesting
{
    internal class TestParUsingExcel
    {

        [Test, TestCaseSource("GetTestdata")]
        public void LoginTest(String username, string password)
        {
            Console.WriteLine(username + " : " + password);
        }


        public static IEnumerable<TestCaseData> GetTestdata()
        {
            var columns = new List<string> { "username", "password" };
            return ExcelRead.GetTestDataFromExcel("C:\\Users\\vikum\\source\\repos\\TestProjectVkDec2024\\TestProjectVkDec2024\\testdata.xlsx", "logintest", columns);
        }

    }
}