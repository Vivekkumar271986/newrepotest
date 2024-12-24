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
    internal class BrowserCommands
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Regression")]
        public void testcase1()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            //to get title to webpage
            string title = driver.Title;
            Console.WriteLine(title);

            //get the current URL
            string currenturl = driver.Url;
            Console.WriteLine(currenturl);

            //get the page source or the html code
            string pagesource = driver.PageSource;
            Console.WriteLine(pagesource);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
