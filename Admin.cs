using AutomationDemo.Pages;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace AutomationDemo
{
    [TestFixture]
    public class Admin
    {
        IWebDriver driver;
        ExtentReports reports;
        ExtentHtmlReporter htmlReporter;
        LoginPage lp;
        HomePage hp;
        CartPage cp;

        [SetUp]
        public void Init()
        {
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            lp = new LoginPage(driver);
            hp = new HomePage(driver);
            cp = new CartPage(driver);
        }

        [OneTimeSetUp]
        public void Setup()
        {
            reports = new ExtentReports();
            htmlReporter = new ExtentHtmlReporter("C:\\Users\\Sarath\\source\\repos\\AutomationDemo\\Reports\\index.html");
            reports.AttachReporter(htmlReporter);

        }
        public void TestcaseIfPass(string title, string description)
        {
            var testcase = reports.CreateTest(title);
            testcase.Pass(description);
        }

        public void TestcaseIfFailed(string title, string description)
        {
            var testcase = reports.CreateTest(title);
            testcase.Fail(description);
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            var srcshot = screenshot.GetScreenshot();
            testcase.AddScreenCaptureFromBase64String(srcshot.AsBase64EncodedString);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            reports.Flush();
        }


        //[TearDown]
        public void Quit()
        {
            driver.Quit();
        }


        [Test]
        public void LoginStandardUser()
        {
            try
            {
                lp.Login();
                TestcaseIfPass("LoginStandardUser", "Login was successful..!!");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                TestcaseIfFailed("LoginStandardUser", ex.Message);
                throw (ex);
            }
            finally
            {
                driver.Close();
            }
        }

        [Test]
        public void ItemsAddedToCart()
        {
            try
            {
                hp.AddToCartProduct();
                TestcaseIfPass("ItemsAddedToCart", "Items are added to cart..!!");
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                TestcaseIfFailed("ItemsAddedToCart", ex.Message);
                throw (ex);
            }
            finally
            {
                driver.Close();
            }
        }

        [Test]
        public void ChechOutCartItems()
        {
            try
            {
                cp.VerifyCartPageInSauceDemo();
                TestcaseIfPass("ChechOutCartItems", "Checkout page is loaded");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                TestcaseIfFailed("ChechOutCartItems", ex.Message);
                throw (ex);
            }
            finally
            {
                driver.Close();
            }

        }
    }
}