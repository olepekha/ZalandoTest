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


namespace ShopNet.Bdd_Bindings
{
    [Binding]
    public class LogInSteps
    {
        public IWebDriver driver;
        public WebDriverWait waitf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

        [Given(@"I am at the ""(.*)"" home page")]
        public void GivenIAmAtTheHomePage(string p0)
        {
            driver = new ChromeDriver();
            waitf = new WebDriverWait(driver, t);
            driver.Navigate().GoToUrl(p0);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        
        [When(@"I click on the Login link")]
        public void WhenIClickOnTheLoginLink()
        {
            driver.FindElement(By.ClassName(@"z-navicat-header_navToolLabel")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

                        
        [Then(@"I go to the Login pop up window")]
        public void ThenIGoToTheLoginPopUpWindow()
        {
            Assert.That(driver.FindElement(By.Name("login.email")).Displayed);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [When(@"I enter valid email and password")]
        public void WhenIEnterValidEmailAndPassword(Table table)
        {
            

            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {

                driver.FindElement(By.Name("login.email")).SendKeys(users.Email);
                driver.FindElement(By.Name("login.password")).SendKeys(users.Password);
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {
            
            driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        

        [Then(@"I go to the ""(.*)"" page")]
        public void ThenIGoToThePage(string p0)
        {
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("account"));
            Assert.AreEqual("https://www.zalando.nl/myaccount/", p0);
            driver.Quit();
        }



    }
}
