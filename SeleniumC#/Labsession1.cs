using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class Labsession1
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void orangehrmlive()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            Thread.Sleep(6000);
            IWebElement Username = driver.FindElement(By.XPath("//input[@placeholder='Username']"));
            Username.SendKeys("Admin");
            IWebElement Password = driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            Password.SendKeys("admin123");
            IWebElement Login = driver.FindElement(By.XPath("//button[@type='submit']"));
            Login.Click();
            Thread.Sleep(6000);
            Console.WriteLine("Login Successful");
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.Navigate().Forward();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();

        }

        [Test]
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
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.Navigate().Forward();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();

        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
