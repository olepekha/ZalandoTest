using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using ShopNet.Pages;

namespace ShopNet.E2ETests
{
    class LoginPageTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginAndLogOut(String BrowserName) //
        {
            try
            {

                Initialize(BrowserName);
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                LoginUserPage page = new LoginUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);

                page.LoginLableClick();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login.email")));
                page.InsertLoginValue(page.LoginEmail, "testolga77@gmail.com");
                page.InsertLoginValue(page.LoginPassword, "Test_Olga77");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                driver.FindElement(By.Id("uc-btn-accept-banner")).Click();
                page.LoginUser();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("myaccount"));
                Assert.AreEqual(@"https://www.zalando.nl/myaccount/", driver.Url);

                page.LoginLableClick();
                page.LogOutUser();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/"));
                Assert.AreEqual(@"https://www.zalando.nl/", driver.Url);

            }
            catch (NoSuchElementException ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithInvalidEmail(String BrowserName)
        {
            try
            {
                Initialize(BrowserName);
                LoginUserPage page = new LoginUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);

             //example of craeting a Test report using extent.Flush();
                test = extent.CreateTest("LoginWithInvalidEmail");
                test.Fail("test");
                test.Info("info");
                extent.Flush();

                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                page.LoginLableClick();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login.email")));
                page.InsertLoginValue(page.LoginEmail, "invalidemail.com");
                page.InsertLoginValue(page.LoginPassword, "Test_Olga77");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                driver.FindElement(By.Id("uc-btn-accept-banner")).Click();
                page.LoginUser();
                Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", page.getErrorText(page.InvalidEmailError));
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithIncorrectPsw(String BrowserName) //
        {
            try
            {
                Initialize(BrowserName);
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                LoginUserPage page = new LoginUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);
                page.LoginLableClick();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login.email")));
                page.InsertLoginValue(page.LoginEmail, "testolga77@gmail.com");
                page.InsertLoginValue(page.LoginPassword, "InvalidPassword");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                driver.FindElement(By.Id("uc-btn-accept-banner")).Click();
                page.LoginUser();
                Assert.AreEqual("Controleer of je het juiste e-mailadres en wachtwoord gebruikt hebt en probeer het nog eens.", page.getErrorText(page.InvalidPasswordError));
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithBlankUser(String BrowserName) //
        {
            try
            {
                Initialize(BrowserName);
                LoginUserPage page = new LoginUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);
                page.LoginLableClick();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login.email")));
                page.InsertLoginValue(page.LoginEmail, "");
                page.InsertLoginValue(page.LoginPassword, "InvalidPassword");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                driver.FindElement(By.Id("uc-btn-accept-banner")).Click();
                page.LoginUser();
                Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", page.getErrorText(page.BlankUserError));
            }

            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithBlankPassword(String BrowserName) 
        {
            try
            {
                Initialize(BrowserName);
                LoginUserPage page = new LoginUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);
                page.LoginLableClick();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("login.email")));
                page.InsertLoginValue(page.LoginEmail, "testolga77@gmail.com");
                page.InsertLoginValue(page.LoginPassword, "");
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("uc-btn-accept-banner")));
                driver.FindElement(By.Id("uc-btn-accept-banner")).Click();
                page.LoginUser();
                Assert.AreEqual("Dit is een verplicht veld", page.getErrorText(page.BlankPasswordError));
            }

            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }
    }    
}
