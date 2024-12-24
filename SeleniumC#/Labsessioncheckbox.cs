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
    internal class Labsessioncheckbox
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
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            driver.Manage().Window.Maximize();
            IWebElement checkbox = driver.FindElement(By.XPath("//input[2]"));
            if (checkbox.Selected)
            {
                // Click the checkbox to unselect it
                checkbox.Click();
            }

            //check boxes can be single select or multiselect
            IReadOnlyList<IWebElement> checkboxlist = driver.FindElements(By.XPath("//form[@id='checkboxes']"));
            foreach (IWebElement e in checkboxlist)
            {
                Console.WriteLine(e.Text);
                e.Click();
                Thread.Sleep(1000);

            }
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
