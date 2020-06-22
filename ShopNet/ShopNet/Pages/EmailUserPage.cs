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

namespace ShopNet.Pages
{
    class EmailUserPage
    {
        private IWebDriver driver;
        private WebDriverWait waitf;
        public EmailUserPage(IWebDriver _driver, WebDriverWait _waitf)
        {
            driver = _driver;
            waitf = _waitf;
        }

        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement Email { get; set; }
        [FindsBy(How = How.Id, Using = "identifierNext")]
        public IWebElement NextButton { get; set; }
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"passwordNext\"]")]
        public IWebElement PasswordButton { get; set; }


    }
}
