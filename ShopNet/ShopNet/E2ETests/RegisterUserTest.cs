using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using log4net;
using log4net.Repository.Hierarchy;
using NUnit.Framework.Internal;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using ShopNet.POM;

namespace ShopNet.E2ETests
{
    class RegisterUserTest: TestBase
    {
        [Test]

        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void CreateUserAndLogin(String BrowserName) 
        {
                Initialize(BrowserName);
                driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");

                POM.RegisterUserPage page = new RegisterUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);

                page.InsertRegisterValue(page.FirstName, "olga");
                page.InsertRegisterValue(page.LastName, "test");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                page.BannerAccept.Click();
                page.InsertRegisterValue(page.RegisterEmail, "testolga78@gmail.com");
                page.InsertRegisterValue(page.RegisterPassword, "Test_Olga78");
                page.SelectCheckBox(RegisterUserPage.ButtonWomenSelector);
                page.SelectCheckBox(RegisterUserPage.ButtonTermsAndConditionsSelector);
                page.RegisterUser();

                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("account"));
                driver.Manage().Timeouts().PageLoad = new TimeSpan(0,0,20);
                Assert.AreEqual(@"https://www.zalando.nl/myaccount", driver.Url); 
                                                
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void CreateExistingUser(String BrowserName) 
        
        {
            try
            {
                Initialize(BrowserName);
                driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");

                POM.RegisterUserPage page = new RegisterUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);

                page.InsertRegisterValue(page.FirstName, "olga");
                page.InsertRegisterValue(page.LastName, "test1");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                page.BannerAccept.Click();
                page.InsertRegisterValue(page.RegisterEmail, "testolga78@gmail.com");
                page.InsertRegisterValue(page.RegisterPassword, "test2");
                page.SelectCheckBox(RegisterUserPage.ButtonWomenSelector);
                page.SelectCheckBox(RegisterUserPage.ButtonTermsAndConditionsSelector);
                page.RegisterUser();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[.='Volgens ons heb je al een account. Probeer in te loggen. Wachtwoord vergeten? Vraag een nieuwe aan.']")));
                Assert.AreEqual("Volgens ons heb je al een account. Probeer in te loggen. Wachtwoord vergeten? Vraag een nieuwe aan.", page.getErrorText());
            }

            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                logger.ErrorFormat($"Exception on CreateExistingUser: Message {ex.Message}; StackTrace:{ex.StackTrace}");
                throw;
            }

        }

    }
}
