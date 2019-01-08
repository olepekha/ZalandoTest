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
using SpecFlow.Assist.Dynamic;
using TechTalk.SpecFlow.Assist;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ShopNet
{
    [Binding]
    public class LogOutSteps

    {
        public IWebDriver driver;
        public WebDriverWait waitf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

        [Given(@"I am at the ""(.*)""")]
        public void GivenIAmAtThe(string p0)
        {
            driver = new ChromeDriver();
            waitf = new WebDriverWait(driver, t);
            driver.Navigate().GoToUrl(p0);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [When(@"I click on the inloggen link")]
        public void WhenIClickOnTheInloggenLink()
        {
            driver.FindElement(By.ClassName(@"z-navicat-header_navToolLabel")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [When(@"I go to the inloggen pop up window")]
        public void WhenIGoToTheInloggenPopUpWindow()
        {
            Assert.That(driver.FindElement(By.Name("login.email")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [When(@"I enter valid email and password for user")]
        public void WhenIEnterValidEmailAndPasswordForUser(Table table)
        {
            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {

                driver.FindElement(By.Name("login.email")).SendKeys(users.Email);
                driver.FindElement(By.Name("login.password")).SendKeys(users.Password);
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [When(@"I click on Inloggen button")]
        public void WhenIClickOnInloggenButton()
        {
            driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [When(@"I go to the ""(.*)"" page")]
       
        public void WhenIGoToThePage(string p0)
        {
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("account"));
            Assert.AreEqual("https://www.zalando.nl/myaccount/", p0);
        }
        
        [When(@"I click on the Niet Olga\? Uitloggen link at mijn account list")]
        public void WhenIClickOnTheNietOlgaUitloggenLinkAtMijnAccountList()
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

        [Then(@"I should loged out to the ""(.*)""")]
        public void ThenIShouldLogedOutToThe(string p0)
        {
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/"));
            Assert.AreEqual(@"https://www.zalando.nl/dames-home/", driver.Url);
            driver.Quit();

        }
    }
}
