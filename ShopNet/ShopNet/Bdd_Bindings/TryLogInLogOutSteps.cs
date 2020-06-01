using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using log4net;
using log4net.Repository.Hierarchy;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow.Assist;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace ShopNet.Bdd_Bindings
{
    [Binding]
    public class TryLogInLogOutSteps

    {
        public IWebDriver driver;
        public WebDriverWait waitf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

        [Given(@"I am at  ""(.*)"" home page")]
        public void GivenIAmAtHomePage(string p0)
        {
            driver = new ChromeDriver();
            waitf = new WebDriverWait(driver, t);
            driver.Navigate().GoToUrl(p0);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        
        [Given(@"I click on the Login link")]
        public void GivenIClickOnTheLoginLink()
        {
            driver.FindElement(By.ClassName(@"z-navicat-header_navToolLabel")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        
        [When(@"I enter valid credentials: email and password")]
        public void WhenIEnterValidCredentialsEmailAndPassword(Table table)
        {

            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {

                driver.FindElement(By.Name("login.email")).SendKeys(users.Email);
                driver.FindElement(By.Name("login.password")).SendKeys(users.Password);
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        
        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            driver.FindElement(By.CssSelector("button[data-testid='login_button']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        
        [Then(@"I go to Login pop up window")]
        public void ThenIGoToLoginPopUpWindow()
        {
            Assert.That(driver.FindElement(By.Name("login.email")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }
        
        [Then(@"I go to  ""(.*)"" page")]
        public void ThenIGoToPage(string p0)
        {
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("account"));
            Assert.AreEqual("https://www.zalando.nl/myaccount/", p0);
            

        }

        [When(@"I cklick on LogOut link")]
        public void WhenICklickOnLogOutLink()
        {
            var myAccountElement = driver.FindElement(By.Id("fieldAccountAccountBox"));
            Thread.Sleep(1000);
            Actions action = new Actions(driver); // include OpenQA.Selenium.Interactions, action works with mouse
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("fieldAccountAccountBox")));

            action.MoveToElement(myAccountElement).Perform();
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("customerAccountBoxLayer")));
            var logout = driver.FindElement(By.PartialLinkText("Uitloggen"));
            logout.Click();
        }

        [Then(@"I log out to a ""(.*)"" home page")]
        public void ThenILogOutToAHomePage(string p0)
        {
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/"));
            Assert.AreEqual(@"https://www.zalando.nl/dames-home/", driver.Url);
            driver.Quit();
        }

    }
}
