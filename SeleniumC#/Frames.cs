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

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class Frames
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Sanity")]
        public void frames()
        {
            driver.Navigate().GoToUrl("https://jqueryui.com/checkboxradio/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            // frame as a xpath
            IWebElement Iframe1 = driver.FindElement(By.XPath("//iframe[@class='demo-frame']"));
            Assert.IsNotNull(Iframe1);
            driver.SwitchTo().Frame(Iframe1);  //Xpath
            Console.WriteLine("Inside Iframe: "+ Iframe1);


            // driver.SwitchTo().Frame(0); //indexing
            //  driver.SwitchTo().Frame(name);  //Byname
            //  driver.SwitchTo().Frame(id);  //By Id
           

            IWebElement radio = driver.FindElement(By.XPath("//label[normalize-space()='New York']"));
            radio.Click();
            Console.WriteLine("Radio button: " + radio.Text +" Clicked.");
            Thread.Sleep(1000);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
