using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class InvokeFireFox
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        //launch FF browser
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Smoke")]
        public void testcase()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
