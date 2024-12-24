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
using NUnit.Framework;
using static OpenQA.Selenium.BiDi.Modules.Input.Wheel;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class WebtableHandling
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void Wintable()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);  //Implicit wait
            //Fetch table
            IWebElement table = driver.FindElement(By.XPath("//table[@id='table1']"));
            //Fetch the rows
            List<IWebElement> trrow = new List<IWebElement>(table.FindElements(By.XPath("//table[@id = 'table1']/tbody/tr")));
            int rowcount = trrow.Count();
            Console.WriteLine(rowcount);
            // fecth the columns 
            List<IWebElement> tdcol = new List<IWebElement>(table.FindElements(By.XPath("//table[@id = 'table1']/tbody/tr[1]/td")));
            int colcount = tdcol.Count();
            Console.WriteLine(colcount);
            // cell data text
            IWebElement celldata = driver.FindElement(By.XPath("//table[@id = 'table1']/tbody/tr[1]/td[2]"));
            string text = celldata.Text;
            Console.WriteLine(text);
            Assert.AreEqual("John", text);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}