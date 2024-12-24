using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class Keyboardevents
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void herokuappcheckbox()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            IWebElement id = driver.FindElement(By.Id("email"));
            IWebElement password = driver.FindElement(By.Id("pass"));

            new Actions(driver)
                .MoveToElement(id).Click()
                .KeyDown(Keys.Shift)
                .SendKeys("vivekK")
                .Perform();

            new Actions(driver)
                .MoveToElement(password).Click()
                .KeyDown(Keys.Shift)
                .SendKeys("pass132")  //will enter PASS!@#
                .Perform();
            Thread.Sleep(1000);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
