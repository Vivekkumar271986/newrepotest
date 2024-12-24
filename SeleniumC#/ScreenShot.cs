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
using OpenQA.Selenium.Support.Extensions;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class ScreenShot
    {
        IWebDriver driver;
        string baseDirectory = "C:\\Users\\vikum\\source\\repos\\TestProjectVkDec2024\\TestProjectVkDec2024\\Utilities\\Screenshots";

        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void testcasewithscreenshot()
        {
            // Create a new folder with timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string folder = Path.Combine(baseDirectory, $"TCScreenshot_{timestamp}");
            Directory.CreateDirectory(folder);

            // Initialize screenshot counter
            int screenshotNumber = 1;

            //open browser and take screenshots and save in folder created
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            driver.TakeScreenshot().SaveAsFile(Path.Combine(folder, $"screenshot_{screenshotNumber++}.png"));
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/download");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            driver.TakeScreenshot().SaveAsFile(Path.Combine(folder, $"screenshot_{screenshotNumber++}.png"));
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
