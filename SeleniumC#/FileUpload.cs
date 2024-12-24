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
    internal class FileUpload
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Regression")]
        public void UploadFile()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            IWebElement browse = driver.FindElement(By.Id("file-upload"));
            browse.SendKeys("C:\\Users\\vikum\\source\\repos\\TestProjectVkDec2024\\TestProjectVkDec2024\\Utilities\\Testing image.jpg");
            Thread.Sleep(1000);
            IWebElement upload = driver.FindElement(By.Id("file-submit"));
            upload.Click();
            Thread.Sleep(1000);
            IWebElement fileuploadedmsg = driver.FindElement(By.XPath("//h3[normalize-space()='File Uploaded!']"));
            if (fileuploadedmsg.Displayed)
            {
                Console.WriteLine("The file is uploaded properly");
            }
            else
            {
                Console.WriteLine("\"The file is not  uploaded properly");
            }
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
