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

namespace ShopNet.Bdd_Bindings
{
    [Binding]
    public class ErrorMessageShouldAppearsWhenITryToCreateNewUserThatAlreadyExistInTheSystemSteps
    {
        public IWebDriver driver;
        
        public WebDriverWait waitf;

        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

        [Given(@"I Am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.zalando.nl/");
            
        }
        
        [Given(@"I navigate to register new user page")]
        public void GivenINavigateToRegisterNewUserPage()
        {

            driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
        }
        
        [When(@"I enter valid credentials for already existing user")]
        public void WhenIEnterValidCredentialsForAlreadyExistingUser()
        {
            driver.FindElement(By.Name("register.firstname")).SendKeys("dfdfdso");
            driver.FindElement(By.Name("register.lastname")).SendKeys("dsfsdf");
            driver.FindElement(By.Name("register.email")).SendKeys("testolga77@gmail.com"); //o.ya@ro.ru o.qw@rambler.ru
            driver.FindElement(By.Name("register.password")).SendKeys("sdasdasdasdsad"); //1111111111
            IWebElement radioBtn_gender = driver.FindElement(By.Name("register.gender"));
            Thread.Sleep(1000);
            radioBtn_gender.Click();
            IWebElement checkBtn_TermsAndConditions = driver.FindElement(By.Name("register.terms-and-conditions-checkbox"));
            // waitf.Until(ExpectedConditions.ElementToBeClickable(By.Name("register.terms-and-conditions-checkbox")));
            checkBtn_TermsAndConditions.Click();
            driver.FindElement(By.CssSelector(@".z-button.z-button--primary.z-button--button")).Click();
           
        }
        
        [Then(@"I get error message and do not login")]
        public void ThenIGetErrorMessageAndDoNotLogin()

        {
          //  waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-1-notification__content")));
            var a = driver.FindElement(By.CssSelector(@".z-1-notification__content")).Text;
            Assert.AreEqual("Volgens ons heb je al een account. Probeer in te loggen. Wachtwoord vergeten? Vraag een nieuwe aan.", a);
            driver.Quit();
        }
    }
}
