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

namespace ShopNet
{
    [TestFixture]
    public class LoginForm_FunctionalTests
    {
        IWebDriver driver;
        WebDriverWait waitf;
        TimeSpan t = new TimeSpan(0, 0, 10);//for timer set


        [SetUp]
        public void Initialize() //start browser
        {
            driver = new ChromeDriver();
            //driver.Quit();
            waitf = new WebDriverWait(driver, t);

        }

        [Test]
        public void CreateUserAndLogin() //user should be created
        {
            //driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.zalando.nl/login/?view=register");
            driver.FindElement(By.Name("register.firstname")).SendKeys("olga");
            driver.FindElement(By.Name("register.lastname")).SendKeys("aaaaa");
            driver.FindElement(By.Name("register.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
            driver.FindElement(By.Name("register.password")).SendKeys("1111111111");
           
            IWebElement radioBtn_gender = driver.FindElement(By.Name("register.gender"));
            radioBtn_gender.Click();

            IWebElement checkBtn_TermsAndConditions = driver.FindElement(By.Name("register.terms-and-conditions-checkbox"));
            checkBtn_TermsAndConditions.Click();


            driver.FindElement(By.CssSelector(".z-button.z-button--primary.z-button--button")).Click();
            waitf.Until(ExpectedConditions.UrlContains("mijnaccount"));
           // driver.Manage().Timeouts().PageLoad = new TimeSpan(0,0,20);
            Assert.AreEqual( @"https://www.zalando.nl/mijnaccount/", driver.Url);

       //  var myAccountElement = driver.FindElement(By.CssSelector("#fieldAccountAccountBox"));// 

            //var myAccountElement = driver.FindElement(By.ClassName("z-navicat-header_navToolLabel"));

      //   Actions action = new Actions(driver); // подключить OpenQA.Selenium.Interactions, action дает возможность работать с мышкой
        // action.MoveToElement(myAccountElement).MoveToElement(driver.FindElement(By.CssSelector(@"#logoutLink"))).Click().Perform();
      //   action.MoveToElement(myAccountElement).MoveToElement(driver.FindElement(By.ClassName(@"z-navicat-header_userAccountLogout"))).Click().Perform();
        

      
       // waitf.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".z-navicat-header_userAccountRegister")));

      //   waitf.Until(ExpectedConditions.TextToBePresentInElement(driver.FindElement(By.CssSelector(".z-text.z-navicat-header_navToolLabelName.z-text-cta.z-text-black")), "inloggen"));

        }

       
    [Test]
        public void SecondLogin() //
        {
        driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
        driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
        driver.FindElement(By.Name("login.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
        driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
        driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();
        waitf.Until(ExpectedConditions.UrlContains("myaccount"));
        Assert.AreEqual(@"https://www.zalando.nl/myaccount/",driver.Url);
        }

        // public void VerifyEmail() //
        // {

        //  }

        [Test]
     public void loginasinvaliduser() //
          {
          driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
          driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
          driver.FindElement(By.Name("login.email")).SendKeys("o.qw@ra"); //o.ya@ro.ru
          driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
          driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();


         var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
         Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);
        // var a = waitf.Until(ExpectedConditions.AlertIsPresent());
          //Assert.AreEqual(@"Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);  
       

      //    IAlert simpleAlert = driver.SwitchTo().Alert();
      //    var alertText = simpleAlert.Text;
      //    Assert.AreEqual(alertText, @"Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).");

          }

        [Test]
       public void LoginWithIncorrectPsw() //
         {
             driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
             driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
             waitf.Until(ExpectedConditions.ElementIsVisible(By.Name("login.email")));
             driver.FindElement(By.Name("login.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
             driver.FindElement(By.Name("login.password")).SendKeys("11111111");
             driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();

             waitf.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")));


           //  var a = driver.FindElement(By.CssSelector(".z-notification.z-notification--global.z-notification--error"));
             var b = driver.FindElement(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
             Assert.AreEqual("Controleer of je het juiste e-mailadres en wachtwoord gebruikt hebt en probeer het nog eens.", b);

        }

        [Test]
          public void LoginWithNullUser() //
          {
             driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
          driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
          driver.FindElement(By.Name("login.email")).SendKeys(""); //o.ya@ro.ru
          driver.FindElement(By.Name("login.password")).SendKeys("1111111111");
          driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();


         var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
         Assert.AreEqual("Vul alsjeblieft een geldig e-mailadres in (bijvoorbeeld voornaam.achternaam@domein.nl).", a);
         }

        [Test]
        public void LoginWithNullPsw() //
        {
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");
            driver.FindElement(By.ClassName("z-navicat-header_navToolLabel")).Click();
            driver.FindElement(By.Name("login.email")).SendKeys("o.qw@rambler.ru"); //o.ya@ro.ru
            driver.FindElement(By.Name("login.password")).SendKeys("");
            driver.FindElement(By.CssSelector(".z-button.z-coast-reef_login_button.z-button--primary.z-button--button")).Click();


            var a = driver.FindElement(By.CssSelector(@".z-text.z-notification__content.z-text-detail-micro.z-text-black")).Text;
            //var b = a.FindElement(By.CssSelector(".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")).Text;
            Assert.AreEqual("Dit is een verplicht veld", a);

        }

    [TearDown]
        public void CloseBrowser() //
        {

                      driver.Quit();
        }
    }
}
