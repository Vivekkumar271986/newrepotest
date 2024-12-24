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
    internal class Saucedemolabpracticeendtoend
    {
        IWebDriver driver;

        [SetUp]
        public void startbrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }

        [Test]
        public void saucedemoendtoend()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Title);
            Thread.Sleep(1000);

            // Login page
            IWebElement Username = driver.FindElement(By.XPath("//input[@id='user-name']"));
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='password']"));
            IWebElement Login = driver.FindElement(By.XPath("//input[@id='login-button']"));
            Username.SendKeys("standard_user");         
            Password.SendKeys("secret_sauce");            
            Login.Click();
            Thread.Sleep(2000);

            //Validate user is logged in and products label is displayed
            IWebElement Products = driver.FindElement(By.XPath("//div[@class='product_label']"));
            if (Products.Displayed)
            {
                Console.WriteLine("User logged in to home Page");
            }

            // Open product in detail view
            IWebElement SauceLabsBackpack = driver.FindElement(By.XPath("//div[normalize-space()='Sauce Labs Backpack']"));
            SauceLabsBackpack.Click();
            IWebElement Productnamedetailview = driver.FindElement(By.XPath("//div[@class='inventory_details_name']"));
            string Productname = Productnamedetailview.Text;
            Assert.AreEqual("Sauce Labs Backpack", Productname);
            Console.WriteLine(Productname);

            // Click Add to Cart
            IWebElement AddToCart = driver.FindElement(By.XPath("//button[normalize-space()='ADD TO CART']"));
            AddToCart.Click();
            Thread.Sleep(2000);

            // Click Cart Icon
            IWebElement CartIcon = driver.FindElement(By.XPath("//*[name()='path' and contains(@fill,'currentCol')]"));
            CartIcon.Click();
            Thread.Sleep(1000);

            // Verify Cart Page
            String Headerlocator = "//div[@class='subheader']";
            IWebElement CheckoutHeaderCartInfo = driver.FindElement(By.XPath(Headerlocator));
            string CheckoutCart = CheckoutHeaderCartInfo.Text;
            Assert.AreEqual("Your Cart", CheckoutCart);
            Console.WriteLine("Checkout header is: " + CheckoutCart);

            // Verify product in cart
            IWebElement Firstproductincart = driver.FindElement(By.XPath("(//div[@class='inventory_item_name'])[1]"));
            string FirstProductname = Firstproductincart.Text;
            Assert.AreEqual("Sauce Labs Backpack", FirstProductname);
            Console.WriteLine("Product in Cart: " + FirstProductname);

            // Click Checkout
            IWebElement Checkout = driver.FindElement(By.XPath("//a[@class='btn_action checkout_button']"));
            Checkout.Click();

            // Verify Checkout page
            IWebElement CheckoutHeaderYourInfo = driver.FindElement(By.XPath(Headerlocator));
            string Checkoutinfo = CheckoutHeaderYourInfo.Text;
            Assert.AreEqual("Checkout: Your Information", Checkoutinfo);
            Console.WriteLine("Checkout header is: " + Checkoutinfo);

            // Enter Checkout details
            Console.WriteLine("Enter Checkout details");
            IWebElement FirstName = driver.FindElement(By.Id("first-name"));
            IWebElement LastName = driver.FindElement(By.Id("last-name"));
            IWebElement ZipPostalCode = driver.FindElement(By.Id("postal-code"));
            IWebElement Continue = driver.FindElement(By.XPath("//input[@class='btn_primary cart_button']"));
            FirstName.SendKeys("Vivek");
            LastName.SendKeys("Kumar");
            ZipPostalCode.SendKeys("575008");
            Continue.Click();
            Console.WriteLine("Checkout Continue");
            Thread.Sleep(2000);

            // Verify Checkout Overview
            IWebElement CheckoutHeaderOverview = driver.FindElement(By.XPath(Headerlocator));
            string CheckoutinfoOverview = CheckoutHeaderOverview.Text;
            Assert.AreEqual("Checkout: Overview", CheckoutinfoOverview);
            Console.WriteLine("Checkout header is: " + CheckoutinfoOverview);
            Thread.Sleep(2000);
            IWebElement Firstproductincheckout = driver.FindElement(By.XPath("(//div[@class='inventory_item_name'])[1]"));
            string FirstCheckoutProductname = Firstproductincheckout.Text;
            Assert.AreEqual("Sauce Labs Backpack", FirstCheckoutProductname);
            Console.WriteLine("Product in Cart: " + FirstCheckoutProductname);
            //Click finish
            IWebElement FinishButton = driver.FindElement(By.XPath("//a[@class='btn_action cart_button']"));
            FinishButton.Click();

            //Verify thank you page
            IWebElement CheckoutHeaderThankYou = driver.FindElement(By.XPath(Headerlocator));
            string CheckoutInfoThankYou = CheckoutHeaderThankYou.Text;
            Assert.AreEqual("Finish", CheckoutInfoThankYou);
            Console.WriteLine("Checkout header is: " + CheckoutInfoThankYou);
            IWebElement CheckoutThankYouForYourOrder = driver.FindElement(By.XPath("//h2[@class='complete-header']"));
            string CheckoutThankYouText = CheckoutThankYouForYourOrder.Text;
            Assert.AreEqual("THANK YOU FOR YOUR ORDER", CheckoutThankYouText);
            Console.WriteLine("Checkout Finish header is: " + CheckoutThankYouText);
            IWebElement CheckoutOrderInfo = driver.FindElement(By.XPath("//div[@class='complete-text']"));
            string CheckoutThankYouTextinfo = CheckoutOrderInfo.Text;
            Assert.AreEqual("Your order has been dispatched, and will arrive just as fast as the pony can get there!", CheckoutThankYouTextinfo);
            Console.WriteLine("Order Info text is: " + CheckoutThankYouTextinfo);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
