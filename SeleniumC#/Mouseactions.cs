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

namespace TestProjectVkDec2024.SeleniumC_
{
    [Allure.NUnit.AllureNUnit]
    internal class Mouseactions
    {
        IWebDriver driver;
        [SetUp]
        public void startbrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void herokuappcheckbox()
        {
            //mouse hover
            //driver.Navigate().GoToUrl("https://www.amazon.in");
            //driver.Manage().Window.Maximize();
           // Console.WriteLine(driver.Title);
            //IWebElement prime = driver.FindElement(By.XPath("//span[normalize-space()='Prime']"));
            //IWebElement latestmovies = driver.FindElement(By.XPath("//span[text()='Latest movies and TV shows']"));


            //Actions actions = new Actions(driver);
            //actions.MoveToElement(prime).Perform();
           // System.Threading.Thread.Sleep(1000);
           // latestmovies.Click();
            //new Actions(driver)
            //   .MoveToElement(prime)
            //   .MoveToElement(latestmovies)
            //  .Click().Perform();
            //Thread.Sleep(1000);

            //drag and drop
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            IWebElement source = driver.FindElement(By.Id("column-a"));
            IWebElement dest = driver.FindElement(By.Id("column-a"));

            new Actions(driver)
             .DragAndDrop(source, dest).Perform();
            Thread.Sleep(4000);

            //Context Menu or right click
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/context_menu");
            IWebElement box = driver.FindElement(By.Id("hot-spot"));
            new Actions(driver)
             .ContextClick(box).Perform();
            Thread.Sleep(4000);
            IAlert alt = driver.SwitchTo().Alert();
            //Clicking on OK Button
            alt.Accept();
        }

            [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
