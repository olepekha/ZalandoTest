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


namespace ShopNet
{
    [Binding]
    public class CreateExistingUserAndGetErrorWhenSubmitSteps
    {
        public IWebDriver driver;
        public WebDriverWait waitf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set

        [Given(@"User is at the registration page")]
        
        public void GivenUserIsAtTheRegistrationPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
        }

        [When(@"I enter valid credentials for existing user")]
        public void WhenIEnterValidCredentialsForExistingUser(Table table)
        {
            IEnumerable<dynamic> credentials = table.CreateDynamicSet();
            foreach (var users in credentials)
            {
                driver.FindElement(By.Name("register.firstname")).SendKeys(users.Firstname);
                driver.FindElement(By.Name("register.lastname")).SendKeys(users.Lastname);
                driver.FindElement(By.Name("register.email")).SendKeys(users.Email); 
                driver.FindElement(By.Name("register.password")).SendKeys(users.Password); ;
            }

        }

        
        [When(@"Check all mandatory vields")]
        public void WhenCheckAllMandatoryVields()
        {
            IWebElement radioBtn_gender = driver.FindElement(By.Name("register.gender"));
            Thread.Sleep(1000);
            radioBtn_gender.Click();
            IWebElement checkBtn_TermsAndConditions = driver.FindElement(By.Name("register.terms-and-conditions-checkbox"));
            // waitf.Until(ExpectedConditions.ElementToBeClickable(By.Name("register.terms-and-conditions-checkbox")));
            checkBtn_TermsAndConditions.Click();
            
        }

        [When(@"Click registration button")]
        public void WhenClickRegistrationButton()
        {
            driver.FindElement(By.CssSelector(@".z-button.z-button--primary.z-button--button")).Click();
           
        }
        
               
        [Then(@"Error message should display")]
        public void ThenErrorMessageShouldDisplay()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            true.Equals(driver.FindElement(By.CssSelector(@".z-1-notification__content")).Displayed);
            Thread.Sleep(10000);
            driver.Quit();
        }

      

    }

}
