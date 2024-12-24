using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class InvokeChrome
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            //launch Chrome browser
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }

        [Test, Category("Smoke")]
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
