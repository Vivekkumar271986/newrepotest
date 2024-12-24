using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class InvokeEdge
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch Edge browser
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
        }

        [Test, Category("Sanity")]
        public void testcases1()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        [TearDown]
        public void closebrowser()
        {
            driver.Close();
        }
    }
}
