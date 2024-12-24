using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class NavigationalCommands
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void testcase1()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.Navigate().Forward();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();

        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
