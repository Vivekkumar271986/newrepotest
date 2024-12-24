using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class WindowsTabHandling
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void ParentAndChildTabNavigation()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Page title of launched Page: " + driver.Title);

            // Fetch the parent window handle 
            string parentHandle = driver.CurrentWindowHandle;

            IWebElement clickHere = driver.FindElement(By.XPath("//a[normalize-space()='Click Here']"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Explicit wait
            wait.Until(d => clickHere.Displayed);
            clickHere.Click();
            Console.WriteLine("'Click Here' button clicked");

            // Fetch the window handles of all the windows - two windows are opened
            IList<string> windowHandles = new List<string>(driver.WindowHandles);
            Console.WriteLine("Parent Window: " + windowHandles[0]);
            Console.WriteLine("Child Window: " + windowHandles[1]);

            // Move the control to the child window
            driver.SwitchTo().Window(windowHandles[1]);
            string currentHandle = driver.CurrentWindowHandle;
            
            // Wait for the title of the new window to be "New Window"
            wait.Until(d => d.Title == "New Window");
            Console.WriteLine("Current window is: " + currentHandle);

            string childPageTitle = driver.Title;
            Assert.AreEqual("New Window", childPageTitle);
            Console.WriteLine("Child Window Page Title: " + childPageTitle);

            driver.Close();
            driver.SwitchTo().Window(windowHandles[0]);

            string parentPageTitle = driver.Title;
            Console.WriteLine("Parent Window Page Title: " + parentPageTitle);
            Assert.AreEqual("The Internet", parentPageTitle);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}