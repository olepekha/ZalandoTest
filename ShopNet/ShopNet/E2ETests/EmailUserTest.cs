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
    class EmailUserTest:TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void VerifyEmailSent(String BrowserName)

        {
            Initialize(BrowserName);
            try
            {
                test = extent.CreateTest("VerifyEmail");
                extent.Flush();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/sl/pwd?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&osid=1&service=mail&ss=1&ltmpl=default&rm=false&flowName=GlifWebSignIn&flowEntry=AddSession&cid=0&navigationDirection=forward");
                EmailUserPage page = new EmailUserPage(driver, waitf);
                PageFactory.InitElements(driver, page);

                page.Email.SendKeys("testolga77@gmail.com");
                page.NextButton.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                                // Fill out the password field
                page.Password.SendKeys("Test_Olga77");
                page.PasswordButton.Click(); 
                waitf.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("#inbox"));
                driver.PageSource.Contains("Zalando");
            }
            catch (Exception ex)
            { test.Fail(ex.StackTrace); }

        }
    }
}
