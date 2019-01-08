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
    class ShoppingCart_FunctionalTests :TestBase
    {
        [Test]

        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void AddOneItemToTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");

        }

        [Test]

        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void AddTheSameItemToTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");

        }

        [Test]

        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void AddDifferenItemToTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");

        }

        [Test]

        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void RemoveOneItemFromTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");

        }

        [Test]

        [TestCaseSource(typeof(TestBase), "BrowsersToRunWith")]
        public void RemoveAllItemsFromTheCart(String BrowserName)
        {
            Initialize(BrowserName);
            driver.Navigate().GoToUrl("https://www.zalando.nl/dames-home/");

        }

        //test for developing: Increase the quantity of the item from the cart ,Click on an item in the cart ,Coupons 
    }

}
