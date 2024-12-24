using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class FileDownload
    {
        IWebDriver driver;
        // Specify the download directory
        string DefaultDownloadDirectory = "C:\\Users\\vikum\\Downloads";
        string UtilityDownloadDirectory = "C:\\Users\\vikum\\source\\repos\\TestProjectVkDec2024\\TestProjectVkDec2024\\Utilities\\Downloads";

        [SetUp]
        public void startbrowser()

        {
            // Initial setup for the first download directory
            var options = new FirefoxOptions();
            options.SetPreference("browser.download.dir", DefaultDownloadDirectory);
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream"); // Adjust MIME type as needed

            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver(options);
        }

        [Test, Category("Regression")]
        public void DownloadFile()
        {
            try
            {
                // First download to DefaultDownloadDirectory
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/download");
                driver.Manage().Window.Maximize();
                Console.WriteLine(driver.Title);

                IWebElement FirstFile = driver.FindElement(By.XPath("(//a[normalize-space()='patients.json'])[1]"));
                string FileName = FirstFile.Text;
                FirstFile.Click();  // download to default downloads folder
                Thread.Sleep(7000);

                // Verify if the file exists in the Default Downloads folder
                string filePath = Path.Combine(DefaultDownloadDirectory, FileName);
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File: "+ FileName +" downloaded successfully to Default Downloads folder.");
                }
                else
                {
                    Console.WriteLine("File: "+ FileName +" not found in Default Downloads folder.");
                }

                // Reinitialize the driver with new download directory
                driver.Quit();
                var options = new FirefoxOptions();
                options.SetPreference("browser.download.dir", UtilityDownloadDirectory);
                options.SetPreference("browser.download.folderList", 2);
                options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream"); // Adjust MIME type as needed

                driver = new FirefoxDriver(options);
                driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/download");
                driver.Manage().Window.Maximize();
                IWebElement FirstFile1 = driver.FindElement(By.XPath("(//a[normalize-space()='patients.json'])[1]"));
                string FileName1 = FirstFile1.Text;
                FirstFile1.Click();  // download to utility downloads folder
                Thread.Sleep(7000);

                // Verify if the file exists in the Utility Downloads folder
                filePath = Path.Combine(UtilityDownloadDirectory, FileName1);
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File: "+ FileName1 +" downloaded successfully to Utility Downloads folder.");
                }
                else
                {
                    Console.WriteLine("File: "+ FileName1 +" not found in Utility Downloads folder.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
