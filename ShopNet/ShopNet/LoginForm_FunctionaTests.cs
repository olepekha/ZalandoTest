using System;
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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace ShopNet
{
    [TestFixture]
    public class LoginForm_FunctionalTests : TestBase

    {


        [Test]
        
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void CreateUserAndLogin(String BrowserName) //user should be created
        {
            try
            {
                Initialize(BrowserName);
                //Create Test report using ExtentReports
                test = extent.CreateTest("CreateUserAndLogin");
                var status = TestContext.CurrentContext.Result.Outcome.Status;

                var stackTrace = "+ TestContext.CurrentContext.Result.StackTrace + ";

                var errorMessage = TestContext.CurrentContext.Result.Message;


                if (status == NUnit.Framework.Interfaces.TestStatus.Failed)

                {

                    test.Log(AventStack.ExtentReports.Status.Fail, status + errorMessage);

                }
                extent.Flush();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
                driver.FindElement(By.Name("register.firstname")).SendKeys("olga");
                var eem1 = driver.FindElement(By.Name("register.firstname"));

                logger.Info("first name ='" + eem1.Text + "'");

                driver.FindElement(By.Name("register.lastname")).SendKeys("dddddd");
                driver.FindElement(By.Name("register.email")).SendKeys("testolga78@gmail.com"); //o.ya@ro.ru o.qw@rambler.ru
                driver.FindElement(By.Name("register.password")).SendKeys("Test_Olga78"); //1111111111

                IWebElement radioBtn_gender = driver.FindElement(By.Name("register.gender"));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                //waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("register.gender")));
                radioBtn_gender.Click();

                IWebElement checkBtn_TermsAndConditions = driver.FindElement(By.Name("register.terms-and-conditions-checkbox"));
                // waitf.Until(ExpectedConditions.ElementToBeClickable(By.Name("register.terms-and-conditions-checkbox")));
                checkBtn_TermsAndConditions.Click();
                logger.Info("click on term_and_conditions");
                IWebElement checkBtn_Letter = driver.FindElement(By.Name("register.newsletter"));

                checkBtn_Letter.Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                IWebElement butt_Register = driver.FindElement(By.CssSelector(".z-button.z-button--primary.z-button--button"));
                butt_Register.Click();

                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("account"));
                // driver.Manage().Timeouts().PageLoad = new TimeSpan(0,0,20);
                Assert.AreEqual(@"https://www.zalando.nl/myaccount/", driver.Url); // can be mijnaccount!
                logger.Info("compate two links with 'https://www.zalando.nl/myaccount/' ");

                try
                {
                    var myAccountElement = driver.FindElement(By.Id("fieldAccountAccountBox"));
                    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                    Actions action = new Actions(driver); // подключить OpenQA.Selenium.Interactions, action дает возможность работать с мышкой
                    waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("fieldAccountAccountBox")));

                    action.MoveToElement(myAccountElement).Perform();
                    waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("customerAccountBoxLayer")));
                    var logout = driver.FindElement(By.PartialLinkText("Uitloggen"));

                    logout.Click();

                    waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/"));
                    logger.Info("wait for link contains https://www.zalando.nl/");
                    Assert.AreEqual(@"https://www.zalando.nl/", driver.Url);

                }
                catch (Exception ex)
                {
                    string s1 = "Exception on myAccountElement: Message: " + ex.Message + "; StackTrace:" + ex.StackTrace;
                    logger.Error(s1);
                    string s2 = string.Format("Exception on myAccountElement: Message: {0}; StackTrace: {1}", ex.Message, ex.StackTrace);
                    logger.Error(s2);
                    logger.ErrorFormat("Exception on myAccountElement: Message: {0}; StackTrace: {1}", ex.Message, ex.StackTrace);
                    string s3 = $"Exception on myAccountElement: Message:{ex.Message}; StackTrace:{ex.StackTrace}";

                    logger.ErrorFormat($"Exception on myAccountElement: Message:{ex.Message}; StackTrace:{ex.StackTrace}");
                    throw;
                }
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void CreateExistingUser(String BrowserName) //
        {
            try
            {
                Initialize(BrowserName);
                test = extent.CreateTest("CreateExistingUser");
                test.Fail("test");
                test.Info("info");
                extent.Flush();

                driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
                driver.FindElement(By.Name("register.firstname")).SendKeys("dfdfdso");
                driver.FindElement(By.Name("register.lastname")).SendKeys("dsfsdf");
                driver.FindElement(By.Name("register.email")).SendKeys("testolga77@gmail.com"); //o.ya@ro.ru o.qw@rambler.ru
                driver.FindElement(By.Name("register.password")).SendKeys("sdasdasdasdsad"); //1111111111
                IWebElement radioBtn_gender = driver.FindElement(By.Name("register.gender"));
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                radioBtn_gender.Click();
                IWebElement checkBtn_TermsAndConditions = driver.FindElement(By.Name("register.terms-and-conditions-checkbox"));
                // waitf.Until(ExpectedConditions.ElementToBeClickable(By.Name("register.terms-and-conditions-checkbox")));
                checkBtn_TermsAndConditions.Click();
                driver.FindElement(By.CssSelector(@".z-button.z-button--primary.z-button--button")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-1-notification__content")));
                var a = driver.FindElement(By.CssSelector(@".z-1-notification__content")).Text; 
                Assert.AreEqual("Volgens ons heb je al een account. Probeer in te loggen. Wachtwoord vergeten? Vraag een nieuwe aan.", a);
            } 
            catch (Exception ex)
            {
                test.Fail(ex.StackTrace);
                logger.ErrorFormat($"Exception on CreateExistingUser: Message {ex.Message}; StackTrace:{ex.StackTrace}");

                throw;


            }

        }


        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void SecondLogin(String BrowserName) //
        {
            try
            {
                test = extent.CreateTest("SecondLogin");
              
                extent.Flush();
                Initialize(BrowserName);

                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("login.email")));
                driver.FindElement(By.Name("login.email")).SendKeys("testolga77@gmail.com"); //o.ya@ro.ru oqw123
                driver.FindElement(By.Name("login.password")).SendKeys("Test_Olga77");
                driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();

                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("myaccount"));
                Assert.AreEqual(@"https://www.zalando.nl/myaccount/", driver.Url);
            }
            catch (NoSuchElementException ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void VerifyEmail(String BrowserName)

        {
            Initialize(BrowserName);
            try
            {
                test = extent.CreateTest("VerifyEmail");
              
                extent.Flush();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/sl/pwd?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&osid=1&service=mail&ss=1&ltmpl=default&rm=false&flowName=GlifWebSignIn&flowEntry=AddSession&cid=0&navigationDirection=forward");
                driver.FindElement(By.Id("identifierId")).SendKeys("testolga77@gmail.com");
                driver.FindElement(By.Id("identifierNext")).Click();
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                // Fill out the password field
                driver.FindElement(By.Name("password")).SendKeys("Test_Olga77");
                driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]")).Click(); //for apostrophes use backslash \ 
                                                                                   //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("#inbox"));
                driver.PageSource.Contains("Zalando");
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                //Thread.Sleep(10000); bad practice
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }

        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithInvalidEmail(String BrowserName)
        {
            try
            {
                Initialize(BrowserName);
                test = extent.CreateTest("LoginWithInvalidEmail");
                
                extent.Flush();
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");

                driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("login.email")));
                driver.FindElement(By.Name("login.email")).SendKeys("o.qw@ra"); //o.ya@ro.ru
                driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
                driver.FindElement(By.CssSelector(@"button.z-button:nth-child(2)")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-1-text.z-1-notification__content.z-1-text-detail-micro.z-1-text-black")));
                var a = driver.FindElement(By.CssSelector(@".z-1-text.z-1-notification__content.z-1-text-detail-micro.z-1-text-black")).Text;

                Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);
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
                test = extent.CreateTest("LoginWithIncorrectPsw");
                test.Fail("test");
                test.Info("info");
                extent.Flush();
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("login.email")));
                driver.FindElement(By.Name("login.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
                driver.FindElement(By.Name("login.password")).SendKeys("11111111");
                driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")));
                //  var a = driver.FindElement(By.CssSelector(".z-notification.z-notification--global.z-notification--error"));
                var b = driver.FindElement(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
                Assert.AreEqual("Controleer of je het juiste e-mailadres en wachtwoord gebruikt hebt en probeer het nog eens.", b);
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithNullUser(String BrowserName) //
        {
            try
            {
                Initialize(BrowserName);
                test = extent.CreateTest("LoginWithNullPsw");
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
                driver.FindElement(By.Name("login.email")).SendKeys(""); //o.ya@ro.ru
                driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
                driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
                var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
                Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);
            }

            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }



        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithNullPsw(String BrowserName) //
        {
            try
            {
                Initialize(BrowserName);
                test = extent.CreateTest("LoginWithNullPsw");
               
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
                driver.FindElement(By.Name("login.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
                driver.FindElement(By.Name("login.password")).SendKeys("");
                driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
                var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
                //var b = a.FindElement(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
                Assert.AreEqual("Dit is een verplicht veld", a);
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }
        }


        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithNullUserAndPsw(String BrowserName) //
        {
            try
            {
                Initialize(BrowserName);
                test = extent.CreateTest("LoginWithNullUserAndPsw");
                test.Fail("test");
                test.Info("info");
                driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
                driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
                driver.FindElement(By.Name("login.email")).SendKeys("");
                driver.FindElement(By.Name("login.password")).SendKeys("");
                driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
                var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }

        }


    }
}
