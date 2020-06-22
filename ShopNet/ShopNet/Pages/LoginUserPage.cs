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
    public class LoginUserPage : TestBase
    {
        public LoginUserPage(IWebDriver _driver, WebDriverWait _waitf)
        {
            driver = _driver;
            waitf = _waitf;
        }

        [FindsBy(How = How.ClassName, Using = "z-navicat-header_navToolLabel")]
        public IWebElement LoginLable { get; set; }
        [FindsBy(How = How.Id, Using = "login.email")]
        public IWebElement LoginEmail { get; set; }
        [FindsBy(How = How.Id, Using = "login.password")]
        public IWebElement LoginPassword { get; set; }
        [FindsBy(How = How.CssSelector, Using = "button[data-testid='login_button']")]
        public IWebElement LoginButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "z-navicat-header_userAccountLogoutW")]
        public IWebElement LogOutLink { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-1-text.z-1-notification__content.z-1-text-detail-micro.z-1-text-black")]
        public IWebElement InvalidEmailError { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")]
        public IWebElement InvalidPasswordError { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-text.z-notification__content.z-text-detail-micro.z-text-black")]
        public IWebElement BlankUserError { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-text.z-notification__content.z-text-detail-text-regular.z-text-black")]
        public IWebElement BlankPasswordError { get; set; }

        public void LoginLableClick (){
            LoginLable.Click();
        }

        public void InsertLoginValue(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        public void LoginUser()
        {
            LoginButton.Click();
        }
        public void LogOutUser()
        {
            LogOutLink.Click();
        }
        public string getErrorText(IWebElement element)
        {
            return element.Text;

        }

    }
}
