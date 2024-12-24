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
    internal class CheckboxMultiselect
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test, Category("Sanity")]
        public void saucedemomultiselectcheckbox()
        {
            driver.Navigate().GoToUrl("https://rahulshettyacademy.com/AutomationPractice/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            IReadOnlyList<IWebElement> Checkboxlist = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            int N = 1;
            foreach (IWebElement checkbox in Checkboxlist ) 
            {
                Console.WriteLine("Checkbox "+N + " clicked");
                Console.WriteLine(checkbox.GetAttribute("value"));
                Thread.Sleep(2000);
                checkbox.Click();
                N++;
            }
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
   