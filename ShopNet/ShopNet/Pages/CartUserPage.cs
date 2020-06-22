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

namespace ShopNet.Pages
{
    class CartUserPage
    {
        private IWebDriver driver;
        private WebDriverWait waitf;
        public CartUserPage(IWebDriver _driver, WebDriverWait _waitf)
        {
            driver = _driver;
            waitf = _waitf;
        }

        [FindsBy(How = How.CssSelector, Using = @"span.\35 _bb")]
        public IWebElement Accessoires { get; set; }
        [FindsBy(How = How.Id, Using = "z-pdp-topSection-addToCartButton")]
        public IWebElement AddToCart { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-navicat-header_navToolItem.z-navicat-header_navToolItem-bag")]
        public IWebElement CartElement { get; set; }
        [FindsBy(How = How.ClassName, Using = "z - coast - base__tile - title")]
        public IWebElement CartTitle { get; set; }
        [FindsBy(How = How.ClassName, Using = "cat_articles")]
        public IWebElement CartArticles { get; set; }
        [FindsBy(How = How.ClassName, Using = "z-navicat-header_searchInput")]
        public IWebElement SearchInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z - icon.z - icon - search - semi - bold.z - icon - small.z - icon - black")]
        public IWebElement FoundBySearchItem { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".cat_brandName-2XZRz.cat_ellipsis-MujnT")]
        public IWebElement CartBrandName { get; set; }
        [FindsBy(How = How.ClassName, Using = "h-m-bottom-m")]
        public IWebElement ElementTitle { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-2-text.z-2-text-title-4.z-2-text-black")]
        public IWebElement CartCount { get; set; }
        [FindsBy(How = How.Id, Using = "uc-btn-accept-banner")]
        public IWebElement BannerAccept { get; set; }
        [FindsBy(How = How.CssSelector, Using = @".z-2-text.z-2-text-detail-text-regular.z-2-text-mediumgray")]
        public IWebElement DeleteItem { get; set; }
        public void UserClick(IWebElement element)
        {
            element.Click();
        }
        public string GetText(IWebElement element)
        {
           return element.Text;
        }
        public void SendText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
    }
}
