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
    internal class Alerts
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Regression")]
        public void herokuappcheckbox()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            IWebElement infoalert = driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Alert']"));
            infoalert.Click();
            //Handling infomation alerts
            IAlert alt = driver.SwitchTo().Alert();
            //Clicking on OK Button
            alt.Accept();
            Thread.Sleep(2000);
            //Handling confirmation alerts
            IWebElement confalert = driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Confirm']"));
            confalert.Click();
            // clicking on cancel button
            alt.Dismiss();
            Thread.Sleep(2000);
            // Handling prompt alerts
            IWebElement propalert = driver.FindElement(By.XPath("//button[normalize-space()='Click for JS Prompt']"));
            propalert.Click();
            // clicking on cancel button
            string alerttext = alt.Text;
            Console.WriteLine(alerttext);
            Thread.Sleep(2000);
            alt.SendKeys("Hello");
            alt.Accept();
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
