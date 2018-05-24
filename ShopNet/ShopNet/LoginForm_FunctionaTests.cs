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


namespace ShopNet
{
    [TestFixture]
    public class LoginForm_FunctionalTests : TestBase



    {
        [Test]
        
        [TestCaseSource(typeof(TestBase),"BrowsersToRunWith")]
        public void CreateUserAndLogin(String BrowserName) //user should be created
        {
            Initialize(BrowserName);

            

            //driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
            driver.FindElement(By.Name("register.firstname")).SendKeys("olga");
            driver.FindElement(By.Name("register.lastname")).SendKeys("aaaaa");
            driver.FindElement(By.Name("register.email")).SendKeys("testolga77@gmail.com"); //o.ya@ro.ru o.qw@rambler.ru
            driver.FindElement(By.Name("register.password")).SendKeys("Test_Olga77"); //1111111111
           
            IWebElement radioBtn_gender = driver.FindElement(By.Name("register.gender"));
            Thread.Sleep(1000);
            //waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("register.gender")));
            radioBtn_gender.Click();
            IWebElement checkBtn_TermsAndConditions = driver.FindElement(By.Name("register.terms-and-conditions-checkbox"));
                                // waitf.Until(ExpectedConditions.ElementToBeClickable(By.Name("register.terms-and-conditions-checkbox")));
            checkBtn_TermsAndConditions.Click();
            IWebElement checkBtn_Letter = driver.FindElement(By.Name("register.newsletter"));
            checkBtn_Letter.Click();
            driver.FindElement(By.CssSelector(".z-button.z-button--primary.z-button--button")).Click();
             waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("mijnaccount"));
                                                                                                           //driver.Manage().Timeouts().PageLoad = new TimeSpan(0,0,20);
             Assert.AreEqual( @"https://www.zalando.nl/mijnaccount/", driver.Url);
            var myAccountElement = driver.FindElement(By.CssSelector("#fieldAccountAccountBox")); // var myAccountElement = driver.FindElement(By.ClassName("z-navicat-header_navToolLabel"));
             Actions action = new Actions(driver); // подключить OpenQA.Selenium.Interactions, action дает возможность работать с мышкой
             waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("fieldAccountAccountBox")));
             action.MoveToElement(myAccountElement).Perform();
             waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("customerAccountBoxLayer")));
             var logout = driver.FindElement(By.PartialLinkText("Uitloggen"));
             logout.Click();
             waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://www.zalando.nl/dames-home/"));
             Assert.AreEqual(@"https://www.zalando.nl/dames-home/", driver.Url);
            
        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void CreateExistedUser(String BrowserName) //user should be created
        {
            Initialize(BrowserName);

            driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
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
            waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")));
            var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
            Assert.AreEqual("Volgens ons heb je al een account. Probeer in te loggen. Wachtwoord vergeten? Vraag een nieuwe aan.", a);
        }

                   
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void SecondLogin(String BrowserName) //
        {
            Initialize(BrowserName);

        driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
        driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
        waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("login.email")));
        driver.FindElement(By.Name("login.email")).SendKeys("testolga77@gmail.com"); //o.ya@ro.ru oqw123
        driver.FindElement(By.Name("login.password")).SendKeys("Test_Olga77");
        driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();

        waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("myaccount"));
        Assert.AreEqual(@"https://www.zalando.nl/myaccount/",driver.Url);
        }

               [Test]
               [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
                public void VerifyEmail(String BrowserName)

               {
                   Initialize(BrowserName);
             
                    driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/sl/pwd?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&osid=1&service=mail&ss=1&ltmpl=default&rm=false&flowName=GlifWebSignIn&flowEntry=AddSession&cid=0&navigationDirection=forward");
                    driver.FindElement(By.Id("identifierId")).SendKeys("testolga77@gmail.com");
                    driver.FindElement(By.Id("identifierNext")).Click();
                    Thread.Sleep(1000);
                                 // Fill out the password field
                    driver.FindElement(By.Name("password")).SendKeys("Test_Olga77");
                    driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]")).Click(); //for apostrophes use backslash \ 
                    Thread.Sleep(10000);
                    waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("#inbox"));
                    driver.PageSource.Contains("Zalando");
                    Thread.Sleep(10000);


        }
               
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
         public void LoginAsInvaliduser(String BrowserName) 
    {
           Initialize(BrowserName);
           driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
             
           driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
           waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("login.email")));
           driver.FindElement(By.Name("login.email")).SendKeys("o.qw@ra"); //o.ya@ro.ru
           driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
           driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
           waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")));
                      
            var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
            Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);

        //  var a = waitf.Until(ExpectedConditions.AlertIsPresent());
       //   Assert.AreEqual(@"Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);  
      //    IAlert simpleAlert = driver.SwitchTo().Alert();
      //    var alertText = simpleAlert.Text;
      //    Assert.AreEqual(alertText, @"Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).");

          }


        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithIncorrectPsw(String BrowserName) //
         {
             Initialize(BrowserName);
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

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithNullUser(String BrowserName) //
        {
            Initialize(BrowserName);
             driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
          driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
          driver.FindElement(By.Name("login.email")).SendKeys(""); //o.ya@ro.ru
          driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
          driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
          var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
         Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);
         }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithNullPsw(String BrowserName) //
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
            driver.FindElement(By.Name("login.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
            driver.FindElement(By.Name("login.password")).SendKeys("");
            driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
            var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
            //var b = a.FindElement(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
            Assert.AreEqual("Dit is een verplicht veld", a);

        }

        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void LoginWithNullUserAndPsw(String BrowserName) //
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
            driver.FindElement(By.Name("login.email")).SendKeys(""); //o.ya@ro.ru
            driver.FindElement(By.Name("login.password")).SendKeys("");
            driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
            var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
            //var b = a.FindElement(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
            Assert.AreEqual(@"Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);

        }

   
    }
}
