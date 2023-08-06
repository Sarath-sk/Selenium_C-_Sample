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
    public class HomePage
    {
        IWebDriver driver;
        LoginPage lp;

        public HomePage(IWebDriver dr)
        {
            driver = dr;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            lp = new LoginPage(driver);

        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Products']")]
        IWebElement VerifyHomePage;

        [FindsBy(How = How.XPath, Using = "//button[text()='Add to cart']")]
        IList<IWebElement> AddToCart;

        [FindsBy(How = How.XPath, Using = "//button[text()='Remove']")]
        public IList<IWebElement> RemoveFromCart;

        [FindsBy(How = How.XPath, Using = "//span[text()='3']")]
        public IWebElement CartItemsCount;


        public void VerifyHomePageInSauceDemo()
        {
            Assert.IsTrue(VerifyHomePage.Displayed, "Home page is not loaded..!!");
        }

        public void AddToCartProduct()
        {
            lp.Login();
            VerifyHomePageInSauceDemo();
            AddToCart[0].Click();
            AddToCart[1].Click();
            AddToCart[2].Click();
            Assert.IsTrue(RemoveFromCart.Count == 3, "Items are not added to cart!!");
            Assert.IsTrue(CartItemsCount.Text == "3", "Items are not added to cart!!");
            CartItemsCount.Click();
        }
    }
}
