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
    internal class Radiobuttons
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void saucedemoradiocheckbox()
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            Thread.Sleep(6000);
            //Radio buttons are singe select
            IWebElement Radio1 = driver.FindElement(By.XPath("//input[@value='radio1']"));
            Radio1.Click();
            if (Radio1.Enabled)
            Console.WriteLine("Radio 1 button clicked");
            IWebElement Radio2 = driver.FindElement(By.XPath("(//input[@name='radioButton'])[2]"));
            Radio2.Click();
            if (Radio2.Enabled)
            Console.WriteLine("Radio 2 button clicked");
            IWebElement Radio3 = driver.FindElement(By.XPath("//input[@value='radio3']"));
            Radio3.Click();
            if (Radio3.Enabled)
            Console.WriteLine("Radio 3 button clicked");
            //Select Single Checkbox
            IWebElement Checkbox = driver.FindElement(By.XPath("//input[@id='checkBoxOption1']"));
            if (Checkbox.Displayed)
            {
            Console.WriteLine("Checkbox Displayed");
            Checkbox.Click();
            Console.WriteLine("Checkbox Clicked");
            }
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
   