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


namespace ShopNet
{
    class DataDrivenLogin_FuncTest
    {
        /* [Theory]

           [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]

           public void LoginPositive(String BrowserName, String username, String password) //
            {
                Initialize(BrowserName);
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

            } */

    }

}
