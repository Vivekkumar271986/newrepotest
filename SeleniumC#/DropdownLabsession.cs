using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class DropdowDropdownLabsession
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Sanity")]
        public void herokuappcheckbox()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            IWebElement dropdown = driver.FindElement(By.Id("dropdown"));
            Assert.IsNotNull(dropdown);
            var select = new SelectElement(dropdown);
            //select by visible text option 1
            Thread.Sleep(1000);
            select.SelectByText(("Option 1"));
            Thread.Sleep(1000);
            select.SelectByIndex(2);
            Thread.Sleep(1000);
            select.SelectByValue("1");
            Thread.Sleep(1000);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
