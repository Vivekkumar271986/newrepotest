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
    internal class Locators
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void testcase1()
        {
            driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/practice/register.php");
            IWebElement FirstName = driver.FindElement(By.Id("firstname"));
            FirstName.SendKeys("Vivek");
            IWebElement LastName = driver.FindElement(By.Name("lastname"));
            LastName.SendKeys("Kumar");
            IWebElement UserName = driver.FindElement(By.XPath("//input[@id='username']"));
            LastName.SendKeys("VivekKumar");
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='password']"));
            LastName.SendKeys("Vk86");
            IWebElement BacktoLogin = driver.FindElement(By.LinkText("Back to Login"));
            BacktoLogin.Click();
            IWebElement Register = driver.FindElement(By.PartialLinkText("Back to Log"));
            Register.Click();
            IWebElement Elements = driver.FindElement(By.CssSelector("button[data-bs-target='#collapseOne']"));
            Elements.Click();
            IWebElement classname = driver.FindElement(By.ClassName("(//input[@class = 'form-control'])[1]"));
            classname.SendKeys("jkkj");

        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}