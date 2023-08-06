using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.Pages
{
    public class CartPage
    {
        IWebDriver driver;
        HomePage hp;
        LoginPage lp;
        public CartPage(IWebDriver dr)
        {
            driver = dr;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            hp = new HomePage(driver);
            lp = new LoginPage(driver);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Your Cart']")]
        public IWebElement VerifycartPage { get; set;}

        [FindsBy(How = How.XPath, Using = "//button[text()='Checkout']")]
        public IWebElement CheckOutBtn { get; set;}


        public void VerifyCartPageInSauceDemo()
        {
            //lp.Login();
            hp.AddToCartProduct();
            Assert.IsTrue(VerifycartPage.Text.Contains("Your Cart"), "Cart page is not loaded..!!");
            Assert.IsTrue(CheckOutBtn.Displayed, "cart page is not loaded!!");
            Assert.IsTrue(hp.RemoveFromCart.Count == 3, "Cart page is not loaded!!");
            Assert.IsTrue(hp.CartItemsCount.Text == "4", "Cart page is not loaded!!");
            CheckOutBtn.Click();

        }
    }
}
