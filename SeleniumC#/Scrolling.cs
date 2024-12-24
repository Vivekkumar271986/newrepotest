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
    internal class Scrolling
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void ScrollDownAndClick()
        {
            driver.Navigate().GoToUrl("https://jqueryui.com/checkboxradio/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            Thread.Sleep(3000);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 500);");
            Thread.Sleep(2000);// Scroll down 500px

            IJavaScriptExecutor jsnew = (IJavaScriptExecutor)driver;
            jsnew.ExecuteScript("window.scrollBy(0, -500);"); // Scroll up 500px
            Thread.Sleep(2000);

            /*     // Locate the element
                 IWebElement LearningCenterFooterLink = driver.FindElement(By.XPath("//a[normalize-space()='Tooltip']//a[normalize-space()='Add Class']"));

             // Use Actions class to scroll to the element and click it
             // Limitation: Viewport Visibility: The Actions class does not automatically scroll the target element into view.You need to ensure the element is within the viewport before performing actions on it
                 new Actions(driver)
                     .ScrollToElement(LearningCenterFooterLink)
                     .Perform();

                 Thread.Sleep(5000);  */
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}