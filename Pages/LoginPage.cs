using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.Pages
{
    public class LoginPage
    {
        IWebDriver driver;

        // Constructor
        public LoginPage(IWebDriver dr)
        {
            driver = dr;
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [FindsBy(How = How.Id, Using = "user-name")]
        IWebElement UserName;

        [FindsBy(How = How.Id, Using = "password")]
        IWebElement Password;

        [FindsBy(How = How.Id, Using = "login-button")]
        IWebElement Login_btn;


        public void Login()
        {
            UserName.SendKeys("standard_user");
            Password.SendKeys("secret_sauce");
            Login_btn.Click();

        }






    }
}
