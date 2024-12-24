using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class Asserttest
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Sanity")]
        public void saucedemo()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            Thread.Sleep(6000);
            IWebElement Username = driver.FindElement(By.XPath("//input[@id='user-name']"));
            Username.SendKeys("standard_user");
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='password']"));
            Password.SendKeys("secret_sauce");
            IWebElement Login = driver.FindElement(By.XPath("//input[@id='login-button']"));
            Login.Click();
            Thread.Sleep(6000);
            IWebElement Products = driver.FindElement(By.XPath("//div[@class ='product_label']"));
            
            // Displayed validation
            if (Products.Displayed)
            {
                Console.WriteLine("User is on the home page");
            }
            else
            {
                Console.WriteLine("User is not on the home page");
            }
            // Assertion class valdiation
            string actualtext = Products.Text;
            string expectedvalue = "Products";
            Assert.AreEqual(actualtext, expectedvalue);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
