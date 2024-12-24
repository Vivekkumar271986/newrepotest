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
    internal class AlertsLabsession
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Smoke")]
        public void herokuappcheckbox()
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            driver.FindElement(By.Id("name")).SendKeys("Vivek Kumar");
            IWebElement alertbtn = driver.FindElement(By.Id("alertbtn"));
            alertbtn.Click();
            IAlert alt = driver.SwitchTo().Alert();
            string alertText = alt.Text;
            //Verify alert text
            Assert.AreEqual("Hello Vivek Kumar, share this practice page and share your knowledge", alertText);
            Console.WriteLine(alertText);
            //Clicking on OK Button
            alt.Accept();
            Thread.Sleep(2000);

            //Handling confirmation alerts
            driver.FindElement(By.Id("name")).SendKeys("Vivek Kumar");
            IWebElement confbtn = driver.FindElement(By.Id("confirmbtn"));
            confbtn.Click();
            string confText = alt.Text;
            Assert.AreEqual("Hello Vivek Kumar, Are you sure you want to confirm?", confText);
            Console.WriteLine(confText);
            //Clicking on OK Button
            alt.Accept();
            Thread.Sleep(2000);
            // clicking on cancel button
            driver.FindElement(By.Id("name")).SendKeys("Vivek Kumar");
            confbtn.Click();
            Assert.AreEqual("Hello Vivek Kumar, Are you sure you want to confirm?", confText);
            Console.WriteLine(confText);
            alt.Dismiss();
            Thread.Sleep(2000);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
